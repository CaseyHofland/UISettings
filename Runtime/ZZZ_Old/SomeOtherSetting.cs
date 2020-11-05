using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UISettings
{
    [UIName("Something/Some Other", order = 10)]
    public class SomeOtherSetting : ToggleSetting
    {
        public override void UpdateView(Toggle toggle)
        {
        }

        protected internal override void ValueChanged(bool value)
        {
        }
    }
}

