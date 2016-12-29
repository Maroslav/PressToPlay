using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Code.Gameplay;
using Assets.Code.Model.Events.Effects;
using Assets.Code.PressEvents;
using Assets.Code.PressEvents.Choices;
using Random = System.Random;

namespace Assets.Code.GameState
{
    public static class Algorithms
    {
        //Sums the distances of attributes that are present in the 'comparedAttributes' collection
        //If one of the dictionaries does not contain the given attribute, no penalty is added (distance is 0).
        public static int Distance(Attribs coll1, Attribs coll2, List<Attrib> comparedAttributes)
        {
            int distance = 0;
            foreach (var attribute in comparedAttributes)
            {
                if (coll1.Values.ContainsKey(attribute) && coll2.Values.ContainsKey(attribute))
                {
                    distance += Math.Abs(coll1.Values[attribute] - coll2.Values[attribute]);
                }
            }
            return distance;
        }


        private static int Distance(List<Effect> effects, WorldState state)
        {
            int dist = 0;
            foreach (var effect in effects)
            {
                dist += effect.GetDistance(state);
            }
            return dist;
        }
        public static List<TextChoice> Closest(List<TextChoice> allOptions,WorldState worldState, int count)
        {
            var choices = (from x in allOptions select new { opt = x, dist = Distance(x.Effects, worldState) })
                .OrderBy(y => y.dist).Take(count).Select(x => x.opt).ToList();
            List<TextChoice> res = new List<TextChoice>(count);
            foreach (var op in allOptions)
            {
                if (choices.Contains(op))
                {
                    res.Add(op);
                }
            }
            return res;
        }
        //How much each attribute can move towards another attribute in one step:
        public const int AttribMoveStep = 100;

        ///returns the new value: 'currentValue' moved towards the 'positionValue'
        public static int MoveTowardsPosition(int currentValue, int positionValue, int amount = AttribMoveStep)
        {
            int diff = currentValue - positionValue;
            var abs = Math.Abs(diff);
            if (abs > amount)
            {
                diff = -Math.Sign(diff) * amount;
            }
            return currentValue + diff;
        }
        public static int AttribsDifference(Attribs a, Attribs b, Attrib attributeName)
        {
            return a.Values[attributeName] - b.Values[attributeName];
        }

        public static int RandomPauseBetweenEvents()
        {
            Random r = new Random();
            return (int)Math.Round(Math.Log(1 - r.NextDouble()) * -1 * Constants.RandomEventsMeanVal);

        }
    }
}
