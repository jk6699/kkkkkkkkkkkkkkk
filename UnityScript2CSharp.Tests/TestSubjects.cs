using System;

namespace UnityEngine
{
    public class Component
    {
        public Component GetComponent(string s) { return this; }
        public Component GetComponent(Type t) { return this; }
        public Component GetComponent<T>() { return this; }
    }
    public class GameObject
    {
        public Component GetComponent(string s) { return null; }
        public Component GetComponent(Type t) { return null; }
        public Component GetComponent<T>() { return null; }
    }
}

namespace UnityEditor
{
    public class Editor
    {
    }
}

namespace UnityScript2CSharp.Tests
{
    public class Outer
    {
        public class Inner
        {
            public class Inner2 {}
        }
    }

    public class Base
    {
        public virtual void M() {}
    }

    public class C
    {
        public static C instance;
        public C myself;

        public static int staticField;
        public static int staticMethod() { return 1; }
        public C instanceMethod() { return null; }

        public C(int i) {}
        public C() {}
    }

    public struct Other
    {
        public string value;
    }

    public sealed class ReferenceType
    {
        public static Other staticOther { get; set; }
    }

    public struct Struct
    {
        public Struct(int i)
        {
            value = i;
            other = default(Other);
        }

        public int value { get; set; }
        public Other other { get; set; }
        public static Other staticOther { get; set; }
    }

    public class NonGeneric
    {
        public string ToName<T>(int n)
        {
            return typeof(T).FullName;
        }

        public Struct Struct { get; set; }
    }

    public class Operators
    {
        public static implicit operator bool(Operators instance)
        {
            return false;
        }

        public static Operators operator*(Operators instance, float n) { return instance; }

        public static Operators operator+(Operators instance, float n) { return instance; }

        public static Operators operator-(Operators instance) { return instance; }

        public static Operators operator+(Operators instance) { return instance; }

        public static Operators operator~(Operators instance) { return instance; }

        public static bool operator!(Operators instance) { return instance; }

        public string Message = "Foo";
    }

    public class Properties
    {
        public int this[int i, string j]
        {
            get { return i; }
            set {}
        }

        public int this[int i]
        {
            get { return i; }
            set {}
        }
    }

    public class AttrAttribute : Attribute
    {
        public AttrAttribute()
        {
        }

        public AttrAttribute(int i)
        {
        }

        public AttrAttribute(Type t)
        {
        }

        public bool Prop { get; set; }
    }

    public class NonCompliant : Attribute
    {
    }

    public class SystemTypeAsParameter
    {
        public SystemTypeAsParameter(Type t) {}

        public static void SimpleMethod(Type t) {}

        public void InParamsArray(params Type[] t) {}
    }

    public class Methods
    {
        public static void OutRef(out int i, ref int j)
        {
            i = 10;
            j = i;
        }
    }

    public struct ObjectType
    {
        public static Object NonGeneric() {  return null; }

        public static T Generic<T>() {  return default(T); }

        public static void Parameter<T>(T p) { }
    }
}
