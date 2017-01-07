using System.Globalization;
using Assets.Code.PressEvents;
using Assets.Code.PressEvents.Choices;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class ImageChoiceEventProcessor : MonoBehaviour
{
    public GameObject ChoiceDescription;
    public GameObject ChoiceDate;
    public GameObject ChoiceViewer;

    public GameObject Publishing;

    private ImageChoiceEvent _event;


    void OnValidate()
    {
        Assert.IsNotNull(ChoiceDescription, name);
        Assert.IsNotNull(ChoiceDescription.GetComponent<Text>(), name);

        Assert.IsNotNull(ChoiceDate, name);
        Assert.IsNotNull(ChoiceDate.GetComponent<Text>(), name);

        Assert.IsNotNull(ChoiceViewer, name);
        Assert.IsNotNull(ChoiceViewer.GetComponent<ImageChoiceProcessor>(), name);

        Assert.IsNotNull(Publishing, name);
        Assert.IsNotNull(Publishing.GetComponent<PublishingProcessor>(), name);
    }


    public void ProcessEvent(ImageChoiceEvent e)
    {
        _event = e;
        gameObject.SetActive(true);

        // Set event description in the UI
        ChoiceDescription.GetComponent<Text>().text = e.Description;
        CultureInfo csCz = new CultureInfo("cs-CZ");
        ChoiceDate.GetComponent<Text>().text = e.Date.ToString("d", csCz);

        // Let the viewer set its content
        ChoiceViewer.GetComponent<ImageChoiceProcessor>().ProcessEvent(e, this);
    }

    internal void ProcessChoice(ImageChoice choice)
    {
        // Remove old choices and hide not neccesary things
        ChoiceViewer.GetComponent<ImageChoiceProcessor>().DestroyChoices();
        gameObject.SetActive(false);

        // Let the event apply the changes to the world state
        _event.Apply(choice, WorldStateProvider.State);

        // Let Publishing handle the rest (this component is now finished)
        Publishing.GetComponent<PublishingProcessor>().Publish(_event, choice);
    }
}
