using UnityEngine.UI;

namespace UISettings
{
    public interface IToggleSetting : ISelectableSetting
    {
        void UpdateView(Toggle toggle);
        void ValueChanged(bool value);
    }
}
