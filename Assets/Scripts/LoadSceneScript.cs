using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class LoadSceneScript : MonoBehaviour
    {
        public string SceneName;

        public void LoadScene()
        {
            Debug.Log("Loading scene: " + SceneName);
            SceneManager.LoadScene(SceneName);
        }
    }
}
