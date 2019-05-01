using System;

namespace ClassLibrary.Model
{
    [Serializable]
    public class Activity
    {
        public string Name { get; }
        public double CalorisePerMinutes { get; }

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
