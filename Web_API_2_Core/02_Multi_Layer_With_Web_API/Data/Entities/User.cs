﻿public class User
{

    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public ICollection<UserRole> Roles { get; set; }    
}