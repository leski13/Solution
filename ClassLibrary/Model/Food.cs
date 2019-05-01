using System;

namespace ClassLibrary.Model
{
    [Serializable]
    public class Food
    {
        public string Name { get; }
        public double Proteins { get; } //белки
        public double Fats { get; }//жиры
        public double Carbohydrates { get; }//углеводы
        /// <summary>
        /// calories of 100 gram 
        /// </summary>
        public double Calories { get; }

        public Food(string name) : this (name, 0,0,0,0) { }

        public Food(string name, double proteins, double fats, double carbohydrates, double calories)
        {
            //TODO: check
            Name = name;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            Calories = calories / 100.0;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
