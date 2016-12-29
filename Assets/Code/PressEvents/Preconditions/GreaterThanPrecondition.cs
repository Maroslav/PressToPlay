using Assets.Code.GameState;

namespace Assets.Code.PressEvents.Preconditions
{
    internal class GreaterThanPrecondition : Precondition
    {
        public GreaterThanPrecondition(Attrib attribute, int value) : base(attribute, value)
        {
        }

        public override bool Check(WorldState state)
        {
            return state.GetValue(Attribute) > Value;
        }
    }
}