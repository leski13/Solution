using System;

namespace ClassLibrary.Model
{
    /// <summary>
    /// Пол.
    /// </summary>
    [Serializable]
    public class Gender
    {
        public int Id { get; set; }
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Создать новый пол
        /// </summary>
        /// <param name="name"> Имя пола  </param>

        public Gender() { }


        public Gender(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пола не правильно введено", nameof(name));

            }
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
