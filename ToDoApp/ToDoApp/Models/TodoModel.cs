﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Models
{
    public class TodoModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
