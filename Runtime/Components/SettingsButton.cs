using UnityEngine;
using UnityEngine.UI;

namespace UISettings
{
    [RequireComponent(typeof(Button))]
    [AddComponentMenu("UI/Settings/SettingsButton")]
    public class SettingsButton : SettingsSelectable
    {
        public Button button => (Button)selectable;
        public ISettingButton settingButton => (ISettingButton)setting;

        protected virtual void OnEnable()
        {
            if(settingButton != null)
            {
                button.onClick.AddListener(settingButton.Clicked);
            }
        }

        protected virtual void OnDisable()
        {
            if(settingButton != null)
            {
                button.onClick.RemoveListener(settingButton.Clicked);
            }
        }

        protected override void LateUpdate()
        {
            base.LateUpdate();
            settingButton?.UpdateView(button);
        }
    }
}

