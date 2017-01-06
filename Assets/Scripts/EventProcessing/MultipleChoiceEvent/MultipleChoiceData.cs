using UnityEngine;
using Assets.Code.GameState;
using Assets.Code.PressEvents;
using Assets.Code.PressEvents.Choices;

/// <summary>
/// Used in MultipleChoice button prefab
/// </summary>
public class MultipleChoiceData : MonoBehaviour
{
    private TextChoice _choice;
    private MultipleChoiceEventProcessor _owner;


    public void SetEvent(TextChoice choice, MultipleChoiceEventProcessor viewProcessor)
    {
        _choice = choice;
        _owner = viewProcessor;
    }

    public void OnClick()
    {
        _owner.FinishEvent(_choice);
    }
}
