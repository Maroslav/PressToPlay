namespace Assets.Code.PressEvents
{
    //Visitor pattern, corresponds to the 'Visitor class'
    public interface IEventProcessor
    {
        void ProcessEvent(MultipleChoiceEvent e);
        void ProcessEvent(CutsceneEvent e);
    }
}
