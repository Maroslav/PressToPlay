using Assets.Code.PressEvents;
using UnityEngine;
using UnityEngine.UI;

internal class PressEventsProcessor : IEventProcessor
{
    public void ProcessEvent(MultipleChoiceEvent e)
    {
        // Set event description in the UI
        GameObject description = GameObject.Find("HeadLineEvent");
        description.GetComponentInChildren<Text>().text = e.Description;

        // Let the viewer set its content
        GameObject viewer = GameObject.Find("EventViewer");
        viewer.GetComponent<PressEventViewProcessor>().ProcessEvent(e);
    }
}