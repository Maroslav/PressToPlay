using Assets.Scripts.Misc;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class SwitchSceneScript
            : MonoBehaviour
    {
        public void LoadScene(ScenePicker scene)
        {
            Debug.Log("Loading scene: " + scene.scenePath);
            SceneManager.LoadScene(scene.scenePath);
        }

        public void ExitGame()
        {
            Debug.Log("Exiting...");
            Application.Quit();
        }
    }
}
