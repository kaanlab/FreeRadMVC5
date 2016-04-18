using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeRadMVC5.Models
{
    public interface IFreeRadRepository : IDisposable
    {
        IEnumerable<User> GetAllUsers();
        void AddUser(User newUser);
        User FindUser(int? userId);
        void EditUser(User user);
        void DeleteUser(int userId);

        IEnumerable<UserAttribute> GetAllUserAttributes();
        void AddUserAttr(UserAttribute newUserAttr);
        UserAttribute FindUserAttr(int? userAttrId);
        void EditUserAttr(UserAttribute userAttr);
        void DeleteUserAttr(int userAttrId);

        IEnumerable<Group> GetAllGroups();
        void AddGroup(Group newGroup);
        Group FindGroup(int? groupId);
        void EditGroup(Group group);
        void DeleteGroup(int groupId);

        IEnumerable<GroupAttribute> GetAllGroupAttributes();
        void AddGroupAttr(GroupAttribute newGroupAttr);
        GroupAttribute FindGroupAttr(int? groupAttrId);
        void EditGroupAttr(GroupAttribute groupAttr);
        void DeleteGroupAttr(int groupAttrId);

        IEnumerable<UserGroup> GetAllUsersInGroup();
        void AddUserToGroup(UserGroup newUser);
        UserGroup FindUserInGroup(int? userId);
        void EditUserInGroup(UserGroup user);
        void DeleteUserFromGroup(int userId);

        IEnumerable<Nas> GetAllNas();
        void AddNas(Nas newNas);
        Nas FindNas(int? nasId);
        void EditNas(Nas nas);
        void DeleteNas(int nasId);

        IEnumerable<AccessLog> GetAllLogsOderByIdDes();
        AccessLog FindLog(int? logId);
        void DeleteLog(int logId);

        void SaveAll();
    }
}
