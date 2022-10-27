using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mvc_database_create_edit.Models
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext() :base("ConString")
        {
        }
        public DbSet<Student> Students { get; set; }
    }
}