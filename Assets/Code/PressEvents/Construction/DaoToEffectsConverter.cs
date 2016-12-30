using Assets.Code.GameState;
using Assets.Code.Model.Events.Effects;
using Assets.Code.PressEvents.Effects;

namespace Assets.Code.PressEvents.Construction
{
    class DaoToEffectsConverter:IEffectDaoProcessor<Effect>
    {
        public Effect Process(ModifyEffectDao effect)
        {
            return new ModifyEffect(Attribs.GetAttribByName(effect.Attribute),effect.Value);
        }

        public Effect Process(MoveTowardsEffectDao effect)
        {
            return new MoveTowardsEffect(Attribs.GetAttribByName(effect.Attribute), effect.Value,effect.Amount);
        }

        public Effect Process(SetEffectDao effect)
        {
            return new SetEffect(Attribs.GetAttribByName(effect.Attribute), effect.Value); 
        }
    }
}
