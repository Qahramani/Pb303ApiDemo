﻿using Microsoft.AspNetCore.Identity;

namespace Shop.Domain.Entities;

public class AppUser : IdentityUser
{
    public required string FullName { get; set; }
}
