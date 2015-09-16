using Bluevolt.POC.Business;
using Bluevolt.POC.TestDao.Core;
using System;

namespace Bluevolt.POC.TestDao.TestData
{
    public class TestData
    {
        public static void PopulateUserData()
        {
            TestBluevoltPOCDB.UserDetails.Add(new UserDetails 
            {
                ID = TestBluevoltPOCDB.NextID, 
                UserName = "john.doe",
                Password="password" ,
                FirstName="John",
                LastName="Doe",
                Gender="Male",
                Phone="1234567890",
                Email="john.doe@bulevolt.com",
                CreatedBy=1,
                CreatedOn=DateTime.Now
            });

            TestBluevoltPOCDB.UserDetails.Add(new UserDetails
            {
                ID = TestBluevoltPOCDB.NextID,
                UserName = "sagar.shelar",
                Password = "password",
                FirstName = "Sagar",
                LastName = "Shelar",
                Gender = "Male",
                Phone = "7894561230",
                Email = "sagar.shelar@bulevolt.com",
                CreatedBy = 1,
                CreatedOn = DateTime.Now
            });
            TestBluevoltPOCDB.UserDetails.Add(new UserDetails
            {
                ID = TestBluevoltPOCDB.NextID,
                UserName = "piyush.ostwal",
                Password = "password",
                FirstName = "Piyush",
                LastName = "Ostwal",
                Gender = "Male",
                Phone = "9124565478",
                Email = "john.doe@bulevolt.com",
                CreatedBy = 1,
                CreatedOn = DateTime.Now
            });
            TestBluevoltPOCDB.UserDetails.Add(new UserDetails
            {
                ID = TestBluevoltPOCDB.NextID,
                UserName = "kunal.adhikari",
                Password = "password",
                FirstName = "Kunal",
                LastName = "Adhikari",
                Gender = "Male",
                Phone = "4567891230",
                Email = "kunal.adhikari@bulevolt.com",
                CreatedBy = 1,
                CreatedOn = DateTime.Now
            });
        }
    }
}
