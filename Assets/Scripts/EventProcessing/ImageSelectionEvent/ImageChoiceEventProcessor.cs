using UnityEngine;
using Assets.Code.PressEvents;
using Assets.Code.PressEvents.Choices;
using UnityEngine.Assertions;

public class ImageChoiceEventProcessor : ChoiceEventProcessorBase<ImageChoiceEvent, ImageChoice>
{
    public GameObject ChoiceViewer;


    void OnValidate()
    {
        Assert.IsNotNull(ChoiceViewer, name);
        Assert.IsNotNull(ChoiceViewer.GetComponent<ImageChoiceProcessor>(), name);
    }


    public override void ProcessEvent(ImageChoiceEvent e)
    {
        base.ProcessEvent(e);

        // Let the viewer set its content
        ChoiceViewer.GetComponent<ImageChoiceProcessor>().ProcessEvent(e, this);
    }

    internal override void ProcessChoice(ImageChoice choice)
    {
        base.ProcessChoice(choice);

        // Remove old choices
        ChoiceViewer.GetComponent<ImageChoiceProcessor>().DestroyChoices();
    }
}
