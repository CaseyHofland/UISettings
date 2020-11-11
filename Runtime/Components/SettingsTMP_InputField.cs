#if TMP
using TMPro;
using UnityEngine;

namespace UISettings
{
    [RequireComponent(typeof(TMP_InputField))]
    [AddComponentMenu("UI/Settings/SettingsTMP_Dropdown")]
    public class SettingsTMP_InputField : SettingsSelectable
    {
        public TMP_InputField tmp_InputField => (TMP_InputField)selectable;
        public ISettingTMP_InputField settingTMP_InputField => (ISettingTMP_InputField)setting;

        protected virtual void OnEnable()
        {
            if(settingTMP_InputField != null)
            {
                tmp_InputField.onValueChanged.AddListener(settingTMP_InputField.ValueChanged);
                tmp_InputField.onEndEdit.AddListener(settingTMP_InputField.EndEdit);
                tmp_InputField.onSelect.AddListener(settingTMP_InputField.Select);
                tmp_InputField.onDeselect.AddListener(settingTMP_InputField.Deselect);
            }
        }

        protected virtual void OnDisable()
        {
            if(settingTMP_InputField != null)
            {
                tmp_InputField.onValueChanged.RemoveListener(settingTMP_InputField.ValueChanged);
                tmp_InputField.onEndEdit.RemoveListener(settingTMP_InputField.EndEdit);
                tmp_InputField.onSelect.RemoveListener(settingTMP_InputField.Select);
                tmp_InputField.onDeselect.RemoveListener(settingTMP_InputField.Deselect);
            }
        }

        protected override void LateUpdate()
        {
            base.LateUpdate();
            settingTMP_InputField?.UpdateView(tmp_InputField);
        }
    }
}
#endif