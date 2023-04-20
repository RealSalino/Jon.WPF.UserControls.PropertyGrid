using PropertyGridApp.Controls;
using System;
using System.ComponentModel;
using System.Windows;

namespace PropertyGridApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();   
            Person person = new Person
            {
                FirstName = "John",
                LastName = "Doe",
                Age = 30,
                Occupation = "Software Developer",
                Email = "john.doe@example.com",
                Phone = "555-1234",
                Address = "123 Main St",
                Gender = Gender.Male,
                Height = 180,
                Weight = 80.5
            };

            propertyGrid.SelectedObject = person;
        }
    }

    public class ExampleClass
    {
        [Category("General")]
        public string PropertyA { get; set; }

        [Category("Numeric")]
        public int PropertyB { get; set; }
    }

    [Description("A object representing a person.")]
    public class Person
    {
        [Description("Person's given name")]
        [Category("General")]
        [DisplayName("First Name")]
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        [Category("General")]
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        [Category("General")]
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        [Category("General")]
        public string Occupation
        {
            get { return _occupation; }
            set { _occupation = value; }
        }
        [Description("Person's date of birth")]
        [Category("General")]
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }
        [Description("Person's email address")]
        [Category("Contact Information")]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        [Description("Person's phone number")]
        [Category("Contact Information")]
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        [Description("Person's address")]
        [Category("Contact Information")]
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        [Description("Person's gender")]
        [Category("General")]
        public Gender Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        [Description("Person's height in centimeters")]
        [Category("Physical Characteristics")]
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }
        [Description("Person's weight in kilograms")]
        [Category("Physical Characteristics")]
        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }
        [Description("Person's body mass index")]
        [Category("Physical Characteristics")]
        public double BodyMassIndex
        {
            get { return _weight / Math.Pow(_height / 100.0, 2); }
        }
        [Description("Person's full name")]
        [Category("General")]
        public string FullName
        {
            get { return _firstName + " " + _lastName; }
        }
        private string _firstName;
        private string _lastName;
        private int _age;
        private string _occupation;
        // Added private fields
        private string _email;
        private string _phone;
        private string _address;
        private Gender _gender;
        private int _height;
        private double _weight;
        private DateTime _dateOfBirth;
    }
    public enum Gender
    {
        Male,
        Female
    }

}