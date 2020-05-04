using DocuSign.eSign.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace WithYou.Web.Data.Entities
{
    public class Researcher : IEntity
    {
        public int Id { get; set; }
        public User User { get; set; }
        public SpecialtyClass SpecialtyClass { get; set; }
    }
}
