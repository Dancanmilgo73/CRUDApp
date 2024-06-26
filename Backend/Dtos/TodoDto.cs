﻿using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos
{
    public class TodoDto
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
