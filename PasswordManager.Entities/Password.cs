﻿using KARA.NET.Entities;

namespace PasswordManager.Entities;
public class Password
    : BaseEntity<Guid>
{
    public string Name { get; set; }
    public byte[] Value { get; set; }
}