using System;
using UnityEditor;
using UnityEngine.Audio;

namespace UISettings.Editor
{
    [CustomEditor(typeof(AudioSetting))]
    [CanEditMultipleObjects]
    public class AudioSettingEditor : UnityEditor.Editor
    {
        private SerializedProperty _selectable;
        private SerializedProperty _audioMixer;
        private SerializedProperty _exposedParameter;
        private SerializedProperty _minValue;
        private SerializedProperty _maxValue;

        private void OnEnable()
        {
            _selectable = serializedObject.FindProperty(nameof(_selectable));
            _audioMixer = serializedObject.FindProperty(nameof(_audioMixer));
            _exposedParameter = serializedObject.FindProperty(nameof(_exposedParameter));
            _minValue = serializedObject.FindProperty(nameof(_minValue));
            _maxValue = serializedObject.FindProperty(nameof(_maxValue));
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_selectable);
            EditorGUILayout.PropertyField(_audioMixer);
            if(_audioMixer.objectReferenceValue != null)
            {
                var audioMixer = (AudioMixer)this._audioMixer.objectReferenceValue;

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
                    var index = Math.Max(Array.IndexOf(names, _exposedParameter.stringValue), 0);
                    index = EditorGUILayout.Popup("Parameter", index, names);
                    _exposedParameter.stringValue = names[index];

                    // Min Max Values
                    EditorGUILayout.PropertyField(_minValue);
                    EditorGUILayout.PropertyField(_maxValue);
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
