using System;
using System.Collections.Generic;

namespace BackendUygulama.Models;

public partial class Task
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime? Deadline { get; set; }

    public int Status { get; set; }

    public DateTime StatusDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public string Type { get; set; } = null!;

    public int? Owner { get; set; }

    public int? CreatedBy { get; set; }

    public virtual User? OwnerNavigation { get; set; }

    public virtual ICollection<Subtask> Subtasks { get; set; } = new List<Subtask>();
}
