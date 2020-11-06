using UnityEngine;
using UnityEngine.UI;

namespace UISettings
{
    [RequireComponent(typeof(InputField))]
    [AddComponentMenu("UI/Settings/SettingsInputField")]
    public class SettingsInputField : SettingsSelectable
    {
        public InputField inputField => (InputField)selectable;
        public IInputFieldSetting inputFieldSetting => (IInputFieldSetting)setting;

        protected virtual void OnEnable()
        {
            if(inputFieldSetting != null)
            {
                inputField.onValueChanged.AddListener(inputFieldSetting.ValueChanged);
                inputField.onEndEdit.AddListener(inputFieldSetting.EndEdit);
            }
        }

        protected virtual void OnDisable()
        {
            if(inputFieldSetting != null)
            {
                inputField.onValueChanged.RemoveListener(inputFieldSetting.ValueChanged);
                inputField.onEndEdit.RemoveListener(inputFieldSetting.EndEdit);
            }
        }

        protected override void LateUpdate()
        {
            base.LateUpdate();
            inputFieldSetting?.UpdateView(inputField);
        }
    }
}

