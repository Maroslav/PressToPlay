using UnityEngine;
using System.Collections;
using Assets.Code.GameState;
using Assets.Code.PressEvents;

public class ChoiceData : MonoBehaviour
{
    public int ChoiceIndex;

    MultipleChoiceEvent _event;
    private MultipleChoiceProcessor _owner;

    public void SetEvent(MultipleChoiceEvent newEvent, MultipleChoiceProcessor viewProcessor)
    {
        _event = newEvent;
        _owner = viewProcessor;
    }

    public void ChooseOption()
    {
        Debug.Log("Clearing buttons before choosing option " + ChoiceIndex);
        _owner.DestroyChoices();
        Debug.Log("Choosing option " + ChoiceIndex);

        if (_event != null)
        {
            _event.FinishEvent(_event.Choices[ChoiceIndex], new WorldState());
        }
    }
}
