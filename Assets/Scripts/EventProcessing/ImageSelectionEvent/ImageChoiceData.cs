using UnityEngine;
using Assets.Code.GameState;
using Assets.Code.PressEvents;
using Assets.Code.PressEvents.Choices;
using UnityEngine.Assertions;
using UnityEngine.UI;

/// <summary>
/// Used in ImageChoice button prefab
/// </summary>
public class ImageChoiceData : MonoBehaviour
{
    public GameObject ImageButton;
    public GameObject ImageMargin;

    void OnValidate()
    {
        Assert.IsNotNull(ImageButton);
        Assert.IsNotNull(ImageButton.GetComponent<Image>());

        Assert.IsNotNull(ImageMargin);
        Assert.IsNotNull(ImageMargin.GetComponent<AspectRatioFitter>());
    }

    private ImageChoice _choice;
    private ImageChoiceEventProcessor _owner;

    public void SetEvent(ImageChoice choice, ImageChoiceEventProcessor viewProcessor)
    {
        _choice = choice;
        _owner = viewProcessor;
    }

    public void OnClick()
    {
        _owner.ProcessChoice(_choice);
    }
}
