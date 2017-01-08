using Assets.Code.GameState;

namespace Assets.Code.PressEvents.Preconditions
{
    internal class EqualAttribPrecondition : PreconditionCompareAttrib
    {

        public EqualAttribPrecondition(Attrib attribute, Attrib comparedAttrib):base(attribute,comparedAttrib)
        {
        }
        public override bool Check(WorldState state)
        {
            return state.GetValue(ComparedAttribute) == state.GetValue(Attribute);
        }
    }
}