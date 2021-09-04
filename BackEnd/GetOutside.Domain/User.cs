using FluentValidation;
using GetOutside.Core;
using GetOutside.Core.Domain;
using System;

namespace GetOutside.User.Domain
{
    [BsonCollection("user")]
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserState State { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }

    public interface IUserValidator : IValidator<User> { }
    public class UserValidator : AbstractValidator<User>, IUserValidator
    {
        public UserValidator()
        {
            RuleFor(user => user.UserName).NotEmpty().NotNull();
            RuleFor(user => user.Password).NotEmpty().NotNull().MinimumLength(8);
        }
    }
}
