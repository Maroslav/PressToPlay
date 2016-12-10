using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class SwitchSceneScript
            : MonoBehaviour
    {
        public void LoadScene(SceneAsset scene)
        {
            Debug.Log("Loading scene: " + scene);
            SceneManager.LoadScene(scene.name);
        }

        public void ExitGame()
        {
            Debug.Log("Exiting...");
            Application.Quit();
        }
    }
}
