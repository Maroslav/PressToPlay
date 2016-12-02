using System;
using System.Collections.Generic;

namespace Assets.Code.Model
{
    //Data Access Object, stores raw data loaded from the database.
    public struct MultipleChoiceEventDao
    {
        public MultipleChoiceEventDao(string description, List<DecisionChoiceDao> options, DateTime? date=null) : this()
        {
            Description = description;
            Options = options;
            Date = date;
        }

        public string Description { get; private set; }
        public List<DecisionChoiceDao> Options { get; private set; }
        public DateTime? Date { get; private set; }
    }
}
