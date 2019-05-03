using System;
using System.Collections.Generic;

namespace ClassLibrary.Model
{
    [Serializable]
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }

        public double CalorisePerMinutes { get; set; }

        public Activity() { }
        public Activity(string name, double caloriesPerMinutes)
        {
            //Check
            Name = name;
            CalorisePerMinutes = caloriesPerMinutes;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
