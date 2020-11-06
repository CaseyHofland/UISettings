using UnityEngine.UI;

namespace UISettings
{
    public interface ISliderSetting : ISelectableSetting
    {
        void UpdateView(Slider slider);
        void ValueChanged(float value);
    }
}

