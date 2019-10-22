using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Deliverable_2_WireFrames.Models;
namespace Deliverable_2_WireFrames.ViewModels
{
    public class LeaderVM
    {
        public int? CommunityLeaderID;
        public List<User> users;
        public UserVM userVM;

    }
}