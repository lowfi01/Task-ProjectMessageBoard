using Application.Common;
using DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class FollowHandler
    {
        public void AssignFollower(string input)
        {
            var user = Utility.Getuser(input);
            var stringData = input.Split(" ");
            var projectName = stringData[2];
            var project = DbContext.ProjectsData.FirstOrDefault(x => x.Title == projectName);

            project.Followers.Add(user);
        }
    }
}
