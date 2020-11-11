using UnityEngine.UI;

namespace UISettings
{
    public interface ISettingScrollbar : ISettingSelectable
    {
        void UpdateView(Scrollbar scrollbar);
        void ValueChanged(float value);
    }
}

