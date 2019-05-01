using ClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClassLibrary.Controller
{
    /// <summary>
    /// Контроллер пользователя - User's controller
    /// </summary>
    public class User_Controller : ControllerBase
    {
        private const string USER_FILE = "users.dat";
        /// <summary>
        /// User application
        /// </summary>
        public List<User> Users { get; }
        public User CurrentUser { get; }
        public bool IsNewUser { get; } = false;
        /// <summary>
        /// Create new user's controller - Создание нового контроллера пользователя. 
        /// </summary>
        /// <param name="user"></param>
        public User_Controller(string userName)
        {
            if(string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("User's name cann't empty value", nameof(userName));
            }
            Users = GetUserData();
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);
            if(CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }
        /// <summary>
        /// Получить сохраненный список пользователей.
        /// </summary>
        /// <returns></returns>
        private List<User> GetUserData()
        {
            return Load<List<User>>(USER_FILE) ?? new List<User>();
        }
        public void SetNewUserData(string genderName, DateTime birthdate, double weight = 1, double height = 1)
        {
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthdate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }
        /// <summary>
        /// User's date save - Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            Save(USER_FILE, Users);
        }
    }
}
