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

        public ImageChoice(List<Effect> effects, string imagePath, string imageLabel, string title, string description, string articleText):base(effects, imagePath,imageLabel,title,description,articleText)
        {
            this.ImagePath = imagePath;
        }


    }
}
