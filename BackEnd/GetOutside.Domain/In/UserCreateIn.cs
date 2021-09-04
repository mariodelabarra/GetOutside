using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetOutside.User.Domain.In
{
    public class UserCreateIn
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public interface IUserCreateInValidator : IValidator<UserCreateIn> { }
    public class UserCreateInValidator : AbstractValidator<UserCreateIn>, IUserCreateInValidator
    {
        public UserCreateInValidator()
        {
            RuleFor(user => user.UserName).NotEmpty().NotNull();
            RuleFor(user => user.Password).NotEmpty().NotNull().MinimumLength(8);
        }
    }
}
