using System.Collections;
using System.Collections.Generic;
using UISettings;
using UnityEngine;
using UnityEngine.UI;

namespace UISettings
{
    [UIName("Something/FullScreen", order = 50)]
    public class NewFullScreenSetting : ToggleSetting
    {
        [Tooltip("Display if the game is windowed instead of full screen.")] [SerializeField] private bool _windowed;

        public bool windowed
        {
            get => _windowed;
            set
            {
                _windowed = value;
                //UpdateView();
            }
        }

        public override void UpdateView(Toggle toggle)
        {
            toggle.SetIsOnWithoutNotify(Screen.fullScreen != windowed);
        }

        protected internal override void ValueChanged(bool value)
        {
            Screen.fullScreen = value != windowed;
        }
    }
}
