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

        public Choice(List<Effect> effects, string imagePath, string title, string description, string articleText)
        {
            Effects = effects;
            ImagePath = imagePath;
            Title = title;
            Description = description;
            ArticleText = articleText;
        }

        public void ApplyEffects(WorldState state)
        {
            foreach (var effect in Effects)
            {
                effect.Apply(state);
            }
        }
        //Image path relative to the Resources folder
        public string ImagePath { get; set; }
        public string Title { get; private set; }
        public string Description { get; private set; }

        public string ArticleText { get; private set; }
    }
}
