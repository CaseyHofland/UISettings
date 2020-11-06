using UnityEngine;
using UnityEngine.UI;

namespace UISettings
{
    [RequireComponent(typeof(Selectable))]
    [ExecuteAlways]
    [AddComponentMenu("UI/Settings/SettingsSelectable")]
    public class SettingsSelectable : MonoBehaviour
    {
        private Selectable _selectable;
        public Selectable selectable => _selectable ? _selectable : (_selectable = GetComponent<Selectable>());

        public Setting setting;

        protected virtual void LateUpdate()
        {
            if(setting)
            {
                setting.UpdateView(selectable);
            }
        }
    }
}

