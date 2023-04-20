using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jon.WPF.Data.Models.General
{
    public class Address
    {
        [DisplayName("Street Address")]
        [Description("The first line of the street address.")]
        [Category("Address")]
        public string Street { get; set; }

        [DisplayName("Street Address 2")]
        [Description("The second line of the street address (if applicable).")]
        [Category("Address")]
        public string Street2 { get; set; }

        [DisplayName("City")]
        [Description("The name of the city.")]
        [Category("Address")]
        public string City { get; set; }

        [DisplayName("State")]
        [Description("The name of the state or province.")]
        [Category("Address")]
        public string State { get; set; }

        [DisplayName("Postal Code")]
        [Description("The postal code or ZIP code.")]
        [Category("Address")]
        public string Postal { get; set; }
    }
}
