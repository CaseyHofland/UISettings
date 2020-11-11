using UnityEngine;

namespace UISettings
{
    [UISetting("Resolution")]
    public abstract class ResolutionSetting : Setting
    {
        private const string saveKey = saveKeyPrefix + "ScreenResolutions";
        private const string widthKey = saveKey + "Width";
        private const string heightKey = saveKey + "Height";
        private const string refreshRateKey = saveKey + "RefreshRate";

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        private static void Init()
        {
            if(PlayerPrefs.HasKey(widthKey) 
                && PlayerPrefs.HasKey(heightKey) 
                && PlayerPrefs.HasKey(refreshRateKey))
            {
                var width = PlayerPrefs.GetInt(widthKey);
                var height = PlayerPrefs.GetInt(heightKey);
                var refreshRate = PlayerPrefs.GetInt(refreshRateKey);
                Screen.SetResolution(width, height, Screen.fullScreenMode, refreshRate);
            }
        }

        public override void Save()
        {
            var resolution = Screen.currentResolution;
            PlayerPrefs.SetInt(widthKey, resolution.width);
            PlayerPrefs.SetInt(heightKey, resolution.height);
            PlayerPrefs.SetInt(refreshRateKey, resolution.refreshRate);
            PlayerPrefs.Save();
        }
    }
}
