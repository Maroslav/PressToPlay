using UnityEngine;
using System.Collections;
using System.Globalization;
using Assets.Code.PressEvents;
using Assets.Code.PressEvents.Choices;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class MultipleChoiceEventProcessor : MonoBehaviour {

    public GameObject ChoiceDescription;
    public GameObject ChoiceDate;
    public GameObject ChoiceViewer;
    public GameObject ChoicePublish;

    private bool _isShowingSelectedChoice = false;
    private MultipleChoiceEvent _event;
    public bool CanFinishEvent { get; private set; }

    void OnValidate()
    {
        Assert.IsNotNull(ChoiceDescription, name);
        Assert.IsNotNull(ChoiceDescription.GetComponent<Text>(), name);

        Assert.IsNotNull(ChoiceDate, name);
        Assert.IsNotNull(ChoiceDate.GetComponent<Text>(), name);
        
        Assert.IsNotNull(ChoiceViewer, name);
        Assert.IsNotNull(ChoiceViewer.GetComponent<MultipleChoiceProcessor>(), name);
    }

    internal void MoveToNextState(TextChoice choice)
    {
        if (_isShowingSelectedChoice)
        {
            _isShowingSelectedChoice = false;
            CanFinishEvent = true;
        }
        else
        {
            // Remove old choices and hide not neccesary things
            ChoiceViewer.GetComponent<MultipleChoiceProcessor>().DestroyChoices();
            ChoiceViewer.SetActive(false);

            ChoiceDescription.GetComponent<Text>().text = choice.Description;
            ChoicePublish.SetActive(true);
            MultipleChoiceData multipleChoiceData = ChoicePublish.GetComponent<MultipleChoiceData>();
            multipleChoiceData.Choice = choice;
            multipleChoiceData.SetEvent(_event, this);

            _isShowingSelectedChoice = true;
        }
    }

    public void ProcessEvent(MultipleChoiceEvent e)
    {
        _event = e;
        CanFinishEvent = false;

        ChoicePublish.SetActive(false);
        ChoiceViewer.SetActive(true);

        // Set event description in the UI
        ChoiceDescription.GetComponent<Text>().text = e.Description;
        CultureInfo csCz = new CultureInfo("cs-CZ");
        ChoiceDate.GetComponent<Text>().text = e.Date.ToString("d", csCz);

        gameObject.SetActive(true);
        
        // Let the viewer set its content
        ChoiceViewer.GetComponent<MultipleChoiceProcessor>().ProcessEvent(e, this);
    }
}
