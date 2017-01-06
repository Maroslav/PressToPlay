using System.Globalization;
using Assets.Code.PressEvents;
using Assets.Code.PressEvents.Choices;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class ImageChoiceEventProcessor : MonoBehaviour
{
    public GameObject ImageChoiceEventDescription;
    public GameObject ImageChoiceEventDate;
    public GameObject ImageChoiceEventBody;
    public GameObject ImageChoiceEventViewer;
    public GameObject ImageChoiceEventPublish;

    private bool _isShowingSelectedChoice = false;
    private ImageChoiceEvent _event;
    public bool CanFinishEvent { get; private set; }

    void OnValidate()
    {
        Assert.IsNotNull(ImageChoiceEventDescription, name);
        Assert.IsNotNull(ImageChoiceEventDescription.GetComponent<Text>(), name);

        Assert.IsNotNull(ImageChoiceEventDate, name);
        Assert.IsNotNull(ImageChoiceEventDate.GetComponent<Text>(), name);

        Assert.IsNotNull(ImageChoiceEventBody, name);

        Assert.IsNotNull(ImageChoiceEventViewer, name);
        Assert.IsNotNull(ImageChoiceEventViewer.GetComponent<ImageChoiceProcessor>(), name);
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
            ImageChoiceEventViewer.GetComponent<ImageChoiceProcessor>().DestroyChoices();
            ImageChoiceEventViewer.SetActive(false);
            ImageChoiceEventBody.SetActive(false);
            ImageChoiceEventDate.SetActive(false);

            //ImageChoiceEventDescription.GetComponent<Text>().text = choice.Description;
            ImageChoiceEventPublish.SetActive(true);
            ImageChoiceData imageChoiceData = ImageChoiceEventPublish.GetComponent<ImageChoiceData>();
            imageChoiceData.Choice = choice;
            imageChoiceData.SetEvent(_event, this);

            _isShowingSelectedChoice = true;
        }
    }

    public void ProcessEvent(ImageChoiceEvent e)
    {
        _event = e;

        CanFinishEvent = false;

        ImageChoiceEventPublish.SetActive(false);
        ImageChoiceEventViewer.SetActive(true);

        // Set event description in the UI
        ImageChoiceEventDescription.GetComponent<Text>().text = e.Description;
        CultureInfo csCz = new CultureInfo("cs-CZ");
        ImageChoiceEventDate.GetComponent<Text>().text = e.Date.ToString("d", csCz);

        gameObject.SetActive(true);
        ImageChoiceEventBody.SetActive(true);
        ImageChoiceEventDate.SetActive(true);

        // Let the viewer set its content
        ImageChoiceEventViewer.GetComponent<ImageChoiceProcessor>().ProcessEvent(e, this);
    }
}
