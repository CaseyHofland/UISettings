#if TMP
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UISettings
{
    public class ResolutionSettingTMP_Dropdown : ResolutionSettingDropdown, ISettingTMP_Dropdown
    {
        public void UpdateView(TMP_Dropdown tmp_Dropdown)
        {
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

        public void ResetOptions(List<TMP_Dropdown.OptionData> options)
        {
            options.Clear();

            var newOptions = options.ToDropdownOptionData();
            ResetOptions(newOptions);

            options.AddRange(newOptions.ToTMP_DropdownOptionData());
        }
    }
}
#endif