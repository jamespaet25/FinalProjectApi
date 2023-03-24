using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ServiceReference1;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace SoapApi
{
    [TestClass]
    public class CountryRoad
    {
        private ServiceReference1.CountryInfoServiceSoapTypeClient countryInfoServiceSoapType;

        [TestInitialize]
        public async Task Initialize()
        {
            countryInfoServiceSoapType = new ServiceReference1.CountryInfoServiceSoapTypeClient(ServiceReference1.CountryInfoServiceSoapTypeClient.EndpointConfiguration.CountryInfoServiceSoap);
        }

        [TestMethod]
        public void CountryNameAndIsoCode()
        {
            var country = ListOfCountryNamesByCode();
            var randomCountry = GetRandomRecord(country);

            var fullCountryInfo = countryInfoServiceSoapType.FullCountryInfo(randomCountry.sISOCode);

            Assert.AreEqual(fullCountryInfo.sISOCode, randomCountry.sISOCode);
            Assert.AreEqual(fullCountryInfo.sName, randomCountry.sName);

        }

        [TestMethod]
        public void CountryISOCode()
        {
            var countryIsoCode = ListOfCountryNamesByCode();
            List<tCountryCodeAndName> countryRecords = new List<tCountryCodeAndName>();

            for (int record = 0; record < 5; record++)
            {
                countryRecords.Add(GetRandomRecord(countryIsoCode));
            }

            foreach (var countryRecord in countryRecords)
            {
                var IsoCode = countryInfoServiceSoapType.CountryISOCode(countryRecord.sName);
                Assert.AreEqual(IsoCode, countryRecord.sISOCode);
            }

        }

        private tCountryCodeAndName GetRandomRecord(tCountryCodeAndName[] data)
        {
            var random = new Random();
            int next = random.Next(data.Length);

            var CountryRecord = data[next];

            return CountryRecord;

        }

        private tCountryCodeAndName[] ListOfCountryNamesByCode()
        {
            var countryName = countryInfoServiceSoapType.ListOfCountryNamesByCode();

            return countryName;
        }

    }
}