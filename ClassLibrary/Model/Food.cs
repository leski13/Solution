using System;

namespace ClassLibrary.Model
{
    [Serializable]
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Proteins { get; set; } //белки
        public double Fats { get; set; }//жиры
        public double Carbohydrates { get; set; }//углеводы
        /// <summary>
        /// calories of 100 gram 
        /// </summary>
        public double Calories { get; set; }

        public Food() { }

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
