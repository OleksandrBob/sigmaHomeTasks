using System;
using System.Collections.Generic;
using System.Text;

namespace StoreProgram
{    
    enum UserType 
    {
        ClassicUser,
        VIPUser
    }

    interface IUserManagerForUser
    {
        IStorageManagerForUser GetAccessToStorageManager(User user);
        IAddOrderToManager GetAccessToOrderManager(User user);

        void DeleteUser(User userToRemove);
    }

    interface IUserManagerForAdministrator 
    {
        void ChangeStatus(User user, UserType newType);
        List<User> WatchAllUsers();
    }

    class UserManager: IUserManagerForUser, IUserManagerForAdministrator
    {
        private static UserManager userManager = null;
        private Store myStore = null;
        private List<User> users = null;
        private IAbstractSchool schoolForStaffCreation = null;

        private UserManager() 
        {
            users = new List<User>();
        }

        public static void InitUserManager() 
        {
            userManager = new UserManager();
        }

        public void SetSchool(IAbstractSchool school) 
        {
            this.schoolForStaffCreation = school;
        }

        public void SetMainStore(Store myStore) 
        {
            this.myStore = myStore;
        }

        public static UserManager GetInstance() 
        {
            return userManager ?? throw new Exception("Error in 'UserManager' class\nImpossible to get instance of the UserManager - 'userManager' is uninitialised.");
        }

        public IStorageManagerForUser GetAccessToStorageManager(User user)
        {
            if (!users.Contains(user))
            {
                return null;//user, that maid a request was deleted or uninitialised yet - can`t give an access
            }

            return myStore.storageManager;
        }

        public IAddOrderToManager GetAccessToOrderManager(User user) 
        {
            if (!users.Contains(user))
            {
                return null;//user, that maid a request was deleted or uninitialised yet - can`t give an access
            }

            return this.myStore.pendingOrderManager;
        }

        public void DeleteUser(User userToRemove) 
        {
            users.Remove(userToRemove);
        }

        public void RegisterNewUser(UserType typeToCreate, string initParameters) 
        {
            try
            {
                if (typeToCreate == UserType.ClassicUser)
                {
                    users.Add(new ClassicUser(initParameters, this));
                }
                else if (typeToCreate == UserType.VIPUser)
                {
                    users.Add(new VIPUser(initParameters, this));
                }
            }
            catch (Exception ex) 
            {
                throw new Exception("User manager didn't create a new user - " + ex.Message);
            }
        }

        public User SignIn(string login, string password) 
        {
            return users.Find((u) => (u.Login == login && u.Password == password));
        }

        public void ChangeStatus(User user, UserType newType) 
        {
            User newUserObject = null;

            if (newType == UserType.ClassicUser)
            {
                try
                {
                    newUserObject = new ClassicUser(user.GetMyFullInfo());
                }
                catch (Exception)
                {
                    return;//Error ocured - reinitialisation failed
                }
            }
            else if (newType == UserType.VIPUser)
            {
                try
                {
                    newUserObject = new VIPUser(user.GetMyFullInfo());
                }
                catch (Exception)
                {
                    return;//Error ocured - reinitialisation failed
                }
            }


            if ((!this.users.Remove(user)) || newType == user.myType)
            {
                return;//No sense to update user status
            }

            this.users.Add(newUserObject);

        }

        public List<User> WatchAllUsers()
        {
            return this.users;
        }
    }
}
