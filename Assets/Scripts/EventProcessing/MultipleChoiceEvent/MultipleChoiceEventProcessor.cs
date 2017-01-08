using UnityEngine;
using System.Globalization;
using Assets.Code.PressEvents;
using Assets.Code.PressEvents.Choices;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class MultipleChoiceEventProcessor : MonoBehaviour
{
    public GameObject ChoiceName;
    public GameObject ChoiceDescription;
    public GameObject ChoiceDate;
    public GameObject ChoiceViewer;

    public GameObject Publishing;

    private MultipleChoiceEvent _event;


    void OnValidate()
    {
        Assert.IsNotNull(ChoiceName, name);
        Assert.IsNotNull(ChoiceName.GetComponent<Text>(), name);

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
        Debug.Log("Processing new multiple choice event: " + _event.Date);
        gameObject.SetActive(true);

        // Set event description in the UI
        ChoiceName.GetComponent<Text>().text = e.Name;
        ChoiceDescription.GetComponent<Text>().text = e.Description;
        ChoiceDate.GetComponent<Text>().text = e.Date.ToString("d", new CultureInfo("cs-CZ"));

        // Let the viewer set its content
        ChoiceViewer.GetComponent<MultipleChoiceProcessor>().ProcessEvent(e, this);
    }

    internal void ProcessChoice(TextChoice choice)
    {
        Debug.Log("Choosing option " + choice.Title);

        // Remove old choices and hide not neccesary things
        ChoiceViewer.GetComponent<MultipleChoiceProcessor>().DestroyChoices();
        gameObject.SetActive(false);

        // Let the event apply the changes to the world state
        _event.Apply(choice, WorldStateProvider.State);
        WorldStateProvider.UpdateAttributeGameObjects();
        // Let Publishing handle the rest (this component is now finished)
        Publishing.GetComponent<PublishingProcessor>().Publish(_event, choice);
    }
}
