using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UISettings
{
    public class ResolutionSetting : UISetting<Dropdown>
    {
        [SerializeField] private bool _descending = false;

        public bool descending
        {
            get => _descending;
            set
            {
                _descending = value;
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
            selectable.ClearOptions();

            var options = new List<string>(Array.ConvertAll(Screen.resolutions, resolution => $"{resolution.width}x{resolution.height}"));
            if(descending)
            {
                options.Reverse();
            }

            selectable.AddOptions(options);

            var resolutionIndex = Array.IndexOf(Screen.resolutions, Screen.currentResolution);
            if(resolutionIndex != -1)
            {
                if(descending)
                {
                    resolutionIndex = Screen.resolutions.Length - 1 - resolutionIndex;
                }

                selectable.SetValueWithoutNotify(resolutionIndex);
                selectable.RefreshShownValue();
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
    }
}