#if TMP
using System.Collections.Generic;

namespace UISettings
{
    public interface ISettingTMP_Dropdown : ISettingSelectable
    {
        void UpdateView(TMPro.TMP_Dropdown tmp_Dropdown);
        void ResetOptions(List<TMPro.TMP_Dropdown.OptionData> options);
        void ValueChanged(int value);
    }
}
#endif