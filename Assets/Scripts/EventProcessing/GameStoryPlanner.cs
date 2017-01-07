using System.Globalization;
using Assets.Code.Gameplay;
using Assets.Code.GameState;
using Assets.Code.Planning;
using Assets.Code.PressEvents;
using Assets.Scripts.Misc;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    [RequireComponent(typeof(ScenePicker))]
    public class GameStoryPlanner : MonoBehaviour
    {
        public GameObject ProcessorGameObject;

        private PressEvent _currentEvent;
        private IPressEventScheduler _scheduler;

        public int skipEventsCount = 0;
        public int addToAttributeInfo = 0;
        public int addToAttributeFun = 0;
        public int addToAttributePanic = 0;
        public int addToAttributeTom = 0;
        public int addToAttributeAlice = 0;
        public bool buttonApply = false;

        private PressEventsProcessor Processor { get { return ProcessorGameObject.GetComponent<PressEventsProcessor>(); } }


        void Validate()
        {
            Assert.IsNotNull(ProcessorGameObject);
            Assert.IsNotNull(Processor);
            Assert.IsNotNull(GetComponent<ScenePicker>().scenePath);
        }

        void Start()
        {
            _scheduler = GameInit.CreateEventScheduler(WorldStateProvider.State);
            _currentEvent = _scheduler.PopNextEvent();
            if (_currentEvent != null)
            {
                _currentEvent.ProcessEvent(Processor);
            }
        }


        // Update is called once per frame
        void Update()
        {
            if (buttonApply)
            {
                buttonApply = false;
                for (int i = 0; i < skipEventsCount; i++)
                {
                    _scheduler.PopNextEvent();
                }
                var info=Attribs.GetAttribByName("Info");
                var panic=Attribs.GetAttribByName("Panic");
                var fun =Attribs.GetAttribByName("Fun");
                var tom=Attribs.GetAttribByName("Tom");
                var alice=Attribs.GetAttribByName("Alice");
                var s = WorldStateProvider.State;
                s.AddToValue(alice,addToAttributeAlice);
                s.AddToValue(panic,addToAttributePanic);
                s.AddToValue(tom, addToAttributeTom);
                s.AddToValue(fun, addToAttributeFun);
                s.AddToValue(info,addToAttributeInfo);
            }
            if (_currentEvent == null)
                return;

            if (_currentEvent.IsFinished)
            {
                _currentEvent = _scheduler.PopNextEvent();

                if (_currentEvent != null)
                {
                    _currentEvent.ProcessEvent(Processor);
                }
                else
                {
                    GetComponent<ScenePicker>().LoadScene();
                }
            }
        }
    }
}
