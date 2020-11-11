using UnityEngine;
using UnityEngine.UI;

namespace UISettings
{
    [RequireComponent(typeof(Slider))]
    [AddComponentMenu("UI/Settings/SettingsSlider")]
    public class SettingsSlider : SettingsSelectable
    {
        public Slider slider => (Slider)selectable;
        public ISettingSlider settingSlider => (ISettingSlider)setting;

        protected virtual void OnEnable()
        {
            if(settingSlider != null)
            {
                slider.onValueChanged.AddListener(settingSlider.ValueChanged);
            }
        }

        protected virtual void OnDisable()
        {
            if(settingSlider != null)
            {
                slider.onValueChanged.RemoveListener(settingSlider.ValueChanged);
            }
        }

        protected override void LateUpdate()
        {
            base.LateUpdate();
            settingSlider?.UpdateView(slider);
        }
    }
}

