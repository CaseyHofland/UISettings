using UnityEngine;
using UnityEngine.UI;

namespace UISettings
{
    [RequireComponent(typeof(Toggle))]
    [AddComponentMenu("UI/Settings/SettingsToggle")]
    public class SettingsToggle : SettingsSelectable
    {
        public Toggle toggle => (Toggle)selectable;
        public IToggleSetting toggleSetting => (IToggleSetting)setting;

        protected virtual void OnEnable()
        {
            if(toggleSetting != null)
            {
                toggle.onValueChanged.AddListener(toggleSetting.ValueChanged);
            }
        }

        protected virtual void OnDisable()
        {
            if(toggleSetting != null)
            {
                toggle.onValueChanged.RemoveListener(toggleSetting.ValueChanged);
            }
        }

        protected override void LateUpdate()
        {

            base.LateUpdate();
            toggleSetting?.UpdateView(toggle);
        }
    }
}

