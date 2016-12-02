using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Code.GameState
{
    public static class Attributes
    {
        //Values 0 - 1000;
        public const string Credibility = "Credibility";

        public const int MinValue = 0;
        public const int MaxValue = 1000;
        public const int MidValue = (MinValue + MaxValue)/2;

        public static List<string> JournalistAttributes =new List<string>() {Credibility};
    }
}
