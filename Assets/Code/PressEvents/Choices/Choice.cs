using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.GameState;
using Assets.Code.Model.Events.Choices;
using Assets.Code.Model.Events.Effects;

namespace Assets.Code.PressEvents.Choices
{
    public class Choice
    {
        public List<Effect> Effects { get; private set; }

        public Choice(List<Effect> effects)
        {
            Effects = effects;
        }

        public void ApplyEffects(WorldState state)
        {
            foreach (var effect in Effects)
            {
                effect.Apply(state);
            }
        }
    }
}
