#if TMP
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UISettings
{
    public class ShadowsSettingTMP_Dropdown : ShadowsSettingDropdown, ISettingTMP_Dropdown
    {
        public void UpdateView(TMP_Dropdown tmp_dropdown)
        {
            var value = (int)QualitySettings.shadows;
            if(reverse)
            {
                value = 2 - value;
            }
            tmp_dropdown.SetValueWithoutNotify(value);
            tmp_dropdown.RefreshShownValue();
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