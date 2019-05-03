using System;
using System.Collections;
using System.Collections.Generic;

namespace ClassLibrary.Model
{
    /// <summary>
    /// User
    /// </summary>
    [Serializable]
    public class User
    {
        #region Property (свойства)
        public int Id { get; set; }
        /// <summary>
        /// name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// gender
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// birthdate
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// вес
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// рост
        /// </summary>
        public double Height { get; set; } 

        public virtual ICollection<Eating> Eatings { get; set; }
        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
        #endregion
        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="name"> Имя.</param>
        /// <param name="gender">Пол.</param>
        /// <param name="birthdate">Дата рождения.</param>
        /// <param name="weight">Вес.</param>
        /// <param name="height">Рост.</param>
        public User(string name, Gender gender, DateTime birthdate, double weight, double height)
        {
            #region Check condition (Проверка условий)
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("User's name cannot empty or null", nameof(name));
            }

            if (birthdate<DateTime.Parse("01.01.1900") || birthdate >=DateTime.Now)
            {
                throw new ArgumentNullException("Error birthdate", nameof(birthdate));
            }
            if(weight<=0 || weight>200)
            {
                throw new ArgumentNullException("Weight cann't =<0 or >200", nameof(weight));
            }
            if(height <= 0 || height > 300)
            {
                throw new ArgumentNullException("Height cann't =<0 or >300", nameof(height));
            }
            #endregion
            

            Name = name;
            Gender = gender ?? throw new ArgumentNullException("Gender cann't null", nameof(gender));
            BirthDate = birthdate;
            Weight = weight;
            Height = height;
        }
        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("User's name cannot empty or null", nameof(name));
            }
            Name = name;
        }
        public User() { }
        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
