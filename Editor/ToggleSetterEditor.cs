using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

namespace UISettings.Editor
{
    [CustomEditor(typeof(ToggleSetter), true)]
    public class ToggleSetterEditor : UnityEditor.Editor
    {
        private SerializedProperty toggleSetting;

        private void OnEnable()
        {
            toggleSetting = serializedObject.FindProperty(nameof(toggleSetting));
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            var baseType = typeof(ToggleSetting);
            var assembly = baseType.Assembly;
            var subTypes = Array.FindAll(assembly.GetTypes(), type => type.IsSubclassOf(baseType));

            var subTypeIndex = Array.FindIndex(subTypes, subType => $"{assembly.GetName().Name} {subType.FullName}" == toggleSetting.managedReferenceFullTypename);
            var newSubTypeIndex = EditorGUILayout.Popup("Toggle Setting:", subTypeIndex, Array.ConvertAll(subTypes, subType => subType.Name));
            if(newSubTypeIndex != subTypeIndex)
            {
                toggleSetting.managedReferenceValue = Activator.CreateInstance(subTypes[newSubTypeIndex]);
            }

            EditorGUILayout.PropertyField(toggleSetting, true);

            //Debug.Log($"Current Type: {toggleSetting.managedReferenceFullTypename}");
            //Debug.Log($"Sub Type: {baseType.Assembly.GetName().Name} {subTypes[0].FullName}");

            serializedObject.ApplyModifiedProperties();
        }
    }
}

