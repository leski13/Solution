﻿using ClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClassLibrary.Controller
{
    public class EatingController : ControllerBase
    {
        private readonly User user;

        public List<Food> Foods { get; }
        public Eating Eating { get; }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Username cann't empty value", nameof(user));
            Foods = GetAllFoods();
            Eating = GetEating();
        }
       
        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(p => p.Name == food.Name);
            if(product==null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }

        private Eating GetEating()
        {
            return Load<Eating>().FirstOrDefault() ?? new Eating(user);
        }
        private List<Food> GetAllFoods()
        {
            return Load<Food>() ?? new List<Food>();
        }
        private void Save()
        {
            Save(Foods);
            Save(new List<Eating>() { Eating });
        }
    }
}
