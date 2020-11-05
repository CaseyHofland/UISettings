using System;
using System.Runtime.CompilerServices;
using UnityEngine.UI;

namespace UISettings
{
    [Serializable]
    public abstract class ToggleSetting
    {
        public abstract void UpdateView(Toggle toggle);
        internal protected abstract void ValueChanged(bool value);
    }
}
