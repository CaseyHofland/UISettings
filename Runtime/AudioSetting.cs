using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace UISettings
{
    public class AudioSetting : MonoBehaviour
    {
        public Slider slider;
        public AudioMixer audioMixer;
        public string exposedParameter;
        public float minValue = -80f;
        public float maxValue = 0f;

        public float value
        {
            get => Mathf.Lerp(minValue, maxValue, slider.normalizedValue);
            set => slider.normalizedValue = Mathf.InverseLerp(minValue, maxValue, value);
        }

        public float normalizedValue
        {
            get => slider.normalizedValue;
            set => slider.normalizedValue = Mathf.Clamp01(value);
        }

        private void OnEnable()
        {
            slider.onValueChanged.AddListener(OnValueChanged);

            if(audioMixer && audioMixer.GetFloat(exposedParameter, out var value))
            {
                if(isActiveAndEnabled)
                {
                    StartCoroutine(Coroutine());

                    IEnumerator Coroutine()
                    {
                        yield return null;
                        this.value = value;
                    }
                }
            }
        }

        private void OnDisable()
        {
            slider.onValueChanged.RemoveListener(OnValueChanged);
        }

        private void OnValueChanged(float value)
        {
            if(audioMixer)
            {
                audioMixer.SetFloat(exposedParameter, this.value);
            }
        }

        public void Clear()
        {
            if(audioMixer && audioMixer.ClearFloat(exposedParameter))
            {
                if(isActiveAndEnabled)
                {
                    StartCoroutine(Coroutine());

                    IEnumerator Coroutine()
                    {
                        yield return null;
                        if(audioMixer && audioMixer.GetFloat(exposedParameter, out var value))
                        {
                            this.value = value;
                        }
                    }
                }
            }
        }

        private void Reset()
        {
            slider = GetComponent<Slider>();
        }
    }
}
