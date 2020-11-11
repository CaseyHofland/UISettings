using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UISettings
{
    public class ShadowsSettingDropdown : ShadowsSetting, ISettingDropdown
    {
        public bool reverse = false;

        public void UpdateView(Dropdown dropdown)
        {
            var value = (int)QualitySettings.shadows;
            if(reverse)
            {
                value = 2 - value;
            }
            dropdown.SetValueWithoutNotify(value);
            dropdown.RefreshShownValue();
        }

        public void ResetOptions(List<Dropdown.OptionData> options)
        {
            options.Clear();

            var optionNames = new List<string>()
            {
                ShadowQuality.Disable.ToString(),
                ShadowQuality.HardOnly.ToString(),
                ShadowQuality.All.ToString(),
            };

            if(reverse)
            {
                optionNames.Reverse();
            }

            options.AddRange(optionNames.ConvertAll(optionName => new Dropdown.OptionData(optionName)));
        }

        public void ValueChanged(int value)
        {
            if(reverse)
            {
                value = 2 - value;
            }

            QualitySettings.shadows = (ShadowQuality)value;
            Save();
        }
    }
}