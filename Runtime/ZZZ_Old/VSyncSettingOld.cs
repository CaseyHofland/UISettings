using System;
using UnityEngine;
using UnityEngine.UI;

namespace UISettings
{
    [UIName("Something/VSync", order = -3)]
    public class VSyncSettingOld : ToggleSetting
    {
        [Range(1, 4)] [SerializeField] private int _vSyncCount = 1;

        public int vSyncCount
        {
            get => _vSyncCount;
            set
            {
                _vSyncCount = value;
                if(QualitySettings.vSyncCount > 0)
                {
                    QualitySettings.vSyncCount = _vSyncCount;
                }
            }
        }

        public override void UpdateView(Toggle toggle)
        {
            toggle.SetIsOnWithoutNotify(QualitySettings.vSyncCount > 0);
        }

        protected internal override void ValueChanged(bool value)
        {
            QualitySettings.vSyncCount = value ? vSyncCount : 0;
        }
    }
}
