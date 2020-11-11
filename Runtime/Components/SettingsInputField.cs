using UnityEngine;
using UnityEngine.UI;

namespace UISettings
{
    [RequireComponent(typeof(InputField))]
    [AddComponentMenu("UI/Settings/SettingsInputField")]
    public class SettingsInputField : SettingsSelectable
    {
        public InputField inputField => (InputField)selectable;
        public ISettingInputField settingInputField => (ISettingInputField)setting;

        protected virtual void OnEnable()
        {
            if(settingInputField != null)
            {
                inputField.onValueChanged.AddListener(settingInputField.ValueChanged);
                inputField.onEndEdit.AddListener(settingInputField.EndEdit);
            }
        }

        protected virtual void OnDisable()
        {
            if(settingInputField != null)
            {
                inputField.onValueChanged.RemoveListener(settingInputField.ValueChanged);
                inputField.onEndEdit.RemoveListener(settingInputField.EndEdit);
            }
        }

        protected override void LateUpdate()
        {
            base.LateUpdate();
            settingInputField?.UpdateView(inputField);
        }
    }
}

