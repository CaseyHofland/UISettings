using UnityEngine;
using UnityEngine.UI;

namespace UISettings
{
    [RequireComponent(typeof(Toggle))]
    [AddComponentMenu("UI/Settings/SettingsToggle")]
    public class SettingsToggle : SettingsSelectable
    {
        public Toggle toggle => (Toggle)selectable;
        public ISettingToggle settingToggle => (ISettingToggle)setting;

        protected virtual void OnEnable()
        {
            if(settingToggle != null)
            {
                toggle.onValueChanged.AddListener(settingToggle.ValueChanged);
            }
        }

        protected virtual void OnDisable()
        {
            if(settingToggle != null)
            {
                toggle.onValueChanged.RemoveListener(settingToggle.ValueChanged);
            }
        }

        protected override void LateUpdate()
        {
            base.LateUpdate();
            settingToggle?.UpdateView(toggle);
        }
    }
}

