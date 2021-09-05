using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataContext
{
    public static class DbContext
    {
        static public List<User> UserData { get; set; }
        static public List<Project> ProjectsData { get; set; }
    }
}
