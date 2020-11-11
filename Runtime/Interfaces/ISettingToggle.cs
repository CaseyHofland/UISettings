using UnityEngine.UI;

namespace UISettings
{
    public interface ISettingToggle : ISettingSelectable
    {
        void UpdateView(Toggle toggle);
        void ValueChanged(bool value);
    }
}
