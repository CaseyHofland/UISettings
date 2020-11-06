using UnityEngine;
using UnityEngine.UI;

namespace UISettings
{
    [RequireComponent(typeof(Scrollbar))]
    [AddComponentMenu("UI/Settings/SettingsScrollbar")]
    public class SettingsScrollbar : SettingsSelectable
    {
        public Scrollbar scrollbar => (Scrollbar)selectable;
        public IScrollbarSetting scrollbarSetting => (IScrollbarSetting)setting;

        protected virtual void OnEnable()
        {
            if(scrollbarSetting != null)
            {
                scrollbar.onValueChanged.AddListener(scrollbarSetting.ValueChanged);
            }
        }

        protected virtual void OnDisable()
        {
            if(scrollbarSetting != null)
            {
                scrollbar.onValueChanged.RemoveListener(scrollbarSetting.ValueChanged);
            }
        }

        protected override void LateUpdate()
        {
            base.LateUpdate();
            scrollbarSetting?.UpdateView(scrollbar);
        }
    }
}

