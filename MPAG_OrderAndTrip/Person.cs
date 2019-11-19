 using System;
using System.Net.Mail;

namespace MPAG_OrderAndTrip
{
    public class Person
    {
        //--------- Attributes ---------//
        public int personID { get; set; }           // Key
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNum { get; set; }
        public string email { get; set; }
        public string address{get; set;}

        public Person(string firstName, string lastName, string email, string address, string phoneNum)
        {
            this.personID = 1;
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.phoneNum = phoneNum;

            if(ValidateEmail(email))
            {
                this.email = email;
            }
        }

        public Person()
        {
        }

        // Reference: https://stackoverflow.com/questions/5342375/regex-email-validation
        private static bool ValidateEmail(string email)
        {
            try
            {
                MailAddress verify = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        // Setters -------------------------//
        // How does this work with a database -> Is it updated first here and then in the DB?
        public void ChangeEmail(string newEmail)
        {
            if(ValidateEmail(newEmail))
            {
                email = newEmail;
            }
        }

        public void GetPersonInfo()
        {
            new TMSDAL().SearchForCustomer(this);
        }
    }
}
