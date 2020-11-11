#if TMP
using TMPro;
using UnityEngine;

namespace UISettings
{
    [RequireComponent(typeof(TMP_Dropdown))]
    [AddComponentMenu("UI/Settings/SettingsTMP_Dropdown")]
    public class SettingsTMP_Dropdown : SettingsSelectable
    {
        public TMP_Dropdown tmp_Dropdown => (TMP_Dropdown)selectable;
        public ISettingTMP_Dropdown settingTMP_Dropdown => (ISettingTMP_Dropdown)setting;

        protected virtual void OnEnable()
        {
            if(settingTMP_Dropdown != null)
            {
                tmp_Dropdown.onValueChanged.AddListener(settingTMP_Dropdown.ValueChanged);
            }
        }

        protected virtual void OnDisable()
        {
            if(settingTMP_Dropdown != null)
            {
                tmp_Dropdown.onValueChanged.RemoveListener(settingTMP_Dropdown.ValueChanged);
            }
        }

        protected override void LateUpdate()
        {
            base.LateUpdate();
            settingTMP_Dropdown?.UpdateView(tmp_Dropdown);
        }

        public void ResetOptions()
        {
            settingTMP_Dropdown.ResetOptions(tmp_Dropdown.options);
        }
    }
}
#endif