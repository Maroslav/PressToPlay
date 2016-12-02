using Assets.Code.Planning;
using Assets.Code.PressEvents;
using Assets.Code.Test;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameStoryPlanner : MonoBehaviour
    {
        private PressEvent currentEvent;
        private IPressEventScheduler scheduler = new MockupPressEventScheduler();
        private IEventProcessor processor = new PressEventsProcessor();
        void Start ()
        {
            currentEvent = scheduler.PopNextEvent();
            if (currentEvent != null)
            {
                currentEvent.ProcessEvent(processor);
            }
        }
	
        // Update is called once per frame
        void Update ()
        {
            if (currentEvent == null) return;
            if (currentEvent.IsFinished)
            {
                currentEvent = scheduler.PopNextEvent();
                if (currentEvent != null)
                {
                    currentEvent.ProcessEvent(processor);
                }
            }
        }
    }
}
