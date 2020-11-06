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
        public ITMP_DropdownSetting tmp_DropdownSetting => (ITMP_DropdownSetting)setting;

        protected virtual void OnEnable()
        {
            if(tmp_DropdownSetting != null)
            {
                tmp_Dropdown.onValueChanged.AddListener(tmp_DropdownSetting.ValueChanged);
            }
        }

        protected virtual void OnDisable()
        {
            if(tmp_DropdownSetting != null)
            {
                tmp_Dropdown.onValueChanged.RemoveListener(tmp_DropdownSetting.ValueChanged);
            }
        }

        protected override void LateUpdate()
        {
            base.LateUpdate();
            tmp_DropdownSetting?.UpdateView(tmp_Dropdown);
        }
    }
}
#endif