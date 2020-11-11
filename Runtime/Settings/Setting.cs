using UnityEngine;
using UnityEngine.UI;

namespace UISettings
{
    public abstract class Setting : ScriptableObject, ISettingSelectable
    {
        internal protected const string saveKeyPrefix = "UISettingsSetting";

        public virtual void UpdateView(Selectable selectable) { }
        public abstract void Save();
    }
}
