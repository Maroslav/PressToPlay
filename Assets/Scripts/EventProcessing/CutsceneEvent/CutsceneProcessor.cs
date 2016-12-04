using System.IO;
using UnityEngine;
using Assets.Code.PressEvents;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class CutsceneProcessor : MonoBehaviour
{
    private CutsceneEvent _event;

    public string ResourceFolder = "/Cutscenes";


    public void ProcessEvent(CutsceneEvent e)
    {
        gameObject.transform.parent.gameObject.SetActive(true);
        _event = e;

        string path = Path.Combine(ResourceFolder, e.ImagePath).Replace('\\', '/');
        Debug.Log("Loading a cutscene from: " + path);
        var texture = Resources.Load<Texture>(path);
        GetComponent<RawImage>().texture = texture;
    }

    public void OnClick()
    {
        gameObject.transform.parent.gameObject.SetActive(false);

        Debug.Log("Destroying cutscene");
        _event.Finish();
    }
}
