using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace UpdatedParty.Models
{
    public class UserRepository
    {
        //
        //Create User
        //
        public MembershipUser CreateUser(string username, string password, string email)
        {
            using (UpdatedPartyDB db = new UpdatedPartyDB())
            {
                Bar user = new Bar();

                user.BarName = username;
                user.Email = email;
                user.Pass = password;
                //user.Promotion = "";
                //user.Event = "";
                user.BarSchedule = "";
                user.Price = null;
                user.BarService = "";
                user.WebSite = "";
                user.MusicGender = "";
                user.Payment = "";
                user.Review = "";
                user.Street = "";
                user.Cologne = "";
                user.Township = "";
                TState state = db.TStates.Find(1);
                user.TState = state;
                user.Country = "";
                user.RegisterDate = DateTime.Now;
                UserType usertype = db.UserTypes.Find(1);
                StatusType statustype = db.StatusTypes.Find(1);
                user.UserType = usertype;
                user.StatusType = statustype;
                //user.PasswordSalt = "1234";
                //user.CreatedDate = DateTime.Now;
                //user.IsActivated = false;
                //user.IsLockedOut = false;
                //user.LastLockedOutDate = DateTime.Now;
                //user.LastLoginDate = DateTime.Now;
                db.Bars.Add(user);
                db.SaveChanges();

                return GetUser(username);
            }
        }

        public string GetUserNameByEmail(string email)
        {
            using (UpdatedPartyDB db = new UpdatedPartyDB())
            {
                var result = from u in db.Bars where (u.Email == email) select u;

                if (result.Count() != 0)
                {
                    var dbuser = result.FirstOrDefault();

                    return dbuser.BarName;
                }
                else
                {
                    return "";
                }
            }
        }

        public MembershipUser GetUser(string username)
        {
            using (UpdatedPartyDB db = new UpdatedPartyDB())
            {
                var result = from u in db.Bars where (u.BarName == username) select u;

                if (result.Count() != 0)
                {
                    var dbuser = result.FirstOrDefault();

                    string _username = dbuser.BarName;
                    int _providerUserKey = dbuser.BarID;
                    string _email = dbuser.Email;
                    string _passwordQuestion = "";
                    string _comment = "";
                    bool _isApproved = true;
                    bool _isLockedOut = false;
                    DateTime _creationDate = dbuser.RegisterDate;
                    DateTime _lastLoginDate = dbuser.RegisterDate;
                    DateTime _lastActivityDate = DateTime.Now;
                    DateTime _lastPasswordChangedDate = DateTime.Now;
                    DateTime _lastLockedOutDate = dbuser.RegisterDate;

                    MembershipUser user = new MembershipUser("CustomMembershipProvider",
                                                              _username,
                                                              _providerUserKey,
                                                              _email,
                                                              _passwordQuestion,
                                                              _comment,
                                                              _isApproved,
                                                              _isLockedOut,
                                                              _creationDate,
                                                              _lastLoginDate,
                                                              _lastActivityDate,
                                                              _lastPasswordChangedDate,
                                                              _lastLockedOutDate);

                    return user;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}