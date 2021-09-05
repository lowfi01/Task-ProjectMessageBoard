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

            // Attempt at some functional programming :(
            var messageList = DbContext.ProjectsData
                .Where(p => p.Followers.FirstOrDefault(f => f.Id == user.Id) != null)
                .SelectMany(p => p.Posts, (project, post) => new { project, post })
                .OrderByDescending(projectAndPost => projectAndPost.post.CreatedAt).ToList();

            messageList.ForEach(projectAndPost => Console.WriteLine($"{projectAndPost.project.Title} - User Id: {projectAndPost.post.UserId}: {projectAndPost.post.Message} ({projectAndPost.post.CreatedAt})"));

        }
    }
}
