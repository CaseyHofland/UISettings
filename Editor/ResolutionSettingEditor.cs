using UnityEditor;

namespace UISettings.Editor
{
    [CustomEditor(typeof(ResolutionSetting))]
    [CanEditMultipleObjects]
    public class ResolutionSettingEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EditorGUILayout.HelpBox("Note that Resolution isn't updated in the Game View, only in builds.", MessageType.Info, true);
        }
    }
}

