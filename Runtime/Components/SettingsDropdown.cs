using UnityEngine;
using UnityEngine.UI;

namespace UISettings
{
    [RequireComponent(typeof(Dropdown))]
    [AddComponentMenu("UI/Settings/SettingsDropdown")]
    public class SettingsDropdown : SettingsSelectable
    {
        public Dropdown dropdown => (Dropdown)selectable;
        public ISettingDropdown settingDropdown => (ISettingDropdown)setting;

        protected virtual void OnEnable()
        {
            if(settingDropdown != null)
            {
                dropdown.onValueChanged.AddListener(settingDropdown.ValueChanged);
            }
        }

        protected virtual void OnDisable()
        {
            if(settingDropdown != null)
            {
                dropdown.onValueChanged.RemoveListener(settingDropdown.ValueChanged);
            }
        }

        protected override void LateUpdate()
        {
            base.LateUpdate();
            settingDropdown?.UpdateView(dropdown);
        }

        public void ResetOptions()
        {
            settingDropdown.ResetOptions(dropdown.options);
        }
    }
}

