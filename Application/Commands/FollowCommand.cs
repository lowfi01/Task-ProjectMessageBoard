using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public class FollowCommand
    {
        public User User { get; set; }
        public string[] StringData { get; set; }
    }
}
