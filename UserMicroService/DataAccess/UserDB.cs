using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserMicroService.Models;

namespace UserMicroService.DataAccess
{
    public static class UserDB
    {

        public static List<User> listOfUsers = new List<User>();


        public static List<User> GetAllUsers()
        {
            return listOfUsers;
        }


        public static User GetUserByName(string name)
        {
            foreach (User u in listOfUsers)
            {
                if (u.Name == name)
                {
                    return u;
                }
            }
            return null;
        }

        public static User GetUserById(int Id)
        {

          
           foreach (User u in listOfUsers)
            {
                if (u.Id == Id)
                {
                    return u;
                }
            }
            return null;
        }

        public static User AddUser(User NewUser)
        {
            foreach (User u in listOfUsers)
            {
                if (u.Id == NewUser.Id)
                {
                    Console.WriteLine("User with this id already exists");

                }
            }
            listOfUsers.Add(NewUser);
            return GetUserById(NewUser.Id);

        }

        public static User EditUser(User user)
        {
            User newUser = GetUserById(user.Id);
            if (newUser != null)
            {
                newUser.Id = user.Id;
                newUser.Name = user.Name;
                newUser.Email = user.Email;
                newUser.Address = user.Address;
                newUser.ZipCode = user.ZipCode;
                newUser.CityName = user.CityName;
                newUser.CountryName = user.CountryName;
                newUser.Phone = user.Phone;

                return newUser;
            }
            else return null;
        }

        public static void DeleteUser(int id)
        {
            User user = GetUserById(id);
            if (user != null)
            {
                listOfUsers.Remove(user);
            }
        }






    }
}