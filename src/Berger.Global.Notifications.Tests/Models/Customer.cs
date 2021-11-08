using System;
using System.Collections.Generic;

namespace Berger.Global.Notifications.Tests.Models
{
    public class Customer : Notifiable
    {
        public Customer()
        {
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Active { get; set; }
        public object PropriedadeObject { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public int? Dependents { get; set; }
        public IList<Customer> CustomersIList { get; set; }
        public IEnumerable<Customer> CustomersIEnumerable { get; set; }
        public ICollection<Customer> CustomersICollection { get; set; }
        public Gender Gender { get; set; }
    }

    public enum Gender
    {
        Male = 1,
        Female = 2
    }
}