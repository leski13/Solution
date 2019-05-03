using ClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary.Controller
{
    public class DatabaseDataSaver : IDataSaver
    {
        public List<T> Load<T>() where T:class
        {
            using (var db = new FitnessController())
            {
                var result = db.Set<T>().Where(l => true).ToList();
                return result;
            }
        }

        public void Save<T>(List<T> item) where T:class
        {
            using (var db = new FitnessController())
            {
                db.Set<T>().AddRange(item);
                db.SaveChanges();
                        
            }
        }
    }
}
