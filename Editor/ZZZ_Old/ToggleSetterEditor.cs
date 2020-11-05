using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Reflection;

namespace UISettings.Editor
{
    [CustomEditor(typeof(ToggleSetter), true)]
    public class ToggleSetterEditor : UnityEditor.Editor
    {
        private SerializedProperty toggleSetting;
        private static string[] subTypeDisplayedOptions;

        private void Awake()
        {
            var baseType = typeof(ToggleSetting);
            var assembly = baseType.Assembly;
            var subTypes = Array.FindAll(assembly.GetTypes(), type => type.IsSubclassOf(baseType));

            var assemblyName = assembly.GetName().Name;
            //var subTypeIndex = Array.FindIndex(subTypes, subType => $"{assemblyName} {subType.FullName}" == toggleSetting.managedReferenceFullTypename);

            Array.Sort(subTypes, (subType, next) => subType.GetCustomAttribute<UINameAttribute>().order - next.GetCustomAttribute<UINameAttribute>().order);
            subTypeDisplayedOptions = Array.ConvertAll(subTypes, subType => subType.GetCustomAttribute<UINameAttribute>().name);
        }

        private void OnEnable()
        {
            toggleSetting = serializedObject.FindProperty(nameof(toggleSetting));
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            var index = EditorGUILayout.Popup("Setting", 0, subTypeDisplayedOptions);

            //var newSubTypeIndex = EditorGUILayout.Popup("Setting", subTypeIndex, Array.ConvertAll(subTypes, subType => subType.Name));
            //if(newSubTypeIndex != subTypeIndex)
            //{
            //    toggleSetting.managedReferenceValue = Activator.CreateInstance(subTypes[newSubTypeIndex]);
            //}

            //EditorGUILayout.PropertyField(toggleSetting, true);

            //Debug.Log($"Current Type: {toggleSetting.managedReferenceFullTypename}");
            //Debug.Log($"Sub Type: {baseType.Assembly.GetName().Name} {subTypes[0].FullName}");

            serializedObject.ApplyModifiedProperties();
        }
    }
}

