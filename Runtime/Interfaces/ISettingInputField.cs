using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UISettings
{
    public interface ISettingInputField : ISettingSelectable
    {
        void UpdateView(InputField inputField);
        void ValueChanged(string value);
        void EndEdit(string value);
    }
}
