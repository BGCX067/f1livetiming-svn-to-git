﻿/*
 *  f1livetiming - Part of the Live Timing Library for .NET
 *  Copyright (C) 2009 Liam Lowey
 *  
 *      http://livetiming.turnitin.co.uk/
 *
 *  Licensed under the Apache License, Version 2.0 (the "License"); 
 *  you may not use this file except in compliance with the License. 
 *  You may obtain a copy of the License at 
 *  
 *      http://www.apache.org/licenses/LICENSE-2.0 
 *  
 *  Unless required by applicable law or agreed to in writing, software 
 *  distributed under the License is distributed on an "AS IS" BASIS, 
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
 *  See the License for the specific language governing permissions and 
 *  limitations under the License. 
 */

using System;
using F1.Configuration;
using F1.Protocol;
using F1.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class AuthorizationTest : UnitTestBase
    {
        private string Username { get; set; }
        private string Password { get; set; }


        public override void OnSetup()
        {
            // This unit test relies on the user configuration
            AuthData d = AuthData.Load("..\\..\\..\\auth.config");

            if( d != null )
            {
                Username = d.Username;
                Password = d.Password;
            }
        }

        

        [TestMethod]
        public void TestGetAuthKey()
        {
            if(String.IsNullOrEmpty(Username) || String.IsNullOrEmpty(Password))
            {
                Assert.Fail("You must configure the auth.config file in sandbox root for this unit test.");
                return;
            }


            var authKey = new F1.Protocol.AuthorizationKey(Username, Password);

            DoTests(authKey);
        }


        [TestMethod]
        public void TestSimGetAuthKey()
        {
            var authKey = new F1.Simulator.AuthorizationKey("..\\..\\..\\Session Keys.txt");

            DoTests(authKey);
        }


        private void DoTests(IAuthKey authKey)
        {
            {
                const string session = "6630"; // 0xF3C3476F

                uint key = authKey.GetKey(session);

                Assert.AreNotEqual(AuthorizationKey.INVALID_KEY, key);
                Assert.AreEqual((uint)0xF3C3476F, key);
            }

            {
                const string session = "6629"; // 0xE5BCF17C

                uint key = authKey.GetKey(session);

                Assert.AreNotEqual(AuthorizationKey.INVALID_KEY, key);
                Assert.AreEqual((uint)0xE5BCF17C, key);
            }

            {
                const string session = "6628"; // 0xcf0a3056

                uint key = authKey.GetKey(session);

                Assert.AreNotEqual(AuthorizationKey.INVALID_KEY, key);
                Assert.AreEqual((uint)0xcf0a3056, key);
            }

            {
                const string session = "6632"; // 0xdc8af5ee

                uint key = authKey.GetKey(session);

                Assert.AreNotEqual(AuthorizationKey.INVALID_KEY, key);
                Assert.AreEqual((uint)0xdc8af5ee, key);
            }


            {
                const string session = "6708"; // 0xdc8af5ee

                uint key = authKey.GetKey(session);

                Assert.AreNotEqual(AuthorizationKey.INVALID_KEY, key);
                Assert.AreEqual((uint)0xdc8af5ee, key);
            }

            {
                const string session = "_040109"; // 0xcf0a3056

                uint key = authKey.GetKey(session);

                Assert.AreNotEqual(AuthorizationKey.INVALID_KEY, key);
                Assert.AreEqual((uint)0, key);
            }
        }
    }
}
