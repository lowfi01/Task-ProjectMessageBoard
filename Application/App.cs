using Application.Common;
using DataContext;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class App
    {
        public App()
        {
            DbContext.UserData = new List<User>()
            {
                new User { Id = 1 , Name = "Alice"},
                new User  {Id = 2, Name = "Bob"}
            };

            DbContext.ProjectsData = new List<Project>()
            {
              new Project { Id = 1, Title = "moonshot"},
              new Project { Id = 2, Title = "apollo" }
            };

            DbContext.ProjectsData[0].Posts.Add(
                new Post { UserId = 1, Message = "Im working on it :)", CreatedAt = DateTime.Now }
                );

            DbContext.ProjectsData[0].Posts.Add(
                new Post { UserId = 2, Message = "Awesome, I'll start on the forgotten password screen ", CreatedAt = DateTime.Now }
                );

            DbContext.ProjectsData[0].Followers.Add(
                    DbContext.UserData[1]
                );

        }

        public void StateManagement(string input)
        {

            if (input.Contains("@"))
            {
                new PostHandler().DoPosts(input);
            }
            else if (input.Contains("follows"))
            {
                new FollowHandler().AssignFollower(new Commands.FollowCommand 
                { 
                    User = Utility.Getuser(input), 
                    StringData = input.Split(" ")
                });
            }
            else if (input.Contains("wall"))
            {
                new WallHandler().PrintWall(input);
            }
            else
            {
                new ProjectDetailHandler().PrintProjectDetails(input);
            }

        }

    }
}
