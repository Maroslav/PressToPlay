using Assets.Code.GameState;

namespace Assets.Code.PressEvents.Preconditions
{
    internal class LessOrEqualAttribPrecondition : PreconditionCompareAttrib
    {
        public LessOrEqualAttribPrecondition(Attrib attribute, Attrib comparedAttrib):base(attribute,comparedAttrib)
        {
            
        }
        public override bool Check(WorldState state)
        {
            return state.GetValue(Attribute) <= state.GetValue(ComparedAttribute);
        }
    }
}