using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MyWebAPI.Models;
using MyWebAPI.Controllers;
using Microsoft.Extensions.Options;

namespace MyWebAPI_Test
{
    public class UserInfoTest
    {
        private readonly BookStoresDBContext _context;
        private readonly JWTSettings _jWTSettings;

        //public UserInfoTest(BookStoresDBContext context, IOptions<JWTSettings> jwtSettings)
        //{
        //    _context = context;
        //    _jWTSettings = jwtSettings.Value;
        //}

        [Fact]
        public void UserTest()
        {
            //arrange
            int a = 100;
            int b = 200;
            int c = 300;

            //User testUser = new User
            //{
            //    UserId = "paolo.accorti",
            //    Password = "d58a7cfca32529d3f53ce8bdbf71bb0b"
            //};
            //UsersController usersController = new UsersController(_context, _jWTSettings);
            //act
            int d = a + b;
            //var getValue = usersController.Login(testUser);

            //assert
            Assert.Equal(c, d);
            
        }

    }
}
