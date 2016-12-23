using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.GameState;
using Assets.Code.Model.Events.Choices;

namespace Assets.Code.PressEvents.Choices
{
    public class Choice
    {
        public Attribs Attributes { get; private set; }

        public Choice(ChoiceDao source)
        {
            Attributes = new Attribs();
            foreach (var attrib in source.Attribs)
            {
                Attributes[Attribs.GetAttribByName(attrib.AttributeName)] = attrib.Value;
            }
        }

        public Choice(Attribs attributes)
        {
            Attributes = attributes;
        }
    }
}
