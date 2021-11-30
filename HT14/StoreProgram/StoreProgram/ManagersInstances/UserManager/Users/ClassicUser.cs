using System;
using System.Collections.Generic;
using System.Text;

namespace StoreProgram
{
    class ClassicUser : User
    {
        public override void ChangeMyInfo(string newInfo)
        {
            string tempName;
            string tempSurname;
            string tempEmail;
            string tempAdress;
            string tempCardDetails;
            string tempLogin;
            string tempPassword;
            DateTime tempDateOfBirdth;

            List<string> initialisationParameters = new List<string>(newInfo.Split(new char['|'], StringSplitOptions.RemoveEmptyEntries));
            try
            {
                tempName = initialisationParameters[0];
                tempSurname = initialisationParameters[1];
                tempEmail = initialisationParameters[2];
                tempAdress = initialisationParameters[3];
                tempCardDetails = initialisationParameters[4];
                tempLogin = initialisationParameters[5];
                tempPassword = initialisationParameters[6];
                tempDateOfBirdth = DateTime.Parse(initialisationParameters[7]);
            }
            catch (Exception)
            {
                throw new Exception("Can't change 'ClassicUser' instance - invalid initialisation parameters");
            }


            this.Name = tempName;
            this.Surname = tempSurname;
            this.Email = tempEmail;
            this.Adress = tempAdress;
            this.CardDetails = tempCardDetails;
            this.Login = tempLogin;
            this.Password = tempPassword;
            this.DateOfBirdth = tempDateOfBirdth;
        }

        public ClassicUser((string, IUserManagerForUser, UserType) paramsForReinit) : base(paramsForReinit) { }

        public ClassicUser(string myInfo, IUserManagerForUser myUserManager) : base(myInfo, myUserManager, UserType.ClassicUser) { }
    }
}
