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
        public Address personAddress { get; set; }

        //--------- Methods ---------//
        public Person(string firstName, string lastName, string email, string phoneNum, 
            string streetAddress, string city, string province, string postalCode)
        {
            this.personID = 1;
            this.firstName = firstName;
            this.lastName = lastName;
            Address temp = new Address(streetAddress, city, province, postalCode);
            personAddress = temp;
            this.phoneNum = phoneNum;

            if(ValidateEmail(email))
            {
                this.email = email;
            }
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
    }
}
