using Assets.Scripts.Misc;
using UnityEditor;

//Editor that enables selection of the scene in Unity GUI Editor.
//Copied from the unity documentation:
//https://docs.unity3d.com/ScriptReference/SceneAsset.html
namespace Assets.Editor.Scripts
{
    [CustomEditor(typeof(ScenePicker), true)]
    public class ScenePickerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            var picker = target as ScenePicker;
            var oldScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(picker.scenePath);

            serializedObject.Update();

            EditorGUI.BeginChangeCheck();
            var newScene = EditorGUILayout.ObjectField("scene", oldScene, typeof(SceneAsset), false) as SceneAsset;

            if (EditorGUI.EndChangeCheck())
            {
                var newPath = AssetDatabase.GetAssetPath(newScene);
                var scenePathProperty = serializedObject.FindProperty("scenePath");
                scenePathProperty.stringValue = newPath;
                var sceneNameProperty = serializedObject.FindProperty("sceneName");
                sceneNameProperty.stringValue = newScene.name;
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
}