using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UISettings;
using UnityEngine.UI;

[UISetting("Shadows")]
public class ShadowsToggleSetting : Setting, IToggleSetting
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
    }
}
