using UnityEngine;
using Assets.Code.GameState;
using Assets.Code.PressEvents;
using Assets.Code.PressEvents.Choices;

/// <summary>
/// Used in ImageChoice button prefab
/// </summary>
public class ImageChoiceData : MonoBehaviour
{
    private ImageChoiceEvent _event;
    private ImageChoiceEventProcessor _owner;

    public ImageChoice Choice;


    public void SetEvent(ImageChoiceEvent newEvent, ImageChoiceEventProcessor viewProcessor)
    {
        _event = newEvent;
        _owner = viewProcessor;
    }

    public void OnClick()
    {
        _owner.MoveToNextState(Choice);

        if (_owner.CanFinishEvent)
        {
            _owner.gameObject.SetActive(false);
            _event.Finish(Choice, WorldStateProvider.State);
        }
    }
}
