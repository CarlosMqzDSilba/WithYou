using System.Collections.Generic;

namespace WithYou.Web.Data.Entities
{
    public class Gender : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection <Leader> Leaders { get; set; }
        public ICollection <Researcher> Researchers { get; set; }
    }
}
