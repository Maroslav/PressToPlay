using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Code.Model
{
    //Data Access Object, stores raw data loaded from the database.
    public struct DecisionDao
    {
        public DecisionDao(string description) : this()
        {
            Description = description;
        }

        public string Description { get; private set; }
        public Dictionary<string, int> Attributes { get; set; }
    }
}
