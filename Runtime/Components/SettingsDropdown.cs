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

        protected virtual void OnEnable()
        {
            if(dropdownSetting != null)
            {
                dropdown.onValueChanged.AddListener(dropdownSetting.ValueChanged);
            }
        }

        protected virtual void OnDisable()
        {
            if(dropdownSetting != null)
            {
                dropdown.onValueChanged.RemoveListener(dropdownSetting.ValueChanged);
            }
        }

        protected override void LateUpdate()
        {
            base.LateUpdate();
            dropdownSetting?.UpdateView(dropdown);
        }
    }
}

