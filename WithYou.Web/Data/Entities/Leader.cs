﻿using System;
using System.ComponentModel.DataAnnotations;

namespace WithYou.Web.Data.Entities
{
    public class Leader : IEntity
    {
        public int Id { get; set; }
        public User User { get; set; }
    }
}
