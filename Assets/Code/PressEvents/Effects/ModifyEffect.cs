using Assets.Code.GameState;
using Assets.Code.Model.Events.Effects;

namespace Assets.Code.PressEvents.Effects
{
    //adds or subtracts the given value from the given attribute.
    public class ModifyEffect:Effect
    {
        public ModifyEffect(Attrib affectedAttribute, int value) : base(affectedAttribute, value)
        {
        }

        public override void Apply(WorldState worldState)
        {
            worldState.AddToValue(AffectedAttribute,Value);
        }
    }
}
