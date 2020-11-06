#if TMP
using System.Collections.Generic;
using TMPro;
using UISettings;
using UnityEngine;

public class ShadowsTMP_DropdownSetting : ShadowsDropdownSetting, ITMP_DropdownSetting
{
    public void UpdateView(TMP_Dropdown tmp_dropdown)
    {
        tmp_dropdown.ClearOptions();

        var options = new List<string>()
        {
            nameof(ShadowQuality.Disable),
            nameof(ShadowQuality.HardOnly),
            nameof(ShadowQuality.All),
        };

        var value = (int)QualitySettings.shadows;
        if(reverse)
        {
            options.Reverse();
            value = 2 - value;
        }

        tmp_dropdown.AddOptions(options);

        tmp_dropdown.SetValueWithoutNotify(value);
    }
}
#endif