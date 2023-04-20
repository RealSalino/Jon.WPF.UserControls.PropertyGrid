using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jon.WPF.Data.Models.General
{
    public class Person
    {
        [DisplayName("First Name")]
        [Description("The person's first name.")]
        [Category("Personal Information")]
        public string First { get; set; }

        [DisplayName("Middle Name")]
        [Description("The person's middle name (if applicable).")]
        [Category("Personal Information")]
        public string Middle { get; set; }

        [DisplayName("Last Name")]
        [Description("The person's last name.")]
        [Category("Personal Information")]
        public string Last { get; set; }

        [DisplayName("Date of Birth")]
        [Description("The person's date of birth.")]
        [Category("Personal Information")]
        public DateTime DOB { get; set; }

        [DisplayName("Address")]
        [Description("The person's physical address.")]
        [Category("Personal Information")]
        public Address Address { get; set; }

        //public string Street => Address.Street;
        //public string Stree2 => Address.Street2;
        //public string City => Address.City;
        //public string State=> Address.State;
        //public string PostalCode => Address.Postal;

        [DisplayName("Contact Information")]
        [Description("A list of the person's contact information.")]
        [Category("Contact Information")]
        public List<ContactInfo> ContactInfoList { get; set; }
    }
}
