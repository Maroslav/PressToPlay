using UnityEngine;
using Assets.Code.GameState;
using Assets.Code.PressEvents;

/// <summary>
/// Used in MultipleChoice button prefab
/// </summary>
public class MultipleChoiceData : MonoBehaviour
{
    private MultipleChoiceEvent _event;
    private MultipleChoiceEventProcessor _owner;

    public DecisionChoice Choice;


    public void SetEvent(MultipleChoiceEvent newEvent, MultipleChoiceEventProcessor viewProcessor)
    {
        _event = newEvent;
        _owner = viewProcessor;
    }

    public void OnClick()
    {
        Debug.Log("Moving to next state before choosing option " + Choice.Title);
        _owner.MoveToNextState(Choice);

        if (_owner.CanFinishEvent)
        {
            Debug.Log("Choosing option " + Choice.Title);

            _event.Finish(Choice);
        }
    }
}
