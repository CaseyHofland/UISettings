using System;
using UnityEditor;
using UnityEngine.Audio;

namespace UISettings.Editor
{
    [CustomEditor(typeof(AudioSetting))]
    [CanEditMultipleObjects]
    public class AudioSettingEditor : UnityEditor.Editor
    {
        private SerializedProperty slider;
        private SerializedProperty audioMixer;
        private SerializedProperty exposedParameter;
        private SerializedProperty minValue;
        private SerializedProperty maxValue;

        private void OnEnable()
        {
            slider = serializedObject.FindProperty(nameof(slider));
            audioMixer = serializedObject.FindProperty(nameof(audioMixer));
            exposedParameter = serializedObject.FindProperty(nameof(exposedParameter));
            minValue = serializedObject.FindProperty(nameof(minValue));
            maxValue = serializedObject.FindProperty(nameof(maxValue));
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(slider);
            EditorGUILayout.PropertyField(audioMixer);
            if(audioMixer.objectReferenceValue != null)
            {
                var audioMixer = (AudioMixer)this.audioMixer.objectReferenceValue;

                // Exposed Parameters Popup
                var parameters = (Array)audioMixer.GetType().GetProperty("exposedParameters").GetValue(audioMixer);
                var names = new string[parameters.Length];
                for(int i = 0; i < parameters.Length; i++)
                {
                    var parameter = parameters.GetValue(i);
                    names[i] = (string)parameter.GetType().GetField("name").GetValue(parameter);
                }

                if(names.Length > 0)
                {
                    var index = Math.Max(Array.IndexOf(names, exposedParameter.stringValue), 0);
                    index = EditorGUILayout.Popup("Parameter", index, names);
                    exposedParameter.stringValue = names[index];

                    // Min Max Values
                    EditorGUILayout.PropertyField(minValue);
                    EditorGUILayout.PropertyField(maxValue);
                }
                else
                {
                    EditorGUILayout.HelpBox("The AudioMixer doesn't have any exposed parameters on it.", MessageType.Warning, true);
                }
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
