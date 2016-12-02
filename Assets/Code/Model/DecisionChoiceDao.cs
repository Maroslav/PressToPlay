using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.GameState;

namespace Assets.Code.Model
{
    //Data Access Object, stores raw data loaded from the database.
    public struct DecisionChoiceDao
    {
        public DecisionChoiceDao(string description) : this()
        {
            Description = description;
        }

        public string Description { get; private set; }
        public Attribs Attribs { get; set; }
    }
}
