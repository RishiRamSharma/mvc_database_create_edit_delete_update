using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc_database_create_edit.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public int Age { get; set; }
    }
}