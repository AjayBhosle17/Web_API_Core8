public class Role
{

    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<UserRole> userRoles  { get; set; }
}