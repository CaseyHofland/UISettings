using UnityEngine;
using UnityEngine.UI;

namespace UISettings
{
    [UISetting("FullScreen")]
    public class FullScreenSetting : Setting, IToggleSetting
    {
        [Tooltip("Display if the game is windowed instead of full screen.")] public bool windowed;

        public void UpdateView(Toggle toggle)
        {
            toggle.SetIsOnWithoutNotify(Screen.fullScreen != windowed);
        }

        public void ValueChanged(bool value)
        {
            Screen.fullScreen = value != windowed;
        }
    }
}
