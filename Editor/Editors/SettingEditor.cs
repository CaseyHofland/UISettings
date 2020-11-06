using UnityEditor;

namespace UISettings.Editor
{
    [CustomEditor(typeof(Setting), true)]
    [CanEditMultipleObjects]
    public class SettingEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            var property = serializedObject.GetIterator();
            if(property.NextVisible(true))
            {
                while(property.NextVisible(false))
                {
                    EditorGUILayout.PropertyField(property, true);
                }
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}

