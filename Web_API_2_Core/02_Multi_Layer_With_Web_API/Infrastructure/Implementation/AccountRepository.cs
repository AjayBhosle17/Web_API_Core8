using Data;

public class AccountRepository : IAccountRepository
{
    private readonly CoreDbContext _context;

    public AccountRepository(CoreDbContext context)
    {
        _context = context;
    }

    public  bool Login(string email, string password , out string roleName)
    {
       bool isExits =  _context.Users.Any(u=> u.Email == email && u.Password == password);

        if (isExits)
        {

            roleName = (from u in _context.Users
                        join ur in _context.UserRoles
                        on u.Id equals ur.UserId
                        join r in _context.Roles
                        on ur.RoleId equals r.Id
                        where u.Email == email && u.Password == password
                        select r.Name)?.FirstOrDefault();

        }
        else
        {
            roleName = "";
        }


        return isExits;
    }

    public async Task<bool> Register(User user)
    {
        _context.Users.Add(user);
        var NoOfUserAdded =  await _context.SaveChangesAsync();

        _context.UserRoles.Add(new UserRole() { UserId = user.Id, RoleId = 2 });
        var NoOfUserRoleAdded =  await _context.SaveChangesAsync();
      
        return NoOfUserAdded >0 && NoOfUserRoleAdded >0 ;
    }
}