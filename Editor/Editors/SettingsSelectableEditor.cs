using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace UISettings.Editor
{
    [CustomEditor(typeof(SettingsSelectable), true)]
    public class SettingsSelectableEditor : UnityEditor.Editor
    {
        private SerializedProperty setting;
        private UnityEditor.Editor settingEditor;

        private static Type[] subTypes;
        private static string[] subTypeDisplayedOptions;
        private int index;

        private void OnEnable()
        {
            setting = serializedObject.FindProperty(nameof(setting));

            var selectable = typeof(SettingsSelectable).GetProperty("selectable").GetValue(target);
            Type iSettingType;
            switch(selectable)
            {
#if TMP
                case TMPro.TMP_InputField _:
                    iSettingType = typeof(ITMP_InputFieldSetting);
                    break;
                case TMPro.TMP_Dropdown _:
                    iSettingType = typeof(ITMP_DropdownSetting);
                    break;
#endif
                case InputField _:
                    iSettingType = typeof(IInputFieldSetting);
                    break;
                case Scrollbar _:
                    iSettingType = typeof(IScrollbarSetting);
                    break;
                case Dropdown _:
                    iSettingType = typeof(IDropdownSetting);
                    break;
                case Slider _:
                    iSettingType = typeof(ISliderSetting);
                    break;
                case Toggle _:
                    iSettingType = typeof(IToggleSetting);
                    break;
                case Button _:
                    iSettingType = typeof(IButtonSetting);
                    break;
                case Selectable _:
                    iSettingType = typeof(ISelectableSetting);
                    break;
                default:
                    iSettingType = null;
                    break;
            }

            var libraryPath = Application.dataPath.Remove(Application.dataPath.LastIndexOf('/') + 1).Replace('/', '\\') + "Library";
            subTypes = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                            where assembly.Location.StartsWith(libraryPath)
                            from type in assembly.GetTypes()
                            where iSettingType.IsAssignableFrom(type)
                            where type.IsSubclassOf(typeof(Setting))
                            where Attribute.IsDefined(type, typeof(UISettingAttribute))
                            select type).ToArray();
            subTypeDisplayedOptions = Array.ConvertAll(subTypes, subType => subType.GetCustomAttribute<UISettingAttribute>().GetName());
            index = -1;

            if(setting.objectReferenceValue)
            {
                index = Array.IndexOf(subTypeDisplayedOptions, setting.objectReferenceValue.GetType().GetCustomAttribute<UISettingAttribute>().GetName());
            }

            if(index == -1 && subTypes.Length > 0)
            {
                index = 0;
                setting.objectReferenceValue = CreateInstance(subTypes[index]);
                serializedObject.ApplyModifiedProperties();
            }

            settingEditor = CreateEditor(setting.objectReferenceValue);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUI.BeginChangeCheck();
            index = EditorGUILayout.Popup("Setting", index, subTypeDisplayedOptions);
            if(EditorGUI.EndChangeCheck())
            {
                Undo.DestroyObjectImmediate(setting.objectReferenceValue);
                setting.objectReferenceValue = CreateInstance(subTypes[index]);
                settingEditor = CreateEditor(setting.objectReferenceValue);

                //var undoGroup = Undo.GetCurrentGroupName();
                //UnityEngine.Debug.Log(Undo.GetCurrentGroupName());

                //Undo.RecordObject(settingEditor, undoGroup);
                //setting.objectReferenceValue = CreateInstance(subTypes[index]);

                //Undo.IncrementCurrentGroup();
                //settingEditor = CreateEditor(setting.objectReferenceValue);
                //Undo.RevertAllInCurrentGroup();

                //Undo.ClearUndo(settingEditor);
                //Undo.RegisterCreatedObjectUndo(settingEditor, undoGroup);
            }

            settingEditor.OnInspectorGUI();

            serializedObject.ApplyModifiedProperties();
        }
    }
}

