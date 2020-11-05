using System;
using UnityEngine.UI;

namespace UISettings
{
    [Serializable]
    public abstract class ToggleSetting
    {
        internal protected abstract void ValueChanged(bool value);
        public abstract void UpdateView(Toggle toggle);
    }
}
