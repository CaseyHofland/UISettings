using UnityEngine.Audio;
using UnityEngine.UI;

namespace UISettings
{
    [UISetting("Audio")]
    public class AudioSetting : Setting, ISliderSetting
    {
        public AudioMixer audioMixer;
        public string exposedParameter;
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
            }
        }

        public void Clear()
        {
            if(audioMixer)
            {
                audioMixer.ClearFloat(exposedParameter);
            }
        }
    }
}

