using System;
using UnityEngine;
using UnityEngine.UI;

namespace UISettings
{
    [UISetting("VSync")]
    public class VSyncSetting : IToggleSetting
    {
        [Range(1, 4)] public int vSyncCount = 1;

        public void UpdateView(Toggle toggle)
        {
            toggle.SetIsOnWithoutNotify(QualitySettings.vSyncCount > 0);

            UpdateView((Selectable)toggle);
        }

        public void UpdateView(Selectable selectable) { }

        public void ValueChanged(bool value)
        {
            QualitySettings.vSyncCount = value ? vSyncCount : 0;
        }
    }
}

