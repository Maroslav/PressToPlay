using UnityEngine;
using System.Collections;
using System.Globalization;
using Assets.Code.PressEvents;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class MultipleChoiceEventProcessor : MonoBehaviour {

    public GameObject MultipleChoiceEventDescription;
    public GameObject MultipleChoiceEventDate;
    public GameObject MultipleChoiceEventBody;
    public GameObject MultipleChoiceEventViewer;
    public GameObject MultipleChoiceEventPublish;

    private bool _isShowingSelectedChoice = false;
    private MultipleChoiceEvent _event;
    public bool CanFinishEvent { get; private set; }

    void OnValidate()
    {
        Assert.IsNotNull(MultipleChoiceEventDescription, name);
        Assert.IsNotNull(MultipleChoiceEventDescription.GetComponent<Text>(), name);

        Assert.IsNotNull(MultipleChoiceEventDate, name);
        Assert.IsNotNull(MultipleChoiceEventDate.GetComponent<Text>(), name);

        Assert.IsNotNull(MultipleChoiceEventBody, name);
        
        Assert.IsNotNull(MultipleChoiceEventViewer, name);
        Assert.IsNotNull(MultipleChoiceEventViewer.GetComponent<MultipleChoiceProcessor>(), name);
    }

    internal void MoveToNextState(DecisionChoice choice)
    {
        if (_isShowingSelectedChoice)
        {
            _isShowingSelectedChoice = false;
            CanFinishEvent = true;
            MultipleChoiceEventPublish.SetActive(false);
        }
        else
        {
            // Remove old choices and hide not neccesary things
            MultipleChoiceEventViewer.GetComponent<MultipleChoiceProcessor>().DestroyChoices();
            MultipleChoiceEventViewer.SetActive(false);
            MultipleChoiceEventBody.SetActive(false);
            MultipleChoiceEventDate.SetActive(false);

            MultipleChoiceEventDescription.GetComponent<Text>().text = choice.Description;
            MultipleChoiceEventPublish.SetActive(true);
            MultipleChoiceData multipleChoiceData = MultipleChoiceEventPublish.GetComponent<MultipleChoiceData>();
            multipleChoiceData.Choice = choice;
            multipleChoiceData.SetEvent(_event, this);

            _isShowingSelectedChoice = true;
        }
    }

    public void ProcessEvent(MultipleChoiceEvent e)
    {
        _event = e;
        CanFinishEvent = false;

        MultipleChoiceEventPublish.SetActive(false);
        MultipleChoiceEventViewer.SetActive(true);

        // Set event description in the UI
        MultipleChoiceEventDescription.GetComponent<Text>().text = e.Description;
        CultureInfo csCz = new CultureInfo("cs-CZ");
        MultipleChoiceEventDate.GetComponent<Text>().text = e.Date.ToString("d", csCz);

        gameObject.SetActive(true);
        MultipleChoiceEventBody.SetActive(true);
        MultipleChoiceEventDate.SetActive(true);
        
        // Let the viewer set its content
        MultipleChoiceEventViewer.GetComponent<MultipleChoiceProcessor>().ProcessEvent(e, this);
    }
}
