using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAG_OrderAndTrip
{
    public class Employee : Person
    {
        //--------- Attributes ---------//
        private int employeeID;         // Key
        //private string password;
        private int roleID;

        private static Dictionary<int,string> validRoles = new Dictionary<int, string>()
        {
            { 0, "Buyer" },
            { 1, "Planner" },
            { 2, "Admin"}
        };

        public Employee
            (string roleID, string firstName, string lastName, string email, string phoneNum, 
            string streetAddress, string city, string province, string postalCode) : 
            base(firstName, lastName, email, phoneNum, streetAddress, city, province, postalCode)
        {
            int possibleRole = ValidateRole(roleID);
            if(possibleRole != -1)
            {
                this.roleID = possibleRole;
            }
        }

        private static int ValidateRole(string newRoleID)
        {
            int isValid = -1;

            foreach(var role in validRoles)
            {
                if(newRoleID == role.Value)
                {
                    isValid = role.Key;
                    break;
                }
            }

            return isValid;
        }
    }
}
