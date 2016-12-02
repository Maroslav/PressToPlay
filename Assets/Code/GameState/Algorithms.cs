using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Assets.Code.PressEvents;
using UnityEngine;

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

        public static int Distance(Attribs coll1, Attribs coll2,
            params Attrib[] comparedAttributes)
        {
            return Distance(coll1, coll2, comparedAttributes.ToList());
        }
        //
        public static List<DecisionChoice> Closest(List<DecisionChoice> allOptions, Attribs comparedState,  int count,
            List<Attrib> comparedAttributes)
        {
            return (from x in allOptions select new {opt= x, dist=Distance(x.Attributes,comparedState,comparedAttributes)})
                .OrderBy(y=>y.dist).Take(count).Select(x=>x.opt).ToList();
        }
        
    }
}
