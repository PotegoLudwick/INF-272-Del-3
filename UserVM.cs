using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Deliverable_2_WireFrames.Models;

namespace Deliverable_2_WireFrames.ViewModels
{
    public class UserVM
    {
        public User user;
        public void RefreshGUID(OnlinePharmacyEntities db)
        {
            db.Configuration.ProxyCreationEnabled = false;
            user.GUID = Guid.NewGuid().ToString();
            user.GUIDExpiry = DateTime.Now.AddMinutes(30);
            int guids = db.Users.Where(usr => usr.GUID == user.GUID).Count();
            if (guids > 0)
                RefreshGUID(db);
            else
            {
                var u = db.Users.Where(zz => zz.UserID == user.UserID).FirstOrDefault();
                db.Entry(u).CurrentValues.SetValues(user);
                db.SaveChanges();
            }
        }

        public bool IslogedIn(OnlinePharmacyEntities db)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var guids = db.Users.Where(usr => usr.GUID == user.GUID && usr.GUIDExpiry > DateTime.Now).Count();
            if (guids > 0)
                return true;
            return false;
        }

        public bool IslogedIn(OnlinePharmacyEntities db, string userGUID)
        {
            db.Configuration.ProxyCreationEnabled = false;
            user = db.Users.Where(usr => usr.GUID == userGUID && usr.GUIDExpiry > DateTime.Now).FirstOrDefault();
            if (user != null)
                return true;
            return false;
        }
    }
}
