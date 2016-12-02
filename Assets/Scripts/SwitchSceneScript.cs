using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class SwitchSceneScript
            : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            Debug.Log("Loading scene: " + sceneName);
            SceneManager.LoadScene(sceneName);
        }

        public void ExitGame()
        {
            Debug.Log("Exiting...");
            Application.Quit();
        }
    }
}
