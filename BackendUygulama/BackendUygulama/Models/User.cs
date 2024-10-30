using System;
using System.Collections.Generic;

namespace BackendUygulama.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Name { get; set; }

    public string? Password { get; set; }

    public string? Mail { get; set; }

    public int? Role { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
