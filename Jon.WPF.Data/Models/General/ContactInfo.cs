using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jon.WPF.Data.Models.General
{
    public class ContactInfo
    {
        [DisplayName("Contact Type")]
        [Description("The type of contact information.")]
        [Category("Contact Information")]
        public ContactInfoType Type { get; set; }

        [DisplayName("Contact Value")]
        [Description("The value of the contact information.")]
        [Category("Contact Information")]
        public string Value { get; set; }
    }
}
