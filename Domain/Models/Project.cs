using System.Collections.Generic;

namespace Domain.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<User> Followers { get; set; } = new List<User>();
        public List<Post> Posts { get; set; } = new List<Post>();
    }
}