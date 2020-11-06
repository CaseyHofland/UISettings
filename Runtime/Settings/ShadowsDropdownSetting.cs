using System.Collections.Generic;
using UISettings;
using UnityEngine;
using UnityEngine.UI;

[UISetting("Shadows")]
public class ShadowsDropdownSetting : Setting, IDropdownSetting
{
    public bool reverse = false;

    public void UpdateView(Dropdown dropdown)
    {
        dropdown.ClearOptions();

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

        dropdown.AddOptions(options);

        dropdown.SetValueWithoutNotify(value);
    }

    public void ValueChanged(int value)
    {
        if(reverse)
        {
            value = 2 - value;
        }

        QualitySettings.shadows = (ShadowQuality)value;
    }
}
