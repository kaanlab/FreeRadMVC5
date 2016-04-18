using Microsoft.Practices.Unity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeRadMVC5.Models
{
    public class FreeRadRepository : IFreeRadRepository
    {
        private bool disposed;
        private MySqlContext _context;

        public FreeRadRepository(MySqlContext context)
        {
            _context = context;
            
            //_context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }


        #region User

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();

        }

        public void AddUser(User newUser)
        {
            _context.Users.Add(newUser);
        }

        public User FindUser(int? userId)
        {
            return _context.Users.Find(userId);
        }

        public void EditUser(User user)
        {
            var mySqlParams = new MySqlParameter[] 
                {
                    new MySqlParameter("@id", user.Id),
                    new MySqlParameter("@username", user.UserName),
                    new MySqlParameter("@attribute", user.Attribute),
                    new MySqlParameter("@op", user.Op),
                    new MySqlParameter("@value", user.Value),
                };

            _context
                .Database
                .ExecuteSqlCommand("UPDATE radius.radcheck SET username = @username, attribute = @attribute, op = @op, value = @value WHERE id = @id", mySqlParams);
        }

        public void DeleteUser(int userId)
        {
            _context
                .Database
                .ExecuteSqlCommand("DELETE FROM radius.radcheck WHERE id = @id", new MySqlParameter("@id", userId));
        }

        #endregion


        #region UserAttr

        public IEnumerable<UserAttribute> GetAllUserAttributes()
        {
            return _context.UserAttributes.ToList();
        }

        public void AddUserAttr(UserAttribute newUserAttr)
        {
            _context.UserAttributes.Add(newUserAttr);
        }

        public UserAttribute FindUserAttr(int? userAttrId)
        {
            return _context.UserAttributes.Find(userAttrId);
        }

        public void EditUserAttr(UserAttribute userAttr)
        {
            var mySqlParams = new MySqlParameter[] 
                {
                    new MySqlParameter("@id", userAttr.Id),
                    new MySqlParameter("@username", userAttr.UserName),
                    new MySqlParameter("@attribute", userAttr.Attribute),
                    new MySqlParameter("@op", userAttr.Op),
                    new MySqlParameter("@value", userAttr.Value),
                };

            _context
                .Database
                .ExecuteSqlCommand("UPDATE radius.radreply SET username = @username, attribute = @attribute, op = @op, value = @value WHERE id = @id", mySqlParams);
        }

        public void DeleteUserAttr(int userAttrId)
        {
            _context
               .Database
               .ExecuteSqlCommand("DELETE FROM radius.radreply WHERE id = @id", new MySqlParameter("@id", userAttrId));
        }

        #endregion


        #region Group

        public IEnumerable<Group> GetAllGroups()
        {
            return _context.Groups.ToList();

        }

        public void AddGroup(Group newGroup)
        {
            _context.Groups.Add(newGroup);
        }

        public Group FindGroup(int? groupId)
        {
            return _context.Groups.Find(groupId);
        }

        public void EditGroup(Group group)
        {
            var mySqlParams = new MySqlParameter[] 
                    {
                        new MySqlParameter("@id", group.Id),
                        new MySqlParameter("@groupname", group.GroupName),
                        new MySqlParameter("@attribute", group.Attribute),
                        new MySqlParameter("@op", group.Op),
                        new MySqlParameter("@value", group.Value),
                    };

            _context
                .Database
                .ExecuteSqlCommand("UPDATE radius.radgroupcheck SET groupname = @groupname, attribute = @attribute, op = @op, value = @value WHERE id = @id", mySqlParams);
        }

        public void DeleteGroup(int groupId)
        {
            _context
               .Database
               .ExecuteSqlCommand("DELETE FROM radius.radgroupcheck WHERE id = @id", new MySqlParameter("@id", groupId));
        }

        #endregion


        #region GroupAttr

        public IEnumerable<GroupAttribute> GetAllGroupAttributes()
        {
            return _context.GroupAttributes.ToList();
        }
        public void AddGroupAttr(GroupAttribute newGroupAttr)
        {
            _context.GroupAttributes.Add(newGroupAttr);
        }

        public GroupAttribute FindGroupAttr(int? groupAttrId)
        {
            return _context.GroupAttributes.Find(groupAttrId);
        }

        public void EditGroupAttr(GroupAttribute groupAttr)
        {
            var mySqlParams = new MySqlParameter[] 
                {
                    new MySqlParameter("@id", groupAttr.Id),
                    new MySqlParameter("@groupname", groupAttr.GroupName),
                    new MySqlParameter("@attribute", groupAttr.Attribute),
                    new MySqlParameter("@op", groupAttr.Op),
                    new MySqlParameter("@value", groupAttr.Value),
                };

            _context
                .Database
                .ExecuteSqlCommand("UPDATE radius.radgroupreply SET groupname = @groupname, attribute = @attribute, op = @op, value = @value WHERE id = @id", mySqlParams);
        }

        public void DeleteGroupAttr(int groupAttrId)
        {
            _context
                .Database
                .ExecuteSqlCommand("DELETE FROM radius.radgroupreply WHERE id = @id", new MySqlParameter("@id", groupAttrId));
        }

        #endregion


        #region UserGroup

        public IEnumerable<UserGroup> GetAllUsersInGroup()
        {
            

            return _context.UserGroups.ToList();
        }

        public void AddUserToGroup(UserGroup newUser)
        {
            _context.UserGroups.Add(newUser);
        }

        public UserGroup FindUserInGroup(int? userId)
        {
            return _context.UserGroups.Find(userId);
        }

        public void EditUserInGroup(UserGroup user)
        {
            var mySqlParams = new MySqlParameter[] 
                {
                    new MySqlParameter("@id", user.Id),
                    new MySqlParameter("@username", user.UserName),
                    new MySqlParameter("@groupname", user.GroupName),
                    new MySqlParameter("@priority", user.Priority)
                };

            _context
                .Database
                .ExecuteSqlCommand("UPDATE radius.radusergroup SET username = @username, groupname = @groupname, priority = @priority WHERE id = @id", mySqlParams);
        }

        public void DeleteUserFromGroup(int userId)
        {
            _context
                .Database
                .ExecuteSqlCommand("DELETE FROM radius.radusergroup WHERE id = @id", new MySqlParameter("@id", userId));
        }

        #endregion


        #region Nas

        public IEnumerable<Nas> GetAllNas()
        {
            return _context.Nases.ToList();
        }

        public void AddNas(Nas newNas)
        {
            _context.Nases.Add(newNas);
        }

        public Nas FindNas(int? nasId)
        {
            return _context.Nases.Find(nasId);
        }

        public void EditNas(Nas nas)
        {
            var mySqlParams = new MySqlParameter[] 
                {
                    new MySqlParameter("@id", nas.Id),
                    new MySqlParameter("@nasname", nas.NasName),
                    new MySqlParameter("@shortname", nas.ShortName),
                    new MySqlParameter("@type", nas.Type),
                    new MySqlParameter("@ports", nas.Ports),
                    new MySqlParameter("@secret", nas.Secret),
                    new MySqlParameter("@community", nas.Community),
                    new MySqlParameter("@description", nas.Description)
                };

            _context
                .Database
                .ExecuteSqlCommand("UPDATE radius.nas SET nasname = @nasname, shortname = @shortname, type = @type, ports = @ports, secret = @secret, community = @community, description = @description WHERE id = @id", mySqlParams);
        }

        public void DeleteNas(int nasId)
        {
            _context
                .Database
                .ExecuteSqlCommand("DELETE FROM radius.nas WHERE id = @id", new MySqlParameter("@id", nasId));
        }

        #endregion


        #region AccessLog

        public IEnumerable<AccessLog> GetAllLogsOderByIdDes()
        {
            return _context.AccessLogs.OrderByDescending(o => o.RadAcctId);
        }

        public AccessLog FindLog(int? logId)
        {
            return _context.AccessLogs.Find(logId);
        }

        public void DeleteLog(int logId)
        {
            _context
                .Database
                .ExecuteSqlCommand("DELETE FROM radius.radacct WHERE radacctid = @id", new MySqlParameter("@id", logId));
        }

        #endregion


        public void SaveAll()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }


    }
}