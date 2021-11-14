using System;
using System.Collections.Generic;
using System.Text;

namespace StoreProgram
{
    abstract class User
    {
        #region user Fields
        protected string name;
        public string Name
        {
            get { return name; }
            protected set { name = value; }
        }

        protected string surname;
        public string Surname
        {
            get { return surname; }
            protected set { surname = value; }
        }

        protected string email;
        public string Email
        {
            get { return email; }
            protected set { email = value; }
        }

        protected string adress;
        public string Adress
        {
            get { return adress; }
            protected set { adress = value; }
        }

        protected string cardDetails;
        public string CardDetails
        {
            get { return cardDetails; }
            protected set { cardDetails = value; }
        }

        protected string login;
        public string Login
        {
            get { return login; }
            protected set { login = value; }
        }

        protected string password;
        public string Password
        {
            get { return password; }
            protected set { password = value; }
        }

        protected DateTime dateOfBirdth;
        public DateTime DateOfBirdth
        {
            get { return dateOfBirdth; }
            protected set { dateOfBirdth = value; }
        }

        protected IUserManagerForUser myUserManager;

        //private List<Basket> myBaskets = null;
        #endregion


        public void DeleteMyAccount() 
        {
            myUserManager.DeleteUser(this);
        }

        public abstract void ChangeMyInfo(string newInfo);

        public List<IProduct> SearchProducts(string searchingParameters) 
        {
            return this.myUserManager.GetAccessToStorageManager().SearchProducts(searchingParameters);
        }
    }
}
