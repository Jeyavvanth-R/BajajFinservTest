using System;
using System.Collections.Generic;
using System.Linq;

namespace BajajFinservTest.Repositories
{
    public class DataRepository:IDataRepository
    {
        public Dictionary<string, object> ProcessData(List<string> data)
        {
            var numbers = data.Where(d => int.TryParse(d, out _)).ToList();
            var alphabets = data.Where(d => d.All(char.IsLetter)).ToList();
            var highestLowercase = alphabets.Where(a => a.All(char.IsLower)).OrderByDescending(a => a).FirstOrDefault();

            var response = new Dictionary<string, object>
            {
                { "is_success", true },
                { "user_id", "john_doe_17091999" },
                { "email", "john@xyz.com" },
                { "roll_number", "ABCD123" },
                { "numbers", numbers },
                { "alphabets", alphabets },
                { "highest_lowercase_alphabet", highestLowercase != null ? new[] { highestLowercase } : new string[] { } }
            };

            return response;
        }

        public Dictionary<string, int> GetOperationCode()
        {
            return new Dictionary<string, int> { { "operation_code", 1 } };
        }
    }
}
