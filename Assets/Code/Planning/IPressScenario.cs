using Assets.Code.PressEvents;

namespace Assets.Code.Planning
{
    //Represents a queue of events.
    public interface IPressScenario
    {
        //Gets the next event in the queue.
        PressEvent PeekNextEvent();
        //Gets the next event and removes it from the scenario.
        PressEvent PopNextEvent();
    }
}