using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UISettings
{
    public abstract class Setting : ScriptableObject, ISelectableSetting
    {
        public virtual void UpdateView(Selectable selectable) { }
    }
}
