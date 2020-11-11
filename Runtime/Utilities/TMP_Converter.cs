#if TMP
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

namespace UISettings
{
    public static class TMP_Converter
    {
        public static List<Dropdown.OptionData> ToDropdownOptionData(this List<TMP_Dropdown.OptionData> options)
        {
            return options.ConvertAll(option => new Dropdown.OptionData(option.text, option.image));
        }

        public static List<TMP_Dropdown.OptionData> ToTMP_DropdownOptionData(this List<Dropdown.OptionData> options)
        {
            return options.ConvertAll(option => new TMP_Dropdown.OptionData(option.text, option.image));
        }
    }
}
#endif