using System;
using System.Collections.Generic;
using System.Text;

namespace StoreProgram
{
    class View
    {
        private Store _store = null;
        private UserManager _userManager = null;
        private StorageManager _storageManager = null;
        private AdminManager _adminManager = null;


        public View() 
        {
            UserManager.InitUserManager();
            AdminManager.InitAdminManager();

            Store.InitStore(UserManager.GetInstance(), StorageManager.GetInstance(), AdminManager.GetInstance(), PendingOrderManager.GetInstance());
            this._store = Store.GetInstance();

            _userManager = UserManager.GetInstance();
            _userManager.SetMainStore(_store);

            _adminManager = AdminManager.GetInstance();
            _adminManager.SetMainStore(_store);
        }

        public void SetManagementSchool(IAbstractSchool abstractSchool) 
        {
            _adminManager.ManagmentSchool = abstractSchool;
        }

        public bool RegisterUser(UserType typeToCreate, string initParameters)
        {
            string loginToRegister = initParameters.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries)[5];
            if (this._adminManager.IsLoginUsed(loginToRegister) || this._userManager.IsLoginUsed(loginToRegister))
            {
                return false;
            }

            this._userManager.RegisterNewUser(typeToCreate, initParameters);
            return true;
        }
        public bool RegisterModerator(string name, string login, string password, string VerifyAdminRegistration)
        {
            if (this._adminManager.IsLoginUsed(login) || this._userManager.IsLoginUsed(login)) 
            {
                return false;
            }

            this._adminManager.RegisterNewModerator(name, login, password, VerifyAdminRegistration);
            return true;
        }
        public bool RegisterAdministrator(string name, string login, string password, string VerifyAdminRegistration)
        {
            if (this._adminManager.IsLoginUsed(login) || this._userManager.IsLoginUsed(login))
            {
                return false;
            }

            this._adminManager.RegisterNewAdministrator(name, login, password, VerifyAdminRegistration);
            return true;
        }

        public object SignIn(string login, string password)
        {
            object account = null;

            account ??= _userManager.SignIn(login, password);
            account ??= _adminManager.SingInModerator(login, password);
            account ??= _adminManager.SingInAdministrator(login, password);

            return account;
        }

    }
}
