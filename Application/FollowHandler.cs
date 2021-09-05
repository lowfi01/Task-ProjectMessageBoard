using Application.Commands;
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
        public void AssignFollower(FollowCommand cmd)
        {
            var projectName = cmd.StringData[2];
            var project = DbContext.ProjectsData.FirstOrDefault(x => x.Title == projectName);
            Console.WriteLine($"{cmd.User.Name} Now follow {project.Title}");

            project.Followers.Add(cmd.User);
        }
    }
}
