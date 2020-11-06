using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UISettings
{
    public interface IButtonSetting : ISelectableSetting
    {
        void UpdateView(Button button);
        void Clicked();
    }
}

