using Microsoft.VisualStudio.TestTools.UnitTesting;
using FirstObOpgUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstObOpgUnit.Tests
{
    [TestClass()]
    public class CarTests
    {
        Car car = new Car() { Id = 1, Model = "Mustang", Price = 100, License = "BHMSKSU" };
        Car carModelNull = new Car() { Id = 1, Model = null, Price = 100, License = "USDHCJSU" };
        Car carModelTooLong = new Car() { Id = 1, Model = "BMW", Price = 100, License = "DJVHSHSU" };
        Car carPriceIsNegative = new Car() { Id = 1, Model = "Mustang", Price = -1, License = "HDUDHCYD" };
        Car carLicenseNotLongEnough = new Car() { Id = 1, Model = "Mustang", Price = 100, License = "D" };
        Car carLicenseTooLong = new Car() { Id = 1, Model = "Mustang", Price = 100, License = "DHVHSYSH" };

        [TestMethod()]
        public void ToStringTest()
        {
            string ca = car.ToString();
            Assert.AreEqual(ca, "1, Mustang, 100, BHMSKSU");
        }

        [TestMethod()]
        public void ValidateModelTest()
        {
            car.ValidateModel();
            Assert.ThrowsException<ArgumentNullException>(() => carModelNull.ValidateModel());
            Assert.ThrowsException<ArgumentException>(() => carModelTooLong.ValidateModel());
        }

        [TestMethod()]
        public void ValidatePriceTest()
        {
            car.ValidatePrice();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => carPriceIsNegative.ValidatePrice());
        }

        [TestMethod()]
        public void ValidateLicenseTest()
        {
            car.ValidateLicense();
            Assert.ThrowsException<ArgumentException>(() => carLicenseNotLongEnough.ValidateLicense());
            Assert.ThrowsException<ArgumentException>(() => carLicenseTooLong.ValidateLicense());
        }

        [TestMethod()]
        public void ValidateTest()
        {
            car.Validate();
            Assert.ThrowsException<ArgumentNullException>(() => carModelNull.Validate());
            Assert.ThrowsException<ArgumentException>(() => carModelTooLong.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => carPriceIsNegative.Validate());
            Assert.ThrowsException<ArgumentException>(() => carLicenseNotLongEnough.Validate());
            Assert.ThrowsException<ArgumentException>(() => carLicenseTooLong.Validate());
        }
    }
}