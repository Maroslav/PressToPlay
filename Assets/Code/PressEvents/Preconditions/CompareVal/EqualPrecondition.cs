using Assets.Code.GameState;

namespace Assets.Code.PressEvents.Preconditions
{
    internal class EqualPrecondition : PreconditionCompareValue
    {
        public EqualPrecondition(Attrib attribute, int value) : base(attribute, value)
        {
        }

        public override bool Check(WorldState state)
        {
            return Value == state.GetValue(Attribute);
        }
    }
}