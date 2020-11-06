using UnityEngine.UI;

namespace UISettings
{
    public interface IScrollbarSetting : ISelectableSetting
    {
        void UpdateView(Scrollbar scrollbar);
        void ValueChanged(float value);
    }
}

