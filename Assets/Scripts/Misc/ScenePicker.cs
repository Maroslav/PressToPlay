using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Misc
{
    /// <summary>
    ///ScenePicker content can be selected from within the Unity GUI Editor using a special editor
    /// Copied from:
    /// https://docs.unity3d.com/ScriptReference/SceneAsset.html
    /// 
    /// </summary>
    public class ScenePicker : MonoBehaviour
    {
        [SerializeField]
        public string scenePath;
        [SerializeField]
        public string sceneName;
        /// <summary>
        /// Plays the scene that is set in the scenePath property.
        /// </summary>
        public void LoadScene()
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
