﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bluevolt.POC.Business.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            UserDetailsTests test = new UserDetailsTests();
            test.DataService.Search(new UserDetailsSearch());
        }
    }
}
