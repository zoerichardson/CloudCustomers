using CloudCustomers.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudCustomers.UnitTests.Fixtures
{
    public static class UsersFixture
    {
        public static List<User> GetTestUsers() =>
            new()
            {
                new User
                {
                    Name = "Test user 1",
                    Email = "testuser1@email.com",
                    Address = new Address
                    {
                        Street = "1 test st",
                        City = "Somewhere",
                        Postcode = "G21 242"
                    }
                },
                new User
                {
                    Name = "Test user 2",
                    Email = "testuser2@email.com",
                    Address = new Address
                    {
                        Street = "2 test st",
                        City = "Somewhere",
                        Postcode = "G43 120"
                    }
                },

                new User
                {
                    Name = "Test user 3",
                    Email = "testuser3@email.com",
                    Address = new Address
                    {
                        Street = "3 test st",
                        City = "Somewhere",
                        Postcode = "G00 202"
                    }
                },
            };
    }
}
