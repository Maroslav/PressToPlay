using UnityEngine;
using Assets.Code.PressEvents;
using Assets.Code.PressEvents.Choices;

public class PublishingProcessor : MonoBehaviour
{
    public GameObject Title;


    private PressEvent _event;


    //void OnValidate()
    //{
    //    Assert.IsNotNull(ChoiceDescription, name);
    //    Assert.IsNotNull(ChoiceDescription.GetComponent<Text>(), name);

    //    Assert.IsNotNull(ChoiceDate, name);
    //    Assert.IsNotNull(ChoiceDate.GetComponent<Text>(), name);

    //    Assert.IsNotNull(ChoiceViewer, name);
    //    Assert.IsNotNull(ChoiceViewer.GetComponent<MultipleChoiceProcessor>(), name);

    //    Assert.IsNotNull(Publishing, name);
    //    Assert.IsNotNull(Publishing.GetComponent<PublishingProcessor>(), name);
    //}


    public void Publish(PressEvent e, TextChoice choice)
    {
        _event = e;

        //    ChoiceDescription.GetComponent<Text>().text = choice.Description;
        //    MultipleChoiceData multipleChoiceData = ChoicePublish.GetComponent<MultipleChoiceData>();
        //    multipleChoiceData.Choice = choice;
        //    multipleChoiceData.SetEvent(_event, this);
    }

    public void Finish()
    {
    }
}
