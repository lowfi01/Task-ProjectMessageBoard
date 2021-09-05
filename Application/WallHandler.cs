using Application.Common;
using DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class WallHandler
    {
        public void PrintWall(string input)
        {
            var user = Utility.Getuser(input);
            // project that the user follows.

            var projects = DbContext.ProjectsData.Where(p => p.Followers.FirstOrDefault(f => f.Id == user.Id) != null).ToList();
            foreach (var project in projects)
            {
                foreach (var post in project.Posts)
                {
                    var currentUser = DbContext.UserData.FirstOrDefault(x => x.Id == post.UserId);
                    Console.WriteLine(currentUser.Name);
                    Console.WriteLine(post.Message);
                }
            }

        }
    }
}
