using UnityEngine.UI;

namespace UISettings
{
    public interface ISettingSlider : ISettingSelectable
    {
        void UpdateView(Slider slider);
        void ValueChanged(float value);
    }
}

