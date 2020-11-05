using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UISettings
{
    [UISetting("Resolution")]
    public class ResolutionSetting : IDropdownSetting, ITMP_DropdownSetting
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

            UpdateView((Selectable)dropdown);
        }

#if TMP
        public void UpdateView(TMPro.TMP_Dropdown tmp_Dropdown)
        {
            tmp_Dropdown.ClearOptions();

            var options = new List<string>(Array.ConvertAll(Screen.resolutions, resolution => $"{resolution.width}x{resolution.height}"));
            if(descending)
            {
                options.Reverse();
            }

            tmp_Dropdown.AddOptions(options);

            var resolutionIndex = Array.IndexOf(Screen.resolutions, Screen.currentResolution);
            if(resolutionIndex != -1)
            {
                if(descending)
                {
                    resolutionIndex = Screen.resolutions.Length - 1 - resolutionIndex;
                }

                tmp_Dropdown.SetValueWithoutNotify(resolutionIndex);
                tmp_Dropdown.RefreshShownValue();
            }

            UpdateView((Selectable)tmp_Dropdown);
        }
#endif

        public void UpdateView(Selectable selectable) { }

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
