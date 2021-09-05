using DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class ProjectDetailHandler
    {
        public void PrintProjectDetails(string input)
        {
            // fetch project
            var project = DbContext.ProjectsData.FirstOrDefault(x => x.Title == input.ToLower());

            foreach (var data in project.Posts)
            {
                // fetch user first
                var user = DbContext.UserData.FirstOrDefault(x => x.Id == data.UserId);
                Console.WriteLine(user.Name);
                Console.WriteLine(data.Message);
            }
        }
    }
}
