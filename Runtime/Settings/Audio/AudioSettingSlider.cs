using UnityEngine.UI;

namespace UISettings
{
    public class AudioSettingSlider : AudioSetting, ISettingSlider
    {
        public float minValue = -80f;
        public float maxValue = 0f;

        public void UpdateView(Slider slider)
        {
            slider.minValue = minValue;
            slider.maxValue = maxValue;

            if(audioMixer && audioMixer.GetFloat(exposedParameter, out var value))
            {
                slider.SetValueWithoutNotify(value);
            }
        }

        public void ValueChanged(float value)
        {
            if(audioMixer)
            {
                audioMixer.SetFloat(exposedParameter, value);
                Save();
            }
        }
    }
}
