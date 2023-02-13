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
        Car car = new Car() { Id = 1, Model = "BMW", Price = 100, License = 5 };
        Car carModelNull = new Car() { Id = 1, Model = null, Price = 100, License = 5 };
        Car carModelTooLong = new Car() { Id = 1, Model = "Mustang", Price = 100, License = 5 };
        Car carPriceIsNegative = new Car() { Id = 1, Model = "BMW", Price = -1, License = 5 };
        Car carLicenseNotLongEnough = new Car() { Id = 1, Model = "BMW", Price = 100, License = 1 };
        Car carLicenseTooLong = new Car() { Id = 1, Model = "BMW", Price = 100, License = 8 };

        [TestMethod()]
        public void ToStringTest()
        {
            string ca = car.ToString();
            Assert.AreEqual(ca, "1, BMW, 100, 5");
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
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => carLicenseNotLongEnough.ValidateLicense());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => carLicenseTooLong.ValidateLicense());
        }

        [TestMethod()]
        public void ValidateTest()
        {
            car.Validate();
            Assert.ThrowsException<ArgumentNullException>(() => carModelNull.Validate());
            Assert.ThrowsException<ArgumentException>(() => carModelTooLong.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => carPriceIsNegative.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => carLicenseNotLongEnough.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => carLicenseTooLong.Validate());
        }
    }
}