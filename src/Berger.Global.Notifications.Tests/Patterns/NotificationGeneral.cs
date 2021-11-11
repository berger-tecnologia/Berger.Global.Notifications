using System;
using System.Linq;
using System.Threading;
using System.Globalization;
using System.Collections.Generic;
using Berger.Global.Notifications.Tests.Models;
using Berger.Global.Notifications.Tests.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Berger.Global.Notifications.Tests.Patterns
{
    [TestClass]
    public class NotificationGeneral : BaseConfiguration
    {
        private readonly Customer _customer = new Customer();

        public override void Dispose()
        {
        }

        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void GetBasicNotification()
        {
            var _notification = CreateFactory(_customer);

            _notification.IfNullOrEmpty(x => x.Name);

            Assert.IsTrue(_notification.IsInvalid());
        }
        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void IfNullOrEmpty()
        {
            var _notification = CreateFactory(_customer);

            string vazio = string.Empty;

            _notification.IfNullOrEmpty(x => x.Name);
            _notification.IfNullOrEmpty(vazio, "Vazio");

            Assert.AreEqual(false, _notification.IsValid());

            Assert.IsTrue(_notification.Count() == 2);
        }
        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void IfNullOrWhiteSpace()
        {
            var _notification = CreateFactory(_customer);

            _notification.IfNullOrWhiteSpace(x => x.Name);
            _notification.IfNullOrWhiteSpace("", "Empty");

            Assert.AreEqual(false, _notification.IsValid());

            Assert.IsTrue(_notification.Count() == 2);
        }
        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void IfNotNullOrEmpty()
        {
            _customer.Name = "Robert"; var _notification = CreateFactory(_customer);

            _notification.IfNotNullOrEmpty(x => x.Name);
            _notification.IfNotNullOrEmpty("NotEmpty", "Any");

            Assert.AreEqual(false, _notification.IsValid());

            Assert.IsTrue(_notification.Count() == 2);
        }
        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void IfLowerThan()
        {
            var _notification = CreateFactory(_customer);

            _customer.Age = 10; 

            _notification.IfLowerThan(x => x.Age, 25);

            Assert.AreEqual(false, _notification.IsValid());
        }
        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void IfGreaterThan()
        {
            var _notification = CreateFactory(_customer);

            _customer.Age = 37; 

            _notification.IfGreaterThan(x => x.Age, 25);

            Assert.AreEqual(false, _notification.IsValid());
        }
        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void IfLengthGreaterThan()
        {
            var _notification = CreateFactory(_customer);

            _customer.Name = "Robert"; 

            _notification.IfLengthGreaterThan(x => x.Name, 1);

            Assert.AreEqual(false, _notification.IsValid());
        }
        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void IfLengthLowerThan()
        {
            var _notification = CreateFactory(_customer);
            _customer.Name = "Robert"; 

            _notification.IfLengthLowerThan(x => x.Name, 200);

            Assert.AreEqual(false, _notification.IsValid());
        }
        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void IfLengthNoEqual()
        {
            var _notification = CreateFactory(_customer);

            _notification.IfLengthNoEqual(x => x.Name, 3);

            Assert.AreEqual(false, _notification.IsValid());
        }
        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void IfNullOrEmptyOrInvalidLength()
        {
            var customerNameEmpty = new Customer();

            var customerNameMinInvalid = new Customer(); 
            customerNameMinInvalid.Name = "a";
            
            var customerNameMaxInvalid = new Customer(); 
            customerNameMaxInvalid.Name = "Name with more than 10 characters";

            var _notification_1 = CreateFactory(customerNameEmpty);
            _notification_1.IfNullOrInvalidLength(x => x.Name, 3, 10);

            var _notification_2 = CreateFactory(customerNameMinInvalid);
            _notification_2.IfNullOrInvalidLength(x => x.Name, 3, 10);

            var _notification_3 = CreateFactory(customerNameMaxInvalid);
            _notification_3.IfNullOrInvalidLength(x => x.Name, 3, 10);

            Assert.AreEqual(1, _notification_1.Count());

            Assert.AreEqual(1, _notification_2.Count());

            Assert.AreEqual(1, _notification_3.Count());
        }
        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void IfNullOrOrInvalidLength()
        {
            Customer customerNameEmpty = new Customer();
            Customer customerNameMinInvalid = new Customer(); 
            
            customerNameMinInvalid.Name = "a"; 
            
            Customer customerNameMaxInvalid = new Customer(); 
            customerNameMaxInvalid.Name = "Name with more than 10 characters";

            var _notification_1 = CreateFactory(customerNameEmpty);
            _notification_1.IfNullOrInvalidLength(x => x.Name, 3, 10);

            var _notification_2 = CreateFactory(customerNameMinInvalid);
            _notification_2.IfNullOrInvalidLength(x => x.Name, 3, 10); var _notification = CreateFactory(_customer);

            var _notification_3 = CreateFactory(customerNameMaxInvalid);
            _notification_3.IfNullOrInvalidLength(x => x.Name, 3, 10);

            Assert.AreEqual(1, _notification_1.Count());

            Assert.AreEqual(1, _notification_2.Count());

            Assert.AreEqual(1, _notification_3.Count());
        }
        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void IfNotEmail()
        {
            var _notification = CreateFactory(_customer);
            _customer.Name = "This is not an e-mail"; 

            _notification.IfNotEmail(x => x.Name);

            Assert.AreEqual(false, _notification.IsValid());
        }

        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void IfNotUrl()
        {
            var _notification = CreateFactory(_customer);

            _customer.Name = "This is not an URL"; 

            _notification.IfNotUrl(x => x.Name);

            Assert.AreEqual(false, _notification.IsValid());
        }

        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void IfGreaterOrEqualsThan()
        {
            Customer customer10 = new Customer();
            Customer customer11 = new Customer(); 
            
            customer10.Age = 10;
            customer11.Age = 11;

            var _notification_10 = CreateFactory(customer10);
            var _notification_11 = CreateFactory(customer11);

            _notification_10.IfGreaterOrEqualsThan(x => x.Age, 10);

            _notification_11.IfGreaterOrEqualsThan(x => x.Age, 10);

            Assert.AreEqual(false, _notification_10.IsValid());

            Assert.AreEqual(false, _notification_11.IsValid());
        }

        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void IfGreaterOrEqualsThan_DateTime()
        {
            Customer customer10 = new Customer(); 
            Customer customer11 = new Customer(); 
            
            DateTime now = DateTime.Now; 

            customer10.CreationDate = now; 
            customer11.CreationDate = now.AddDays(1);

            var _notification_10 = CreateFactory(customer10);
            var _notification_11 = CreateFactory(customer11);

            _notification_10.IfGreaterOrEqualsThan(x => x.CreationDate, now);
            _notification_11.IfGreaterOrEqualsThan(x => x.CreationDate, now);

            Assert.AreEqual(false, _notification_10.IsValid());
            Assert.AreEqual(false, _notification_11.IsValid());
        }
        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void IfLowerOrEqualsThan()
        {
            Customer customer10 = new Customer(); 
            Customer customer09 = new Customer(); 
            
            customer10.Age = 10; 
            customer09.Age = 09;

            var _notification_10 = CreateFactory(customer10);
            var _notification_09 = CreateFactory(customer09);

            _notification_10.IfLowerOrEqualsThan(x => x.Age, 10);
            _notification_09.IfLowerOrEqualsThan(x => x.Age, 10);

            Assert.AreEqual(false, _notification_10.IsValid());
            Assert.AreEqual(false, _notification_09.IsValid());
        }

        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void IfLowerOrEqualsThan_DateTime()
        {
            Customer customer10 = new Customer(); 
            Customer customer11 = new Customer(); 
            
            DateTime now = DateTime.Now; 
            
            customer10.CreationDate = now; 
            customer11.CreationDate = now.AddDays(-1);

            var _notification_10 = CreateFactory(customer10);
            var _notification_11 = CreateFactory(customer11);

            _notification_10.IfLowerOrEqualsThan(x => x.CreationDate, now);
            _notification_11.IfLowerOrEqualsThan(x => x.CreationDate, now);

            Assert.AreEqual(false, _notification_10.IsValid());
            Assert.AreEqual(false, _notification_11.IsValid());
        }

        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void IfNotRange()
        {
            var _notification = CreateFactory(_customer);

            _customer.Age = 10; 

            _notification.IfNotRange(x => x.Age, 11, 21);

            Assert.AreEqual(false, _notification.IsValid());
        }
        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void IfNotRange_Date()
        {
            var _notification = CreateFactory(_customer);

            DateTime now = DateTime.Now; 

            _customer.CreationDate = now; 

            _notification.IfNotRange(x => x.CreationDate, now.AddMinutes(1), now.AddDays(1));

            Assert.AreEqual(false, _notification.IsValid());
        }

        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void IfRange()
        {
            var _notification = CreateFactory(_customer);

            _customer.Age = 10; 

            _notification.IfRange(x => x.Age, 05, 21);

            Assert.AreEqual(false, _notification.IsValid());
        }

        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void IfRange_Date()
        {
            var _notification = CreateFactory(_customer);

            DateTime now = DateTime.Now; _customer.CreationDate = now; 

            _notification.IfNotRange(x => x.CreationDate, DateTime.Now.AddDays(1), DateTime.Now.AddDays(1));

            Assert.AreEqual(false, _notification.IsValid());
        }

        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void IfNotContains()
        {
            var _notification = CreateFactory(_customer);

            _customer.Name = "Rafael"; 

            _notification.IfNotContains(x => x.Name, "Robert");

            Assert.AreEqual(false, _notification.IsValid());
        }

        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void IfContains()
        {
            var _notification = CreateFactory(_customer);

            _customer.Name = "Rafael"; 

            _notification.IfContains(x => x.Name, "Rafael");

            Assert.AreEqual(false, _notification.IsValid());
        }

        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void IfNotAreEquals()
        {
            var _notification = CreateFactory(_customer);

            _customer.Name = "Rafael"; 

            _notification.IfNotAreEquals(x => x.Name, "Robert");

            Assert.AreEqual(false, _notification.IsValid());
        }

        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void IfAreEquals()
        {
            var _notification = CreateFactory(_customer);

            _customer.Name = "Rafael"; 

            _notification.IfAreEquals(x => x.Name, "Rafael");

            Assert.AreEqual(false, _notification.IsValid());
        }

        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void IfTrue()
        {
            var _notification = CreateFactory(_customer);

            _customer.Active = true; 

            _notification.IfTrue(x => x.Active);

            Assert.AreEqual(false, _notification.IsValid());
        }
        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void IfFalse()
        {
            var _notification = CreateFactory(_customer);

            _customer.Active = false;

            _notification.IfFalse(x => x.Active);

            Assert.AreEqual(false, _notification.IsValid());
        }
        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void IfNotCpf()
        {
            var _notification = CreateFactory(_customer);

            _customer.Cpf = "0000000000"; 

            _notification.IfNotCpf(x => x.Cpf);

            Assert.AreEqual(false, _notification.IsValid());
        }
        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void IfNotCnpj()
        {
            var _notification = CreateFactory(_customer);

            _customer.Cnpj = "80288216000134"; 

            _notification.IfNotCnpj(x => x.Cnpj);

            Assert.AreEqual(false, _notification.IsValid());
        }
        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void IfNotGuid()
        {
            var _notification = CreateFactory(_customer);

            _customer.Name = "Invalid Guid"; 

            _notification.IfNotGuid(x => x.Name);

            Assert.AreEqual(false, _notification.IsValid());
        }
        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void IfCustom()
        {
            var _notification = CreateFactory(_customer);

            _notification.CustomCreate("Customer", "This is a custom notification");

            Assert.AreEqual(false, _notification.IsValid());
        }

        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void IfCollectionIsNullOrEmpty()
        {
            var _notification = CreateFactory(_customer);

            _notification.IfCollectionIsNullOrEmpty(x => x.CustomersIEnumerable);
            _notification.IfCollectionIsNullOrEmpty(x => x.CustomersIList);
            _notification.IfCollectionIsNullOrEmpty(x => x.CustomersICollection);

            _customer.CustomersIEnumerable = new List<Customer>().AsEnumerable();
            _customer.CustomersIList = new List<Customer>();
            _customer.CustomersICollection = new List<Customer>();

            _notification.IfCollectionIsNullOrEmpty(x => x.CustomersIEnumerable);
            _notification.IfCollectionIsNullOrEmpty(x => x.CustomersIList);
            _notification.IfCollectionIsNullOrEmpty(x => x.CustomersICollection);

            Assert.AreEqual(false, _notification.IsValid());
            Assert.AreEqual(true, _notification.Count() == 6);
        }
        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void IfEqualsZero()
        {
            var _notification = CreateFactory(_customer);

            _customer.Age = 0; 

            _notification.IfEqualsZero(x => x.Age);

            Assert.AreEqual(false, _notification.IsValid());
        }
        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void IfNull()
        {
            var _notification = CreateFactory(_customer);

            _notification.IfNull(x => x.Dependents);

            Assert.AreEqual(false, _notification.IsValid());
        }
        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void IfNull_Object()
        {
            var _notification = CreateFactory(_customer);

            _notification.IfNull(x => x.AnyObject);

            Assert.AreEqual(false, _notification.IsValid());
        }
        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void IfNotNull()
        {
            var _notification = CreateFactory(_customer);

            _customer.Dependents = 2; 

            _notification.IfNotNull(x => x.Dependents);

            Assert.AreEqual(false, _notification.IsValid());
        }
        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void ShouldNotificateInEnglish()
        {
            var _notification = CreateFactory(_customer);

            _customer.Dependents = 2; 

            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US"); 

            _notification.IfNotNull(x => x.Dependents);

            Assert.AreEqual(false, _notification.IsValid());
            Assert.IsTrue(_notification.Count() == 1);
            Assert.IsTrue(_notification.Messages.Any(x => x.Message.Equals("Field Dependents should be equals to null.")), "É esperado uma mensagem no idioma ingles");
        }
        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void IfNotDate()
        {
            var _notification = CreateFactory(_customer);

            _customer.Name = "Invalid Date"; 

            _notification.IfNotDate(x => x.Name);

            Assert.AreEqual(false, _notification.IsValid());
        }
        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void IfEnumInvalid()
        {
            var _notification = CreateFactory(_customer);

            Gender gender = (Gender)0; 
            
            _customer.Gender = gender; 

            _notification.IfEnumInvalid(x => x.Gender);

            Assert.AreEqual(false, _notification.IsValid());
        }
        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void AddNotificationIfNull()
        {
            Customer customer = new Customer(); 

            InsertCustomerRequest request = new InsertCustomerRequest() 
            { 
                Name = null, 
                Age = 36 
            };

            var _notification = CreateFactory(customer);

            _notification.IfNull(request.Name, "Name");

            Assert.IsTrue(_notification.IsInvalid());
        }
    }
}