using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UISettings
{
    [UISetting("Resolution")]
    public class ResolutionSetting : Setting, IDropdownSetting
    {
        public bool descending = false;

        public void UpdateView(Dropdown dropdown)
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

        public void ValueChanged(int value)
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
