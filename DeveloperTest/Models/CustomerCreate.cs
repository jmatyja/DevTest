using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperTest.Models
{
    public class CustomerCreate: CustomerBase
    {
        private const int NAME_MIN_LENGTH = 5;
        public (bool isValid, IEnumerable<string> validationMessages) Validate()
        {
            var validationMessages = new List<string>();
            if (string.IsNullOrEmpty(Name))
            {
                validationMessages.Add("\"Name\" cannot be empty");
            }
            if(!string.IsNullOrEmpty(Name) && Name.Length < NAME_MIN_LENGTH)
            {
                validationMessages.Add($"\"Name\" minium characters length is {NAME_MIN_LENGTH}");
            }
            if (!Enum.IsDefined(typeof(CustomerType), Type))
            {
                validationMessages.Add($"Invalid \"Type\" value. Valid values are: {string.Join(", ", Enum.GetNames(typeof(CustomerType)))}");
            }
            return (!validationMessages.Any(), validationMessages);
        }
    }
}
