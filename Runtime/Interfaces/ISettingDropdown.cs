using System.Collections.Generic;
using UnityEngine.UI;

namespace UISettings
{
    public interface ISettingDropdown : ISettingSelectable
    {
        void UpdateView(Dropdown dropdown);
        void ResetOptions(List<Dropdown.OptionData> options);
        void ValueChanged(int value);
    }
}
