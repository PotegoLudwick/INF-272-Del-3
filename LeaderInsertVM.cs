using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Deliverable_2_WireFrames.Models;

namespace Deliverable_2_WireFrames.ViewModels
{
    public class LeaderInsertVM
    {
        
        public int CommunityLeader_ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public string Position { get; set; }
        public virtual Village Village { get; set; }

        public string Email { get; set; }
    }
}