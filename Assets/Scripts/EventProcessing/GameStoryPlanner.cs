using System;
using Assets.Code.Planning;
using Assets.Code.PressEvents;
using Assets.Code.Test;
using UnityEngine;
using UnityEngine.Assertions;

namespace Assets.Scripts
{
    public class GameStoryPlanner : MonoBehaviour
    {
        public GameObject ProcessorGameObject;

        private PressEvent currentEvent;
        private IPressEventScheduler scheduler = new MockupPressEventScheduler();


        private PressEventsProcessor Processor { get { return ProcessorGameObject.GetComponent<PressEventsProcessor>(); } }


        void Validate()
        {
            Assert.IsNotNull(ProcessorGameObject);
            Assert.IsNotNull(Processor);
        }

        void Start()
        {
            currentEvent = scheduler.PopNextEvent();
            if (currentEvent != null)
            {
                currentEvent.ProcessEvent(Processor);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (currentEvent == null)
                return;

            if (currentEvent.IsFinished)
            {
                currentEvent = scheduler.PopNextEvent();

                if (currentEvent != null)
                {
                    currentEvent.ProcessEvent(Processor);
                }
            }
        }
    }
}
