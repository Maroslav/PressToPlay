using System.Collections;
using System.IO;
using UnityEngine;
using Assets.Code.PressEvents;
using UnityEngine.Assertions;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class CutsceneProcessor : MonoBehaviour
{
    private CutsceneEvent _event;

    public GameObject BackgroundDarkener;
    public GameObject ToggledParent;

    public string ResourceFolder = "/Cutscenes";
    public float FinishTransitionDuration;


    private void OnValidate()
    {
        Assert.IsNotNull(BackgroundDarkener, name);
        Assert.IsNotNull(BackgroundDarkener.GetComponent<Image>(), name);
        Assert.IsNotNull(ToggledParent, name);
    }

    public void ProcessEvent(CutsceneEvent e)
    {
        ToggledParent.SetActive(true);
        BackgroundDarkener.GetComponent<CanvasRenderer>().SetAlpha(0);
        BackgroundDarkener.GetComponent<Image>().CrossFadeAlpha(.85f, 1, false);
        _event = e;

        string path = Path.Combine(ResourceFolder, e.ImagePath).Replace('\\', '/');
        Debug.Log("Loading a cutscene from: " + path);
        var texture = Resources.Load<Texture>(path);
        var image = GetComponent<RawImage>();
        image.texture = texture;
    }

    public void OnClick()
    {
        StartCoroutine(TransitionToFinish());
    }

    IEnumerator TransitionToFinish()
    {
        BackgroundDarkener.GetComponent<Image>().CrossFadeAlpha(0, FinishTransitionDuration, false);
        yield return new WaitForSeconds(FinishTransitionDuration);

        ToggledParent.SetActive(false);
        Debug.Log("Destroying cutscene");
        _event.Finish();
    }
}
