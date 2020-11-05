using UnityEngine;
using UnityEngine.UI;

namespace UISettings
{
    [RequireComponent(typeof(Selectable))]
    [AddComponentMenu("UI/Settings/SettingsSelectable")]
    public class SettingsSelectable : MonoBehaviour
    {
        private Selectable _selectable;
        public Selectable selectable => _selectable ? _selectable : (_selectable = GetComponent<Selectable>());

        [SerializeReference] public ISelectableSetting setting;

        protected virtual void OnEnable()
        {
            setting.UpdateView(selectable);
        }

        protected virtual void OnValidate()
        {
            if(isActiveAndEnabled && !Application.IsPlaying(gameObject))
            {
                setting.UpdateView(selectable);
            }
        }
    }
}

