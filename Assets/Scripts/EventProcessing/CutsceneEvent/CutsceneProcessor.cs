using System.Collections;
using System.IO;
using Assets.Code.Gameplay;
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
    public GameObject AudioPlayer;

    public string ResourceFolder = "/Cutscenes";
    public float FinishTransitionDuration;


    private void OnValidate()
    {
        Assert.IsNotNull(BackgroundDarkener, name);
        Assert.IsNotNull(BackgroundDarkener.GetComponent<Image>(), name);
        Assert.IsNotNull(ToggledParent, name);
        Assert.IsNotNull(AudioPlayer, name);
        Assert.IsNotNull(AudioPlayer.GetComponent<AudioSource>(), name);
    }


    public void ProcessEvent(CutsceneEvent e)
    {
        ToggledParent.SetActive(true);
        BackgroundDarkener.GetComponent<CanvasRenderer>().SetAlpha(0);
        BackgroundDarkener.GetComponent<Image>().CrossFadeAlpha(.85f, 1, false);
        _event = e;
        PlaySound(e);
        string path = Path.Combine(ResourceFolder, e.ImagePath).Replace('\\', '/');
        Debug.Log("Loading a cutscene from: " + path);
        var texture = Resources.Load<Texture>(path);
        var image = GetComponent<RawImage>();
        image.texture = texture;
        GetComponent<AspectRatioFitter>().aspectRatio = texture.width / (float)texture.height;
    }

    private void PlaySound(PressEvent e)
    {
        if (string.IsNullOrEmpty(e.SoundPath)) return;
        string path = Path.Combine(Constants.SoundsResFolder, e.SoundPath).Replace('\\', '/');
        var audioSource = AudioPlayer.GetComponent<AudioSource>();
        var ac = Resources.Load(path) as AudioClip;
        Debug.Assert(ac!=null, "Wrong sound name.");
        if (ac == null)           
            return;
        audioSource.PlayOneShot(ac);
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
        AudioPlayer.GetComponent<AudioSource>().Stop();
    }
}
