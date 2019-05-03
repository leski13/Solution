using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary.Model
{
    [Serializable]
    public class Eating
    {
        public int Id { get; set; }
        public DateTime Moment { get; set; }//when eating
        public Dictionary<Food, double> Foods { get; set; }//what eating

        public int UserId { get; set; }

        public virtual User User { get; set; }// Who eating

        public Eating() { }

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
