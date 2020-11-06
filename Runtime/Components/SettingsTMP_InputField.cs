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
        public ITMP_InputFieldSetting tmp_InputFieldSetting => (ITMP_InputFieldSetting)setting;

        protected virtual void OnEnable()
        {
            if(tmp_InputFieldSetting != null)
            {
                tmp_InputField.onValueChanged.AddListener(tmp_InputFieldSetting.ValueChanged);
                tmp_InputField.onEndEdit.AddListener(tmp_InputFieldSetting.EndEdit);
                tmp_InputField.onSelect.AddListener(tmp_InputFieldSetting.Select);
                tmp_InputField.onDeselect.AddListener(tmp_InputFieldSetting.Deselect);
            }
        }

        protected virtual void OnDisable()
        {
            if(tmp_InputFieldSetting != null)
            {
                tmp_InputField.onValueChanged.RemoveListener(tmp_InputFieldSetting.ValueChanged);
                tmp_InputField.onEndEdit.RemoveListener(tmp_InputFieldSetting.EndEdit);
                tmp_InputField.onSelect.RemoveListener(tmp_InputFieldSetting.Select);
                tmp_InputField.onDeselect.RemoveListener(tmp_InputFieldSetting.Deselect);
            }
        }

        protected override void LateUpdate()
        {
            base.LateUpdate();
            tmp_InputFieldSetting?.UpdateView(tmp_InputField);
        }
    }
}
#endif