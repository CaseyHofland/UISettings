using UnityEngine;
using UnityEngine.UI;

namespace UISettings
{
    public class ShadowsSettingToggle : ShadowsSetting, ISettingToggle
    {
        public ShadowQuality onQuality = ShadowQuality.All;
        public ShadowQuality offQuality = ShadowQuality.Disable;

        public void UpdateView(Toggle toggle)
        {
            toggle.SetIsOnWithoutNotify(QualitySettings.shadows == onQuality && QualitySettings.shadows != offQuality);
        }

        public void ValueChanged(bool value)
        {
            QualitySettings.shadows = value ? onQuality : offQuality;
            Save();
        }
    }
}

