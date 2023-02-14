using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstObOpgUnit
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
        public string License { get; set; }

        public override string ToString()
        {
            return $"{Id}, {Model}, {Price}, {License}";
        }

        public void ValidateModel()
        {
            if (Model == null)
            {
                throw new ArgumentNullException("Model is null.");
            }
            if (Model.Length >= 4)
            {
                throw new ArgumentException("Model is empty or too long.");
            }
        }

        public void ValidatePrice()
        {
            if (Price <= 0)
            {
                throw new ArgumentOutOfRangeException("Price is negative.");
            }
        }

        public void ValidateLicense()
        {
            if (License?.Length < 2 || License?.Length > 7)
            {
                throw new ArgumentException("License is not right.");
            }
        }

        public void Validate()
        {
            ValidateModel();
            ValidatePrice();
            ValidateLicense();
        }
    }
}
