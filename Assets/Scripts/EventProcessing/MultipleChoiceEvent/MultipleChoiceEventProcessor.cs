using UnityEngine;
using System.Globalization;
using Assets.Code.PressEvents;
using Assets.Code.PressEvents.Choices;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class MultipleChoiceEventProcessor : MonoBehaviour
{

    public GameObject ChoiceDescription;
    public GameObject ChoiceDate;
    public GameObject ChoiceViewer;

    public GameObject Publishing;

    private MultipleChoiceEvent _event;

    void OnValidate()
    {
        Assert.IsNotNull(ChoiceDescription, name);
        Assert.IsNotNull(ChoiceDescription.GetComponent<Text>(), name);

        Assert.IsNotNull(ChoiceDate, name);
        Assert.IsNotNull(ChoiceDate.GetComponent<Text>(), name);

        Assert.IsNotNull(ChoiceViewer, name);
        Assert.IsNotNull(ChoiceViewer.GetComponent<MultipleChoiceProcessor>(), name);

        Assert.IsNotNull(Publishing, name);
        Assert.IsNotNull(Publishing.GetComponent<PublishingProcessor>(), name);
    }

    public void ProcessEvent(MultipleChoiceEvent e)
    {
        _event = e;

        // Set event description in the UI
        ChoiceDescription.GetComponent<Text>().text = e.Description;
        CultureInfo csCz = new CultureInfo("cs-CZ");
        ChoiceDate.GetComponent<Text>().text = e.Date.ToString("d", csCz);

        gameObject.SetActive(true);

        // Let the viewer set its content
        ChoiceViewer.GetComponent<MultipleChoiceProcessor>().ProcessEvent(e, this);
    }

    internal void FinishEvent(TextChoice choice)
    {
        // Let the event apply the changes to the world stat
        Debug.Log("Choosing option " + choice.Title);
        _event.Finish(choice, WorldStateProvider.State);

        // Remove old choices and hide not neccesary things
        ChoiceViewer.GetComponent<MultipleChoiceProcessor>().DestroyChoices();
        gameObject.SetActive(false);

        // Let Publishing handle the rest (this component is now finished)
        Publishing.GetComponent<PublishingProcessor>().Publish(_event, choice);
    }
}
