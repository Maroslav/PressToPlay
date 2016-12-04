using UnityEngine;
using Assets.Code.GameState;
using Assets.Code.PressEvents;

/// <summary>
/// Used in MultipleChoice button prefab
/// </summary>
public class MultipleChoiceData : MonoBehaviour
{
    private MultipleChoiceEvent _event;
    private MultipleChoiceProcessor _owner;


    public int ChoiceIndex;


    public void SetEvent(MultipleChoiceEvent newEvent, MultipleChoiceProcessor viewProcessor)
    {
        _event = newEvent;
        _owner = viewProcessor;
    }

    public void OnClick()
    {
        Debug.Log("Clearing buttons before choosing option " + ChoiceIndex);
        _owner.DestroyChoices();
        Debug.Log("Choosing option " + ChoiceIndex);

        _event.Finish(ChoiceIndex);
    }
}
