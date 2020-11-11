#if TMP
using UnityEditor;
using UnityEngine;

namespace UISettings.Editor
{
    [CustomEditor(typeof(SettingsTMP_Dropdown), true)]
    public class SettingsTMP_DropdownEditor : SettingsSelectableEditor
    {
        protected override void OnEnable()
        {
            setting = serializedObject.FindProperty(nameof(setting));
            var settingReference = setting.objectReferenceValue;

            base.OnEnable();

            if(settingReference != setting.objectReferenceValue)
            {
                ((SettingsTMP_Dropdown)target).ResetOptions();
                EditorUtility.SetDirty(target);
            }
        }

        public override void OnInspectorGUI()
        {
            var settingReference = setting.objectReferenceValue;

            base.OnInspectorGUI();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel(" ");
            if(GUILayout.Button("Reset Options") || settingReference != setting.objectReferenceValue)
            {
                ((SettingsTMP_Dropdown)target).ResetOptions();
                EditorUtility.SetDirty(target);
            }
            EditorGUILayout.EndHorizontal();
        }
    }
}
#endif