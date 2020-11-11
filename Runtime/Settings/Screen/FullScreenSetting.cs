using UnityEngine;

namespace UISettings
{
    [UISetting("FullScreen")]
    public abstract class FullScreenSetting : Setting
    {
        private const string saveKey = saveKeyPrefix + "ScreenFullScreenMode";

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        private static void Init()
        {
            if(PlayerPrefs.HasKey(saveKey))
            {
                Screen.fullScreenMode = (FullScreenMode)PlayerPrefs.GetInt(saveKey);
            }
        }

        public override void Save()
        {
            PlayerPrefs.SetInt(saveKey, (int)Screen.fullScreenMode);
            PlayerPrefs.Save();
        }
    }
}
