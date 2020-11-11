using UnityEditor;
using UnityEngine;

namespace UISettings.Editor
{
    [CustomEditor(typeof(SettingsDropdown), true)]
    public class SettingsDropdownEditor : SettingsSelectableEditor
    {
        protected override void OnEnable()
        {
            setting = serializedObject.FindProperty(nameof(setting));
            var settingReference = setting.objectReferenceValue;

            base.OnEnable();

            if(settingReference != setting.objectReferenceValue)
            {
                ((SettingsDropdown)target).ResetOptions();
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
                ((SettingsDropdown)target).ResetOptions();
                EditorUtility.SetDirty(target);
            }
            EditorGUILayout.EndHorizontal();
        }
    }
}

