using UnityEngine;
using UnityEngine.UI;

namespace UISettings
{
    [RequireComponent(typeof(Dropdown))]
    [AddComponentMenu("UI/Settings/SettingsDropdown")]
    public class SettingsDropdown : SettingsSelectable
    {
        public Dropdown dropdown => (Dropdown)selectable;
        public IDropdownSetting dropdownSetting => (IDropdownSetting)setting;

        protected override void OnEnable()
        {
            dropdownSetting.UpdateView(dropdown);
            dropdown.onValueChanged.AddListener(dropdownSetting.ValueChanged);
        }

        protected virtual void OnDisable()
        {
            dropdown.onValueChanged.RemoveListener(dropdownSetting.ValueChanged);
        }

        protected override void OnValidate()
        {
            if(isActiveAndEnabled && !Application.IsPlaying(gameObject))
            {
                dropdownSetting.UpdateView(dropdown);
            }
        }
    }
}

