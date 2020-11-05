using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace UISettings
{
    public class AudioSetting : UISetting<Slider>
    {
        #region Properties
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private string _exposedParameter;
        [SerializeField] private float _minValue = -80f;
        [SerializeField] private float _maxValue = 0f;

        public AudioMixer audioMixer
        {
            get => _audioMixer;
            set
            {
                _audioMixer = value;
                UpdateView();
            }
        }

        public string exposedParameter
        {
            get => _exposedParameter;
            set
            {
                _exposedParameter = value;
                UpdateView();
            }
        }

        public float minValue
        {
            get => _minValue;
            set
            {
                _minValue = value;
                UpdateView();
            }
        }

        public float maxValue
        {
            get => _maxValue;
            set
            {
                _maxValue = value;
                UpdateView();
            }
        }

        public float value
        {
            get => Mathf.Lerp(minValue, maxValue, selectable.normalizedValue);
            set => selectable.normalizedValue = Mathf.InverseLerp(minValue, maxValue, value);
        }
        #endregion

        protected override void Subscribe()
        {
            selectable.onValueChanged.AddListener(OnValueChanged);
        }

        protected override void Unsubscribe()
        {
            selectable.onValueChanged.RemoveListener(OnValueChanged);
        }

        protected override void OnValidate()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.delayCall += base.OnValidate;
#else
            base.OnValidate();
#endif
        }

        public override void UpdateView()
        {
            if(audioMixer && audioMixer.GetFloat(exposedParameter, out var value))
            {
                var t = Mathf.InverseLerp(minValue, maxValue, value);
                var input = Mathf.Lerp(selectable.minValue, selectable.maxValue, t);
                selectable.SetValueWithoutNotify(input);

                OnValueChanged(selectable.normalizedValue);
            }
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
                Invoke(nameof(UpdateView), Time.fixedUnscaledDeltaTime);
            }
        }
    }
}
