using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.Model;

namespace Assets.Code.PressEvents
{
    public class DecisionOption
    {
        public DecisionOption(Dictionary<string, int> attributes, string description)
        {
            Attributes = attributes;
            Description = description;
        }

        public DecisionOption(DecisionDao source)
        {
            Attributes = source.Attributes;
            Description = source.Description;
        }
        public Dictionary<string, int> Attributes { get; private set; }
        public string Description { get; private set; }
    }
}
