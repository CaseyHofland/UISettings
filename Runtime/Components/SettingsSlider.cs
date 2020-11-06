using UnityEngine;
using UnityEngine.UI;

namespace UISettings
{
    [RequireComponent(typeof(Slider))]
    [AddComponentMenu("UI/Settings/SettingsSlider")]
    public class SettingsSlider : SettingsSelectable
    {
        public Slider slider => (Slider)selectable;
        public ISliderSetting sliderSetting => (ISliderSetting)setting;

        protected virtual void OnEnable()
        {
            if(sliderSetting != null)
            {
                slider.onValueChanged.AddListener(sliderSetting.ValueChanged);
            }
        }

        protected virtual void OnDisable()
        {
            if(sliderSetting != null)
            {
                slider.onValueChanged.RemoveListener(sliderSetting.ValueChanged);
            }
        }

        protected override void LateUpdate()
        {
            base.LateUpdate();
            sliderSetting?.UpdateView(slider);
        }
    }
}

