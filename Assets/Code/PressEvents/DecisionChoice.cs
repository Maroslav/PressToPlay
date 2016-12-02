using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.GameState;
using Assets.Code.Model;

namespace Assets.Code.PressEvents
{
    public class DecisionChoice
    {
        public DecisionChoice(Attribs attributes, string description)
        {
            Attributes = attributes;
            Description = description;
        }

        public DecisionChoice(DecisionChoiceDao source)
        {
            Attributes = source.Attribs;
            Description = source.Description;
        }
        public Attribs Attributes { get; private set; }
        public string Description { get; private set; }
    }
}
