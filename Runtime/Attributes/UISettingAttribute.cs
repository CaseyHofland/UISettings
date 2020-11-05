using System;

namespace UISettings
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface, AllowMultiple = false, Inherited = true)]
    public sealed class UISettingAttribute : Attribute
    {
        private string name;
        public int order;

        public UISettingAttribute(string name)
        {
            this.name = name;
        }

        public string GetName() => name;
    }
}
