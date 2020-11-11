using UnityEngine;

namespace UISettings
{
    [UISetting("VSync")]
    public abstract class VSyncSetting : Setting
    {
        private const string saveKey = saveKeyPrefix + "QualitySettingsVSyncCount";

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        private static void Init()
        {
            if(PlayerPrefs.HasKey(saveKey))
            {
                QualitySettings.vSyncCount = PlayerPrefs.GetInt(saveKey);
            }
        }

        public override void Save()
        {
            PlayerPrefs.SetInt(saveKey, QualitySettings.vSyncCount);
            PlayerPrefs.Save();
        }
    }
}

