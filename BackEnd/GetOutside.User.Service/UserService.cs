using AutoMapper;
using FluentValidation;
using GetOutside.User.Domain.In;
using GetOutside.User.Repository;
using System.Threading.Tasks;

namespace GetOutside.User.Service
{
    public interface IUserService
    {
        Task<bool> Insert(UserCreateIn userCreateIn);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        private readonly IUserCreateInValidator _userCreateInValidator;

        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, 
            IUserCreateInValidator userCreateInValidator, 
            IMapper mapper)
        {
            _userRepository = userRepository;
            _userCreateInValidator = userCreateInValidator;
            _mapper = mapper;
        }

        public async Task<bool> Insert(UserCreateIn userCreateIn)
        {
            await _userCreateInValidator.ValidateAndThrowAsync(userCreateIn);

            var user = _mapper.Map<UserCreateIn, Domain.User>(userCreateIn);

            await _userRepository.InsertOneAsync(user);

            return true;
        }
    }
}
