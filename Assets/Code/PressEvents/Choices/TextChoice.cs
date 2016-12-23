using System.Collections.Generic;
using Assets.Code.GameState;
using Assets.Code.Model.Events.Choices;
using Assets.Code.Model.Events.Effects;

namespace Assets.Code.PressEvents.Choices
{
    //Decision choice in a form of a description text.
    public class TextChoice :Choice
    {

        public TextChoice(List<Effect> effects, string title, string description):base(effects)
        {
            Title = title;
            Description = description;
        }
       
        public string Title { get; private set; }
        public string Description { get; private set; }
    }
}
