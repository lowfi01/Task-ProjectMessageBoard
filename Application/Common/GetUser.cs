using DataContext;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common
{
    public static class Utility
    {
        public static User Getuser(string input)
        {
            // fetch user
            var stringData = input.Split(" ");
            var userIndex = DbContext.UserData.FindIndex(x => x.Name == stringData[0]);
            return DbContext.UserData[userIndex];
        }
        public static Project GetProject(string input)
        {
            var stringData = input.Split(" ");
            var projectName = stringData[2].Split("@")[1];
            var projectIndex = DbContext.ProjectsData.FindIndex(x => x.Title == projectName);

            return DbContext.ProjectsData[projectIndex];
        }
    }
}
