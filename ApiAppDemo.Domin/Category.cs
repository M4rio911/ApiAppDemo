﻿using ApiAppDemo.Domain.Common;
namespace ApiAppDemo.Domin.Entities;

public class Category : AuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
