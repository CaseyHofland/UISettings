using System;
using UnityEngine;
using UnityEngine.UI;

namespace UISettings
{
    public class VSyncSetting : ToggleSetting
    {
        public bool something = true;

        public override void UpdateView(Toggle toggle)
        {
            toggle.SetIsOnWithoutNotify(QualitySettings.vSyncCount > 0);

            Debug.Log("VSynced");
        }

        protected internal override void ValueChanged(bool value)
        {
            QualitySettings.vSyncCount = value ? 1 : 0;
        }
    }
}
