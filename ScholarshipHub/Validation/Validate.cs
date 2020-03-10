using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ScholarshipHub.Validation
{
    internal class Validate
    {
     
       
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        

        [NonAction]
        public static bool IsNullOrWhiteSpace(string s)

        {

            if (s == null)

                return true;



            return (s.Trim() == string.Empty);

        }

        [NonAction]
        public static bool name(string n)
        {
            if (!IsNullOrWhiteSpace(n))
            {

                string s = n.Replace("-", "");
                s = n.Replace(".", "");
                s = s.Replace(" ", "");
                if (s.All(char.IsLetter))
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        
        

        [NonAction]
        public static bool pass(string n)
        {

            if (!IsNullOrWhiteSpace(n))
            {
                if (n.Length >= 6)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        [NonAction]
        public static bool letter(string s)
        {
            if (s.All(char.IsLetter))
            {
                return true;
            }
            return false;
        }

        [NonAction]
        public static bool digit(string s)
        {
            if (s.All(char.IsDigit))
            {
                return true;
            }
            return false;
        }

        [NonAction]
        public static bool un(string n)
        {
            if (!IsNullOrWhiteSpace(n))
            {
                string s = n.Replace(".", "");
                s = s.Replace("_", "");
                if (s.All(char.IsLetterOrDigit))
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        [NonAction]
        public static bool day(string n)
        {
            if (!IsNullOrWhiteSpace(n) && n.All(char.IsDigit) && Convert.ToInt32(n) < 32)
            {
                return true;
            }
            return false;
        }
        public static bool month(string n)
        {
            if (!IsNullOrWhiteSpace(n) && n.All(char.IsDigit) && Convert.ToInt32(n) < 12)
            {
                return true;
            }
            return false;
        }

        [NonAction]
        public static bool year(string n)
        {
            if (!IsNullOrWhiteSpace(n) && n.All(char.IsDigit) && n.Length == 4)
            {
                return true;
            }
            return false;
        }



    }
}
