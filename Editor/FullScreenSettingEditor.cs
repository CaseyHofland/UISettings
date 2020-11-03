using UnityEditor;

namespace UISettings.Editor
{
    [CustomEditor(typeof(FullScreenSetting))]
    [CanEditMultipleObjects]
    public class FullScreenSettingEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EditorGUILayout.HelpBox("Note that FullScreen isn't updated in the Game View, only in builds.", MessageType.Info, true);
        }
    }
}
