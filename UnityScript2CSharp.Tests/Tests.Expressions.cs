using NUnit.Framework;

namespace UnityScript2CSharp.Tests
{
    [TestFixture]
    public partial class Tests
    {
        [Test]
        public void Self_Implicit()
        {
            //TODO: is it possible to get rid of the synthetic *self* ? (it is not marked as such)
            var sourceFiles = SingleSourceFor("self_implict.js", "public var a : int; function F() { a = 42; }");
            var expectedConvertedContents = SingleSourceFor("self_implict.cs", DefaultGeneratedClass + @"self_implict : MonoBehaviour { public int a; public virtual void F() { this.a = 42; } }");

            AssertConversion(sourceFiles, expectedConvertedContents);
        }

        [TestCase("int", "int")]
        [TestCase("String", "string")]
        [TestCase("System.Object", "object")]
        [TestCase("boolean", "bool")]
        public void Arrays_New(string usTypeName, string csTypeName)
        {
            var sourceFiles = SingleSourceFor("arrays_new.js", $"public var a : {usTypeName} []; function F() {{ a = new {usTypeName}[10]; }}");
            var expectedConvertedContents = SingleSourceFor("arrays_new.cs", DefaultGeneratedClass + $@"arrays_new : MonoBehaviour {{ public {csTypeName}[] a; public virtual void F() {{ this.a = new {csTypeName}[10]; }} }}");

            AssertConversion(sourceFiles, expectedConvertedContents);
        }

        [Test]
        public void Simple_Generic_Methods()
        {
            var sourceFiles = SingleSourceFor("simple_generic_method.js", "import UnityScript2CSharp.Tests; function F(o:NonGeneric) { return o.ToName.<NonGeneric>(42); }");
            var expectedConvertedFiles = SingleSourceFor("simple_generic_method.cs", "using UnityScript2CSharp.Tests; " + DefaultGeneratedClass + "simple_generic_method : MonoBehaviour { public virtual string F(NonGeneric o) { return o.ToName<NonGeneric>(42); } }");

            AssertConversion(sourceFiles, expectedConvertedFiles);
        }
    }
}
