using System;
using System.Reflection;
using UnityEditor;
using UnityEngine.UI;

namespace UISettings.Editor
{
    [CustomEditor(typeof(SettingsSelectable), true)]
    public class SettingsSelectableEditor : UnityEditor.Editor
    {
        private SerializedProperty setting;

        private static Type[] subTypes;
        private static string[] subTypeDisplayedOptions;
        private static int index;

        private void OnEnable()
        {
            setting = serializedObject.FindProperty(nameof(setting));

            var selectable = typeof(SettingsSelectable).GetProperty("selectable").GetValue(target);
            Type iSettingType;
            switch(selectable)
            {
#if TMP
                case TMPro.TMP_Dropdown tmp_d:
                    iSettingType = typeof(ITMP_DropdownSetting);
                    break;
#endif
                case Dropdown d:
                    iSettingType = typeof(IDropdownSetting);
                    break;
                case Selectable s:
                    iSettingType = typeof(ISelectableSetting);
                    break;
                default:
                    iSettingType = null;
                    break;
            }
            subTypes = Array.FindAll(iSettingType.Assembly.GetTypes(), type => iSettingType.IsAssignableFrom(type) && Attribute.IsDefined(type, typeof(UISettingAttribute)));
            subTypeDisplayedOptions = Array.ConvertAll(subTypes, subType => subType.GetCustomAttribute<UISettingAttribute>().GetName());
            index = -1;

            var settingSplitIndex = setting.managedReferenceFullTypename.IndexOf(' ');
            if(settingSplitIndex > -1)
            {
                var settingTypeName = setting.managedReferenceFullTypename.Substring(settingSplitIndex);
                var settingAssemblyName = setting.managedReferenceFullTypename.Substring(0, settingSplitIndex);
                var settingType = Type.GetType($"{settingTypeName}, {settingAssemblyName}");

                if(settingType != null)
                {
                    index = Array.IndexOf(subTypeDisplayedOptions, settingType.GetCustomAttribute<UISettingAttribute>().GetName());
                }
            }

            if(index == -1 && subTypes.Length > 0)
            {
                index = 0;
                setting.managedReferenceValue = Activator.CreateInstance(subTypes[index]);
                serializedObject.ApplyModifiedProperties();
            }
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            // Draw the Setting Picker.
            EditorGUI.BeginChangeCheck();
            index = EditorGUILayout.Popup("Setting", index, subTypeDisplayedOptions);
            if(EditorGUI.EndChangeCheck())
            {
                setting.managedReferenceValue = Activator.CreateInstance(subTypes[index]);
            }

            // Draw the Setting without toggle.
            var settingChild = setting.Copy();
            if(settingChild.NextVisible(true))
            {
                EditorGUILayout.PropertyField(settingChild, true);
                while(settingChild.NextVisible(false))
                {
                    EditorGUILayout.PropertyField(settingChild, true);
                }
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}

