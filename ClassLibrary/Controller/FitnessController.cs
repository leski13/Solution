
using ClassLibrary.Model;
using System.Data.Entity;

namespace ClassLibrary.Controller
{
    class FitnessController : DbContext
    {
        public FitnessController():base("DBConnection") { }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Eating> Eatings { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
