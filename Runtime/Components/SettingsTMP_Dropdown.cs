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

        protected override void OnEnable()
        {
            tmp_Dropdown.onValueChanged.AddListener(tmp_DropdownSetting.ValueChanged);
            tmp_DropdownSetting.UpdateView(tmp_Dropdown);
        }

        protected virtual void OnDisable()
        {
            tmp_Dropdown.onValueChanged.RemoveListener(tmp_DropdownSetting.ValueChanged);
        }

        protected override void OnValidate()
        {
            if(isActiveAndEnabled && !Application.IsPlaying(gameObject))
            {
                tmp_DropdownSetting.UpdateView(tmp_Dropdown);
            }
        }
    }
}
#endif