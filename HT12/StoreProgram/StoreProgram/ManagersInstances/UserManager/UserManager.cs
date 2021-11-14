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
        ISearchByAllStoragesManager GetAccessToStorageManager();
        void DeleteUser(User userToRemove);
    }

    class UserManager: IUserManagerForUser
    {
        private static UserManager userManager = null;
        public Store myStore = null;
        private List<User> users = null;

        private UserManager() 
        {
            users = new List<User>();
        }

        public static void InitUserManager() 
        {
            userManager = new UserManager();
        }

        public void SetMainStore(Store myStore) 
        {
            this.myStore = myStore;
        }

        public static UserManager GetInstance() 
        {
            if (userManager == null)
            {
                throw new Exception("Error in 'UserManager' class\nImpossible to get instance of the UserManager - 'userManager' is uninitialised.");
            }

            return userManager;
        }

        public ISearchByAllStoragesManager GetAccessToStorageManager()
        {
            return myStore.storageManager;
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
                else if (true)
                {

                }
            }
            catch (Exception ex) 
            {
                throw new Exception("User magager didn't create a new user - " + ex.Message);
            }
        }

        public User SignIn(string login, string password) 
        {
            return users.Find((u) => (u.Login == login && u.Password == password));
        }
    }
}
