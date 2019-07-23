using Logger.Exceptions;
using Logger.Models.Interfaces;
using Logger.Models.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Factories
{
   public class LayoutFactory
    {
        public ILayout GetLayout(string type)
        {
            ILayout layout;
            if (type.ToLower() == "simplelayout")
            {
                layout = new SimpleLayout();
            }
            else if (type.ToLower() == "xmllayout")
            {
                layout = new XmlLayout();
            }
            else
            {
                throw new InvaliLayoutTypeException();
            }
            return layout;
        }
    }
}
