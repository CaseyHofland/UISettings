using UnityEngine;
using UnityEngine.Audio;

namespace UISettings
{
    [UISetting("Audio")]
    public abstract class AudioSetting : Setting
    {
        private string saveKey => saveKeyPrefix + audioMixer.name + exposedParameter;

        public AudioMixer audioMixer;
        public string exposedParameter;

        protected virtual void Awake()
        {
            if(PlayerPrefs.HasKey(saveKey) && audioMixer)
            {
                audioMixer.SetFloat(exposedParameter, PlayerPrefs.GetFloat(saveKey));
            }
        }

        public void Clear()
        {
            if(audioMixer)
            {
                audioMixer.ClearFloat(exposedParameter);
            }
        }

        public override void Save()
        {
            if(audioMixer && audioMixer.GetFloat(exposedParameter, out var value))
            {
                PlayerPrefs.SetFloat(saveKey, value);
                PlayerPrefs.Save();
            }
        }
    }
}

