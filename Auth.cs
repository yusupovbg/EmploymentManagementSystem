﻿using Intercom.Data;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
{
    internal class Auth
    {
        public static bool isLoggedIn = false;
        public static User currentUser;
        /*public static bool isUserEmp = false;
        public static bool isUserAdmin = false;*/

        public static bool Login()
        {
            Console.Clear();
            Console.Write("Username: ");
            string username = Console.ReadLine().Trim().ToLower();
            Console.WriteLine(Environment.NewLine);

            Console.Write("Password: ");
            string password = Console.ReadLine().Trim();
            Console.WriteLine(Environment.NewLine);

            // Check if the username and password match any employee in the employee list
            foreach (User i in Program.userList.GetAllEmployees())
            {
                if (i.Username == username && i.Password == password)
                {
                    currentUser = i;
                    return true;
                }
            }

            isLoggedIn = true;
            // If the username and password do not match any admin or employee, authentication fails
            return false;
        }

        public static void Logout()
        {
            RulesView rulesView = new RulesView();
            isLoggedIn = false;
            currentUser = null;
            rulesView.Show();
            //Program.mainView()
        }

        public bool IsLoggedIn()
        {
            return isLoggedIn;
        }

        public static bool isUserAdmin()
        {
            return currentUser.IsAdmin;
        }
    }
}
