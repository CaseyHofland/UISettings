using System;

namespace UISettings
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = true)]
    public class UINameAttribute : Attribute
    {
        public string name;
        public int order;

        public UINameAttribute(string name)
        {
            this.name = name;
        }
    }
}

