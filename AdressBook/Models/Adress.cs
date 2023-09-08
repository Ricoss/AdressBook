﻿using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace AdressBook.Models
{
    public class Adress
    {
        public Guid Id { get; }
        public string Name { get; private set; }
        public string Street { get; private set; }
        public int BuldingNumber { get; private set; }
        public int PremisesNumber { get; private set; }
        public string PostCode { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }

        protected Adress()
        {

        }

        public Adress(string name, string street, int buldingNumber, int premisesNumber, string postCode, string city, string country)
        {
            Guid id = Guid.NewGuid();
            SetName(name);
            SetStreet(street);
            BuldingNumber = buldingNumber;
            PremisesNumber = premisesNumber;
            SetPostCode(postCode);
            SetCity(city);
            SetCountry(country);
        }
        public Adress(string name, string street, int buldingNumber, string postCode, string city, string country)
        {
            Guid id = Guid.NewGuid();
            SetName(name);
            SetStreet(street);
            BuldingNumber = buldingNumber;
            SetPostCode(postCode);
            SetCity(city);
            SetCountry(country);

        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Name can not by empty.");
            }
            name = name.ToLower();
            Name = name;

        }
        public void SetStreet(string street)
        {
            if (string.IsNullOrWhiteSpace(street))
            {
                throw new Exception("Street can not by empty.");
            }
            street = street.ToLower();
            Street = street;
        }

        public void SetPostCode(string postCode)
        {
            if (string.IsNullOrWhiteSpace(postCode))
            {
                throw new Exception("Post Code can not by empty.");
            }
            postCode = postCode.ToLower();
            Street = postCode;
        }
        public void SetCity(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                throw new Exception("City can not by empty.");
            }
            city = city.ToLower();
            Street = city;
        }
        public void SetCountry(string country)
        {
            if (string.IsNullOrWhiteSpace(country))
            {
                throw new Exception("Country can not by empty.");
            }
            country = country.ToLower();
            Street = country;
        }


    }
}
