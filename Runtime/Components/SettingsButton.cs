using UnityEngine;
using UnityEngine.UI;

namespace UISettings
{
    [RequireComponent(typeof(Button))]
    [AddComponentMenu("UI/Settings/SettingsButton")]
    public class SettingsButton : SettingsSelectable
    {
        public Button button => (Button)selectable;
        public IButtonSetting buttonSetting => (IButtonSetting)setting;

        protected virtual void OnEnable()
        {
            if(buttonSetting != null)
            {
                button.onClick.AddListener(buttonSetting.Clicked);
            }
        }

        protected virtual void OnDisable()
        {
            if(buttonSetting != null)
            {
                button.onClick.RemoveListener(buttonSetting.Clicked);
            }
        }

        protected override void LateUpdate()
        {
            base.LateUpdate();
            buttonSetting?.UpdateView(button);
        }
    }
}

