using UnityEngine;

namespace UISettings
{
    [UISetting("Shadows")]
    public abstract class ShadowsSetting : Setting
    {
        private const string saveKey = saveKeyPrefix + "QualitySettingsShadows";

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Init()
        {
            if(PlayerPrefs.HasKey(saveKey))
            {
                QualitySettings.shadows = (ShadowQuality)PlayerPrefs.GetInt(saveKey);
            }
        }

        public override void Save()
        {
            PlayerPrefs.SetInt(saveKey, (int)QualitySettings.shadows);
            PlayerPrefs.Save();
        }
    }
}
