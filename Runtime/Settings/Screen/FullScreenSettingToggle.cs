using UnityEngine;
using UnityEngine.UI;

namespace UISettings
{
    public class FullScreenSettingToggle : FullScreenSetting, ISettingToggle
    {
        [Tooltip("Display if the game is windowed instead of full screen.")] public bool windowed;

        public void UpdateView(Toggle toggle)
        {
            toggle.SetIsOnWithoutNotify(Screen.fullScreen != windowed);
        }

        public void ValueChanged(bool value)
        {
            Screen.fullScreen = value != windowed;
            Save();
        }
    }
}
