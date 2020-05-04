using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WithYou.Web.Data.Entities
{
    public class Manager:IEntity
    {
        public int Id { get; set; }
        public User User { get; set; }
    }
}
