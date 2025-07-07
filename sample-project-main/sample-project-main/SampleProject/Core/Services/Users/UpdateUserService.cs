using BusinessEntities;
using Common;
using System.Collections.Generic;
using System.Linq;

namespace Core.Services.Users
{
    [AutoRegister]
    public class UpdateUserService : IUpdateUserService
    {
        public void Update(User user, string name, string email, UserTypes type, decimal? annualSalary, int age, IEnumerable<string> tags)
        {
            user.SetEmail(email);
            user.SetName(name);
            user.SetType(type);
            user.SetAge(age);
            user.SetMonthlySalary(annualSalary.HasValue ? annualSalary.Value / 12 : (decimal?)null); //handle null reference exception
            user.SetTags(tags ?? Enumerable.Empty<string>()); //ensures you're never passing null - just an empty list
        }
    }
}