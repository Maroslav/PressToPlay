using Assets.Code.PressEvents;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class PressEventsProcessor : MonoBehaviour, IEventProcessor
{
    public GameObject MultipleChoiceEventDescription;
    public GameObject MultipleChoiceEventViewer;

    public GameObject CutsceneEventDescription;
    public GameObject CutsceneEventViewer;


    void OnValidate()
    {
        Assert.IsNotNull(MultipleChoiceEventDescription);
        Assert.IsNotNull(MultipleChoiceEventDescription.GetComponent<Text>());
        Assert.IsNotNull(MultipleChoiceEventViewer);
        Assert.IsNotNull(MultipleChoiceEventViewer.GetComponent<MultipleChoiceProcessor>());

        Assert.IsNotNull(MultipleChoiceEventDescription);
        Assert.IsNotNull(MultipleChoiceEventDescription.GetComponent<Text>());
        Assert.IsNotNull(CutsceneEventViewer);
        Assert.IsNotNull(CutsceneEventViewer.GetComponent<CutsceneProcessor>());
    }

    public void ProcessEvent(MultipleChoiceEvent e)
    {
        // Set event description in the UI
        MultipleChoiceEventDescription.GetComponentInChildren<Text>().text = e.Description;
        // Let the viewer set its content
        MultipleChoiceEventViewer.GetComponent<MultipleChoiceProcessor>().ProcessEvent(e);
    }

    public void ProcessEvent(CutsceneEvent e)
    {
        // Set event description in the UI
        CutsceneEventDescription.GetComponentInChildren<Text>().text = e.Description;
        // Let the viewer set its content
        CutsceneEventViewer.GetComponent<CutsceneProcessor>().ProcessEvent(e);
    }
}
