#if TMP
using System;
using System.Collections.Generic;
using UnityEngine;

namespace UISettings
{
    public class TMP_ResolutionSetting : ResolutionSetting, ITMP_DropdownSetting
    {
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
        }
    }
}
#endif