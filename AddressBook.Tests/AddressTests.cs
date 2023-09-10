using AdressBook.Models;
using AdressBook.Repozytories;
using AdressBook.Services;
using Moq;
using System.Diagnostics.Metrics;
using System.IO;
using System.Net;
using System.Xml.Linq;

namespace AddressBook.Tests
{
    public class AddressTests
    {
        private Address _address;
        [SetUp]
        public void Setup()
        {
            _address = new Address("name", "street", 0, "00-000", "city", "country");
        }

        //private Mock<IAddressRepozytories> _mockIAddressRepozytories = new Mock<IAddressRepozytories>();
        // [Test]
        // public async Task Test1()
        // {
        //     var addressService = new AddressService(_mockIAddressRepozytories.Object);
        //
        //     await addressService.AddAdresAsync("name", "street", 0, "00-000", "city", "country");
        //
        //     Assert.Pass(); 
        // }

        [Test]
        public void TestingFirstConstructorInAddress()
        {
            _address = new Address("name", "street", 0, "00-000", "city", "country");
            var resId = _address.Id;
            var resName = _address.Name.ToString();
            var resStreet = _address.Street.ToString();
            var resBuldingNumber = _address.BuldingNumber;
            var resPostCode = _address.PostCode.ToString();
            var resCity = _address.City.ToString();
            var resCountry = _address.Country.ToString();

            Assert.IsNotNull(resId);
            Assert.That(resName, Is.EqualTo("name"));
            Assert.That(resStreet, Is.EqualTo("street"));
            Assert.That(resBuldingNumber, Is.EqualTo(0));
            Assert.That(resPostCode, Is.EqualTo("00-000"));
            Assert.That(resCity, Is.EqualTo("city"));
            Assert.That(resCountry, Is.EqualTo("country"));
        }

        [Test]
        public void TestingSecondConstructorInAddress()
        {
            _address = new Address("name", "street", 0, 1, "00-000", "city", "country");

            var resPremisesNumber = _address.PremisesNumber;

            Assert.That(resPremisesNumber, Is.EqualTo(1));
        }

        [Test]
        public void TestingTheSetNameMethod()
        {
            var res = "name1";

            _address.SetName("Name1");

            Assert.That(res, Is.EqualTo(_address.Name));
        }

        [Test]
        public void TestingTheSetStreetMethod()
        {
            var res = "street1";

            _address.SetStreet("Street1");

            Assert.That(res, Is.EqualTo(_address.Street));
        }

        [Test]
        public void TestingTheSetPostCodeMethod()
        {
            var res = "00-001";

            _address.SetPostCode("00-001");

            Assert.That(res, Is.EqualTo(_address.PostCode));
        }

        [Test]
        public void TestingTheSetCityCodeMethod()
        {
            var res = "city1";

            _address.SetCity("City1");

            Assert.That(res, Is.EqualTo(_address.City));
        }

        [Test]
        public void TestingTheSetCountryMethod()
        {
            var res = "country1";

            _address.SetCountry("Country1");

            Assert.That(res, Is.EqualTo(_address.Country));
        }
    }
}