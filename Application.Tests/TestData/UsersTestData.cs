﻿namespace Application.Tests.TestData
{
    public class UsersTestData
    {
        public static UserData GetAdminAccount()
        {
            return new UserData("Main", "Admin", "admin@gmail.com", "", "admin");
        }
    }

    public struct UserData
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public UserData(string name, string lastName, string email, string phone, string password)
        {
            Name = name;
            LastName = lastName;
            Phone = phone;
            Email = email;
            Password = password;
        }
    }
}