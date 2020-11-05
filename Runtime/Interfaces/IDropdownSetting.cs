using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UISettings
{
    public interface IDropdownSetting : ISelectableSetting
    {
        void UpdateView(Dropdown dropdown);
        void ValueChanged(int value);
    }
}
