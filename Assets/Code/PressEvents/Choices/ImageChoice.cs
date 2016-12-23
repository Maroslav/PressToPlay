using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.Model.Events.Choices;
using Assets.Code.Model.Events.Effects;

namespace Assets.Code.PressEvents.Choices
{
    public class ImageChoice:Choice
    {

        public ImageChoice(List<Effect> effects, string imagePath ):base(effects)
        {
            this.ImagePath = imagePath;
        }

        //Image path relative to the Resources folder
        public string ImagePath { get; set; }
    }
}
