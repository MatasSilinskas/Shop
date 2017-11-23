using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB.Interfaces;
using WEB.Models;

namespace WEB.SettingsLogic
{
    
    public class RatingChosenEvent
    {
        public delegate void RatingAddedEventHandler(object source, EventArgs args);
        public event RatingAddedEventHandler RatingAdded;   
        public void Done()
        {
            OnRatingAdded();
        }
        protected virtual void OnRatingAdded()
        {
            RatingAdded?.Invoke(this, EventArgs.Empty);
        }
    }
}