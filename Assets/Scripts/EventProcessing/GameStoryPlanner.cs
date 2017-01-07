using Assets.Code.Gameplay;
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
            if (_currentEvent == null)
                return;

            if (_currentEvent.IsFinished)
            {
                WorldStateProvider.UpdateAttributeGameObjects();
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
