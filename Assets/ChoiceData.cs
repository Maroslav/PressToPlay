using UnityEngine;
using System.Collections;
using Assets.Code.PressEvents;

public class ChoiceData : MonoBehaviour {

    public int choiceIndex;

    MultipleChoiceEvent _event;

    public void setEvent(MultipleChoiceEvent newEvent)
    {
        _event = newEvent;
    }

    public void ChooseOption()
    {
        Debug.Log("Clearing buttons before choosing option " + choiceIndex);
        GameObject viewer = GameObject.Find("EventViewer");
        viewer.GetComponent<PressEventViewProcessor>().DestroyChoices();
        Debug.Log("Choosing option " + choiceIndex);
        if (_event != null)
        {
            _event.SelectOption(_event.Options[choiceIndex]);
        }
    }
}
