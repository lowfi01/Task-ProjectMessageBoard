using System;
using System.Collections.Generic;
using System.Text;
using Application.Common;
using DataContext;
using Domain.Models;


namespace Application
{
    public class PostHandler
    {
        public void DoPosts(string input)
        {
            // fetch user
            var user = Utility.Getuser(input);

            // fetch project
            var project = Utility.GetProject(input);

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
                Message = printedMessage,
                CreatedAt = DateTime.Now,
            });
        }
    }
}
