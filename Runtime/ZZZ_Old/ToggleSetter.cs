using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UISettings
{
    [RequireComponent(typeof(Toggle))]
    public class ToggleSetter : MonoBehaviour
    {
        private Toggle _toggle;
        public Toggle toggle => _toggle ? _toggle : (_toggle = GetComponent<Toggle>());

        [SerializeReference] public ToggleSetting toggleSetting;

        protected virtual void OnEnable()
        {
            toggle.onValueChanged.AddListener(toggleSetting.ValueChanged);
            toggleSetting.UpdateView(toggle);
        }

        protected virtual void OnDisable()
        {
            toggle.onValueChanged.RemoveListener(toggleSetting.ValueChanged);
        }

        protected virtual void OnValidate()
        {
            if(isActiveAndEnabled && !Application.IsPlaying(gameObject))
            {
                toggleSetting.UpdateView(toggle);
            }
        }
    }
}
