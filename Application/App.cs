using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class App
    {
        static public List<User> UserData { get; set; }
        static public List<Project> ProjectsData { get; set; }

        public App()
        {
            UserData = new List<User>()
            {
                new User { Id = 1 , Name = "Alice"},
                new User  {Id = 2, Name = "Bob"}
            };

            ProjectsData = new List<Project>()
            {
              new Project { Id = 1, Title = "moonshot"},
              new Project { Id = 2, Title = "apollo " }
            };

            ProjectsData[0].Posts.Add(
                new Post { UserId = 1, Message = "Im working on it :)" }
                );

            ProjectsData[0].Posts.Add(
                new Post { UserId = 2, Message = "Awesome, I'll start on the forgotten password screen " }
                );

            ProjectsData[0].Followers.Add(
                    UserData[1]
                );

        }

        public void Events(string input)
        {
            if (input.Contains("@"))
            {
                DoPosts(input);
            }
            else if (input.Contains("follows"))
            {
                AssignFollower(input);
            }
            else if (input.Contains("wall"))
            {
                PrintWall(input);
            }
            else
            {
                PrintProjectDetails(input);
            }

        }

        public void DoPosts(string input)
        {
            // fetch user
            var user = Getuser(input);

            // fetch project
            var project = GetProject(input);

            var stringData = input.Split(" ");
            // we have to forloop to fetch the message as we are splitting by string;
            var printedMessage = "";
            for (var i = 3; i < stringData.Length; i++)
            {
                printedMessage += $"{stringData[i]} ";
            }

            // submit data
            project.Posts.Add(new Post
            {
                UserId = user.Id,
                Message = printedMessage
            });
        }

        public void AssignFollower(string input)
        {
            var user = Getuser(input);
            var stringData = input.Split(" ");
            var projectName = stringData[2];
            var project = ProjectsData.FirstOrDefault(x => x.Title == projectName);

            project.Followers.Add(user);
        }

        public void PrintWall(string input)
        {
            var user = Getuser(input);
            // project that the user follows.

            var projects = ProjectsData.Where(p => p.Followers.FirstOrDefault(f => f.Id == user.Id) != null).ToList();
            foreach (var project in projects)
            {
                foreach (var post in project.Posts)
                {
                    var currentUser = UserData.FirstOrDefault(x => x.Id == post.UserId);
                    Console.WriteLine(currentUser.Name);
                    Console.WriteLine(post.Message);
                }
            }
            
        }

        public void PrintProjectDetails(string input)
        {
            // fetch project
            var project = ProjectsData.FirstOrDefault(x => x.Title == input);

            foreach (var data in project.Posts)
            {
                // fetch user first
                var user = UserData.FirstOrDefault(x => x.Id == data.UserId);
                Console.WriteLine(user.Name);
                Console.WriteLine(data.Message);
            }
        }

        public User Getuser(string input)
        {
            // fetch user
            var stringData = input.Split(" ");
            var userIndex = UserData.FindIndex(x => x.Name == stringData[0]);
            return UserData[userIndex];
        }

        public Project GetProject(string input)
        {
            var stringData = input.Split(" ");
            var projectName = stringData[2].Split("@")[1];
            var projectIndex = ProjectsData.FindIndex(x => x.Title == projectName);

            return ProjectsData[projectIndex];
        }
    }
}
