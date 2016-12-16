using System.Globalization;
using Assets.Code.PressEvents;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class PressEventsProcessor : MonoBehaviour, IEventProcessor
{
    public GameObject MultipleChoiceEventDescription;
    public GameObject MultipleChoiceEventDate;
    public GameObject MultipleChoiceEventViewer;

    public GameObject CutsceneEventDescription;
    public GameObject CutsceneEventViewer;


    void OnValidate()
    {
        Assert.IsNotNull(MultipleChoiceEventDescription, name);
        Assert.IsNotNull(MultipleChoiceEventDescription.GetComponent<Text>(), name);
        Assert.IsNotNull(MultipleChoiceEventDate, name);
        Assert.IsNotNull(MultipleChoiceEventDate.GetComponent<Text>(), name);
        Assert.IsNotNull(MultipleChoiceEventViewer, name);
        Assert.IsNotNull(MultipleChoiceEventViewer.GetComponent<MultipleChoiceProcessor>(), name);

        Assert.IsNotNull(MultipleChoiceEventDescription, name);
        Assert.IsNotNull(MultipleChoiceEventDescription.GetComponent<Text>(), name);
        Assert.IsNotNull(CutsceneEventViewer, name);
        Assert.IsNotNull(CutsceneEventViewer.GetComponent<CutsceneProcessor>(), name);
    }

    public void ProcessEvent(MultipleChoiceEvent e)
    {
        // Set event description in the UI
        MultipleChoiceEventDescription.GetComponent<Text>().text = e.Description;
        CultureInfo csCz = new CultureInfo("cs-CZ");
        MultipleChoiceEventDate.GetComponent<Text>().text = e.Date.ToString("d", csCz);
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
