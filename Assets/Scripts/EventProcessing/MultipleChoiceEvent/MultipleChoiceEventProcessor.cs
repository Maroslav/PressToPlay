using UnityEngine;
using Assets.Code.PressEvents;
using Assets.Code.PressEvents.Choices;
using UnityEngine.Assertions;

public class MultipleChoiceEventProcessor : ChoiceEventProcessorBase<MultipleChoiceEvent, TextChoice>
{
    public GameObject ChoiceViewer;


    void OnValidate()
    {
        Assert.IsNotNull(ChoiceViewer, name);
        Assert.IsNotNull(ChoiceViewer.GetComponent<MultipleChoiceProcessor>(), name);
    }


    public override void ProcessEvent(MultipleChoiceEvent e)
    {
        base.ProcessEvent(e);

        // Let the viewer set its content
        ChoiceViewer.GetComponent<MultipleChoiceProcessor>().ProcessEvent(e, this);
    }

    internal override void ProcessChoice(TextChoice choice)
    {
        base.ProcessChoice(choice);

        // Remove old choices
        ChoiceViewer.GetComponent<MultipleChoiceProcessor>().DestroyChoices();
    }
}
