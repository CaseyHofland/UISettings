using UnityEngine;
using UnityEngine.UI;

namespace UISettings
{
    [RequireComponent(typeof(Scrollbar))]
    [AddComponentMenu("UI/Settings/SettingsScrollbar")]
    public class SettingsScrollbar : SettingsSelectable
    {
        public Scrollbar scrollbar => (Scrollbar)selectable;
        public ISettingScrollbar settingScrollbar => (ISettingScrollbar)setting;

        protected virtual void OnEnable()
        {
            if(settingScrollbar != null)
            {
                scrollbar.onValueChanged.AddListener(settingScrollbar.ValueChanged);
            }
        }

        protected virtual void OnDisable()
        {
            if(settingScrollbar != null)
            {
                scrollbar.onValueChanged.RemoveListener(settingScrollbar.ValueChanged);
            }
        }

        protected override void LateUpdate()
        {
            base.LateUpdate();
            settingScrollbar?.UpdateView(scrollbar);
        }
    }
}

