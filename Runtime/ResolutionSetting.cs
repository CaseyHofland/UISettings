using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UISettings
{
    public class ResolutionSetting : MonoBehaviour
    {
        #region Properties
        [SerializeField] private Dropdown _dropdown;
        [SerializeField] private bool _descending = false;

        public Dropdown dropdown
        {
            get => _dropdown;
            set
            {
                OnDisable();
                _dropdown = value;
                OnEnable();
            }
        }

        public bool descending
        {
            get => _descending;
            set
            {
                _descending = value;
                SetOptions();
            }
        }
        #endregion

        #region Unity Methods
        private void OnEnable()
        {
            dropdown.onValueChanged.AddListener(ValueChanged);

            SetOptions();
        }

        private void OnDisable()
        {
            dropdown.onValueChanged.RemoveListener(ValueChanged);
        }

        private void Reset()
        {
            _dropdown = GetComponent<Dropdown>();
        }
        #endregion

        #region Dropdown Handling
        public void SetOptions()
        {
            dropdown.ClearOptions();

            var options = new List<string>(Array.ConvertAll(Screen.resolutions, resolution => $"{resolution.width}x{resolution.height}"));
            if(descending)
            {
                options.Reverse();
            }

            dropdown.AddOptions(options);

            var resolutionIndex = Array.IndexOf(Screen.resolutions, Screen.currentResolution);
            if(resolutionIndex != -1)
            {
                if(descending)
                {
                    resolutionIndex = Screen.resolutions.Length - 1 - resolutionIndex;
                }

                dropdown.SetValueWithoutNotify(resolutionIndex);
                dropdown.RefreshShownValue();
            }
        }

        private void ValueChanged(int value)
        {
            if(descending)
            {
                value = Screen.resolutions.Length - 1 - value;
            }

            var resolution = Screen.resolutions[value];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode);
        }
        #endregion
    }
}