using UnityEngine;
using UnityEngine.UI;

namespace UISettings
{
    public class FullScreenSetting : UISetting<Toggle>
    {
        [Tooltip("Display if the game is windowed instead of full screen.")] [SerializeField] private bool _windowed;

        public bool windowed
        {
            get => _windowed;
            set
            {
                _windowed = value;
                UpdateView();
            }
        }

        protected override void Subscribe()
        {
            selectable.onValueChanged.AddListener(ValueChanged);
        }

        protected override void Unsubscribe()
        {
            selectable.onValueChanged.RemoveListener(ValueChanged);
        }

        public override void UpdateView()
        {
            selectable.SetIsOnWithoutNotify(Screen.fullScreen != windowed);
        }

        private void ValueChanged(bool value)
        {
            Screen.fullScreen = value != windowed;
        }
    }
}

