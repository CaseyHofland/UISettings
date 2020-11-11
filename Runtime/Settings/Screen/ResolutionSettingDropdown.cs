using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UISettings
{
    public class ResolutionSettingDropdown : ResolutionSetting, ISettingDropdown
    {
        public bool descending = false;
        protected bool lastDescending = false;

        public void UpdateView(Dropdown dropdown)
        {
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

        public void ResetOptions(List<Dropdown.OptionData> options)
        {
            options.Clear();

            var optionNames = new List<string>(Array.ConvertAll(Screen.resolutions, resolution => $"{resolution.width}x{resolution.height}"));
            if(descending)
            {
                optionNames.Reverse();
            }

            options.AddRange(optionNames.ConvertAll(optionName => new Dropdown.OptionData(optionName)));
        }

        public void ValueChanged(int value)
        {
            if(descending)
            {
                value = Screen.resolutions.Length - 1 - value;
            }

            var resolution = Screen.resolutions[value];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode);
            Save();
        }
    }
}
