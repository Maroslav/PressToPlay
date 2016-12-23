using Assets.Code.GameState;
using Assets.Code.Model.Events.Choices;

namespace Assets.Code.PressEvents.Choices
{
    //Decision choice in a form of a description text.
    public class TextChoice :Choice
    {

        public TextChoice(Attribs attributes, string title, string description):base(attributes)
        {
            Title = title;
            Description = description;
        }

        public TextChoice(TextChoiceDao source):base(source)
        {
            Title = source.Title;
            Description = source.Description;
        }
       
        public string Title { get; private set; }
        public string Description { get; private set; }
    }
}
