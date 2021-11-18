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

        protected readonly Basket[] myBaskets = new Basket[10];
        #endregion


        protected User(string myInfo, IUserManagerForUser myUserManager)
        {
            if (myUserManager == null)
            {
                throw new Exception("Can't create 'ClassicUser' instance - object should belong to any UserManager");
            }
            this.myUserManager = myUserManager;

            List<string> initialisationParameters = new List<string>(myInfo.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries));
            try
            {
                this.Name = initialisationParameters[0];
                this.Surname = initialisationParameters[1];
                this.Email = initialisationParameters[2];
                this.Adress = initialisationParameters[3];
                this.CardDetails = initialisationParameters[4];
                this.Login = initialisationParameters[5];
                this.Password = initialisationParameters[6];
                this.DateOfBirdth = DateTime.Parse(initialisationParameters[7]);

                for (int i = 0; i < 10; i++)
                {
                    myBaskets[i] = new Basket(this, i + 1);
                }
            }
            catch (Exception)
            {
                throw new Exception("Can't create 'ClassicUser' instance - invalid initialisation parameters");
            }
        }


        public void DeleteMyAccount() 
        {
            myUserManager.DeleteUser(this);
        }

        public abstract void ChangeMyInfo(string newInfo);

        public List<IProduct> SearchProducts(string searchingParameters) 
        {
            return this.myUserManager.GetAccessToStorageManager().SearchProducts(searchingParameters);
        }

        public List<IProduct> ShowBasketProducts(int basketNumber) 
        {
            return myBaskets[basketNumber].GetProducts();
        }

        public void AddProductToBasket(int basketNumber, IProduct product, int count)
        {
            myBaskets[basketNumber].AddProduct(product, count);
        }

        public void RemoveProductFromBasket(int basketNumber, IProduct product, int count)
        {
            myBaskets[basketNumber].RemoveProduct(product, count);
        }

    }
}
