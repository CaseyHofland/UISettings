using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UISettings
{
    [UIName("Something/Some", order = 12)]
    public class SomeSetting : ToggleSetting
    {
        public override void UpdateView(Toggle toggle)
        {
            //throw new System.NotImplementedException();
        }

        protected internal override void ValueChanged(bool value)
        {
            //throw new System.NotImplementedException();
        }
    }
}

