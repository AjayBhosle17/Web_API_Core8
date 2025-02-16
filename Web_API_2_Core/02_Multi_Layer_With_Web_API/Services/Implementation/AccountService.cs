
using AutoMapper;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _repo;
    private readonly IMapper _mapper;

    public AccountService(IAccountRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public bool Login(string email, string password,out string roleName)
    {
        return _repo.Login(email, password,out roleName);
    }

    public async Task<bool> Register(UserModel user)
    {
       var User = _mapper.Map<User>(user);
       var result = await _repo.Register(User);
    
        return result;
    }
}