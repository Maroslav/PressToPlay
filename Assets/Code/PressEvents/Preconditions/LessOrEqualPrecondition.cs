using Assets.Code.GameState;

namespace Assets.Code.PressEvents.Preconditions
{
    internal class LessOrEqualPrecondition : Precondition
    {
        public LessOrEqualPrecondition(Attrib attribute, int value) : base(attribute, value)
        {
        }

        public override bool Check(WorldState state)
        {
            return state.GetValue(Attribute) <= Value;
        }
    }
}