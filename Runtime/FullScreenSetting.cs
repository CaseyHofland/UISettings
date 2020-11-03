using UnityEngine;
using UnityEngine.UI;

namespace UISettings
{
    public class FullScreenSetting : MonoBehaviour
    {
        #region Properties
        [SerializeField] private Toggle _toggle;
        [Tooltip("Display if the game is windowed instead of full screen.")] [SerializeField] private bool _windowed;

        public Toggle toggle
        {
            get => _toggle;
            set
            {
                OnDisable();
                _toggle = value;
                OnEnable();
            }
        }

        public bool windowed
        {
            get => _windowed;
            set
            {
                _windowed = value;
                UpdateView();
            }
        }
        #endregion

        #region Unity Methods
        private void OnEnable()
        {
            toggle.onValueChanged.AddListener(ValueChanged);

            UpdateView();
        }

        private void OnDisable()
        {
            toggle.onValueChanged.RemoveListener(ValueChanged);
        }

        private void Reset()
        {
            _toggle = GetComponent<Toggle>();
        }
        #endregion

        #region Toggle Handling
        public void UpdateView()
        {
            toggle.SetIsOnWithoutNotify(Screen.fullScreen != windowed);
        }

        private void ValueChanged(bool value)
        {
            Screen.fullScreen = value != windowed;
        }
        #endregion
    }
}

