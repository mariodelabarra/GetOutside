using GetOutside.Core;
using GetOutside.Core.Repository;

namespace GetOutside.User.Repository
{
    public interface IUserRepository : IBaseRepository<Domain.User>
    {
    }

    public class UserRepository : BaseRepository<Domain.User>, IUserRepository
    {
        private readonly IBaseRepository<Domain.User> _userRepository;

        public UserRepository(IMongoDbSettings settings, IBaseRepository<Domain.User> userRepository) : base(settings)
        {
            _userRepository = userRepository;
        }
    }
}
