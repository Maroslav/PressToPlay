using System.IO;
using UnityEngine;
using Assets.Code.PressEvents;
using UnityEngine.Assertions;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class CutsceneProcessor : MonoBehaviour
{
    private CutsceneEvent _event;

    public GameObject ToggledParent;
    public string ResourceFolder = "/Cutscenes";


    private void OnValidate()
    {
        Assert.IsNotNull(ToggledParent);
    }

    public void ProcessEvent(CutsceneEvent e)
    {
        gameObject.transform.parent.parent.gameObject.SetActive(true);
        _event = e;

        string path = Path.Combine(ResourceFolder, e.ImagePath).Replace('\\', '/');
        Debug.Log("Loading a cutscene from: " + path);
        var texture = Resources.Load<Texture>(path);
        var image = GetComponent<RawImage>();
        image.texture = texture;
    }

    public void OnClick()
    {
        gameObject.transform.parent.parent.gameObject.SetActive(false);

        Debug.Log("Destroying cutscene");
        _event.Finish();
    }
}
