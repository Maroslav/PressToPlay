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
    public GameObject ChoiceBody;
    public GameObject ChoiceViewer;
    public GameObject ChoicePublish;

    private bool _isShowingSelectedChoice = false;
    private ImageChoiceEvent _event;
    public bool CanFinishEvent { get; private set; }

    void OnValidate()
    {
        Assert.IsNotNull(ChoiceDescription, name);
        Assert.IsNotNull(ChoiceDescription.GetComponent<Text>(), name);

        Assert.IsNotNull(ChoiceDate, name);
        Assert.IsNotNull(ChoiceDate.GetComponent<Text>(), name);

        Assert.IsNotNull(ChoiceBody, name);

        Assert.IsNotNull(ChoiceViewer, name);
        Assert.IsNotNull(ChoiceViewer.GetComponent<ImageChoiceProcessor>(), name);
    }

    internal void MoveToNextState(ImageChoice choice)
    {
        if (_isShowingSelectedChoice)
        {
            _isShowingSelectedChoice = false;
            CanFinishEvent = true;
        }
        else
        {
            // Remove old choices and hide not neccesary things
            ChoiceViewer.GetComponent<ImageChoiceProcessor>().DestroyChoices();
            ChoiceViewer.SetActive(false);
            ChoiceBody.SetActive(false);
            ChoiceDate.SetActive(false);

            //ImageChoiceEventDescription.GetComponent<Text>().text = choice.Description;
            ChoicePublish.SetActive(true);
            ImageChoiceData imageChoiceData = ChoicePublish.GetComponent<ImageChoiceData>();
            imageChoiceData.Choice = choice;
            imageChoiceData.SetEvent(_event, this);

            _isShowingSelectedChoice = true;
        }
    }

    public void ProcessEvent(ImageChoiceEvent e)
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
        ChoiceBody.SetActive(true);
        ChoiceDate.SetActive(true);

        // Let the viewer set its content
        ChoiceViewer.GetComponent<ImageChoiceProcessor>().ProcessEvent(e, this);
    }
}
