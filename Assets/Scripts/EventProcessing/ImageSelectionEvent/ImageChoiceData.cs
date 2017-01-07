using UnityEngine;
using Assets.Code.GameState;
using Assets.Code.PressEvents;
using Assets.Code.PressEvents.Choices;

/// <summary>
/// Used in ImageChoice button prefab
/// </summary>
public class ImageChoiceData : MonoBehaviour
{
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
