using System;
using System.Collections.Generic;

namespace BackendUygulama.Models;

public partial class Subtask
{
    public int Id { get; set; }

    public int MainTaskId { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime? Deadline { get; set; }

    public int Status { get; set; }

    public DateTime StatusDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public string Type { get; set; } = null!;

    public virtual Task MainTask { get; set; } = null!;
}
