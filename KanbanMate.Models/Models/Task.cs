﻿namespace KanbanMate.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }  
        public string? Description { get; set; }
        public ICollection<Phase> Phase { get; set; }
    }
}