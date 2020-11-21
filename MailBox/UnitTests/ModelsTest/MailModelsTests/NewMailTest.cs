﻿using System;
using Xunit;
using MailBox.Models;
using System.Collections.Generic;
using MailBox.Models.UserModels;
using MailBox.Models.MailModels;

namespace UnitTests.ModelsTest.MailModelsTest
{
    public class NewMailTest
    {
        [Fact]
        public void ConstructorTest()
        {
            NewMail newMail = null;
            #region Init variables
            int senderId = 0;
            List<string> CCRecipientsAddresses = new List<string>();
            List<string> BCCRecipientsAddresses = new List<string>();
            string topic = "testtocpic";
            string text = "testtext";
            DateTime dateTime = new DateTime(2021, 1, 1);
            #endregion
            newMail = new NewMail(senderId, CCRecipientsAddresses, BCCRecipientsAddresses, topic, text, dateTime);
            #region Tests
            Assert.NotNull(newMail);
            Assert.Equal(newMail.SenderId, senderId);
            Assert.Equal(newMail.CCRecipientsAddresses, CCRecipientsAddresses);
            Assert.Equal(newMail.BCCRecipientsAddresses, BCCRecipientsAddresses);
            Assert.Equal(newMail.Topic, topic);
            Assert.Equal(newMail.Text, text);
            Assert.Equal(newMail.Date, dateTime);
            #endregion
        }
    }
}