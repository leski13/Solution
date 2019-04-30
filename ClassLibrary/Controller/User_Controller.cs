using ClassLibrary.Model;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClassLibrary.Controller
{
    /// <summary>
    /// Контроллер пользователя - User's controller
    /// </summary>
    public class User_Controller
    {
        /// <summary>
        /// User application
        /// </summary>
        public User User { get; }
        /// <summary>
        /// Create new user's controller - Создание нового контроллера пользователя. 
        /// </summary>
        /// <param name="user"></param>
        public User_Controller(string userName, string genderName, DateTime birthdate, double weight, double height)
        {
            //TODO: проверка 
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthdate, weight, height);
        }
        public User_Controller()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }
                // TODO: Что делать если пользователя не прочитали?(What do you do if user don't read?)              
            }
        }
        /// <summary>
        /// User's date save - Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }
        /// <summary>
        /// Получить данніе пользователя - User's date receive.
        /// </summary>
        /// <returns>User application - пользователь приложения.</returns>
        
    }
}
