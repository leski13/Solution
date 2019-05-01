using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary.Model
{
    [Serializable]
    public class Eating
    {
        public DateTime Moment { get; }//when eating
        public Dictionary<Food, double> Foods { get; }//what eating
        public User User { get; }// Who eating

        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("User cann't empty value", nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }
        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));
            if(product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }
        }
    }
}
