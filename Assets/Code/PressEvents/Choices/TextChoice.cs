using System.Collections.Generic;
using Assets.Code.GameState;
using Assets.Code.Model.Events.Choices;
using Assets.Code.Model.Events.Effects;

namespace Assets.Code.PressEvents.Choices
{
    //Decision choice in a form of a description text.
    public class TextChoice :Choice
    {

        public TextChoice(List<Effect> effects, string choiceText, string title, string description,string articleText=null, string imagePath=null, string imageLabel=null):base(effects,imagePath,imageLabel,title,description,articleText)
        {
            ChoiceText = choiceText;
        }

        public string ChoiceText { get; set; }
 
    }
}
