using System;

namespace Domain.Models
{
    public class Post
    {
        public int UserId { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt {get; set; }
    }
}