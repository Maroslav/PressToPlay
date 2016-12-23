using System.Globalization;
using Assets.Code.PressEvents;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class PressEventsProcessor : MonoBehaviour, IEventProcessor
{
    public GameObject MultipleChoiceEvent;
   
    public GameObject CutsceneEventDescription;
    public GameObject CutsceneEventViewer;


    void OnValidate()
    {
        Assert.IsNotNull(MultipleChoiceEvent, name);
        Assert.IsNotNull(MultipleChoiceEvent.GetComponent<MultipleChoiceEventProcessor>(), name);

        Assert.IsNotNull(CutsceneEventViewer, name);
        Assert.IsNotNull(CutsceneEventViewer.GetComponent<CutsceneProcessor>(), name);
    }

    public void ProcessEvent(MultipleChoiceEvent e)
    {
        MultipleChoiceEvent.GetComponent<MultipleChoiceEventProcessor>().ProcessEvent(e);
    }

    public void ProcessEvent(CutsceneEvent e)
    {
        // Set event description in the UI
        CutsceneEventDescription.GetComponentInChildren<Text>().text = e.Description;
        // Let the viewer set its content
        CutsceneEventViewer.GetComponent<CutsceneProcessor>().ProcessEvent(e);
    }

    public void ProcessEvent(ImageChoiceEvent e)
    {
        throw new System.NotImplementedException();
    }
}
