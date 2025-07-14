using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Practice2.Models;

public partial class UserList
{
    [Key]
    public int userId { get; set; }

    public string UserName { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public string? UserProfile { get; set; } 

    public string UserAddress { get; set; } = null!;

    public string UserRole { get; set; } = null!;

    public bool UserStatus { get; set; }
}
