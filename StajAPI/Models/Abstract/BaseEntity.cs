using System;
using StajAPI.Enums;
namespace StajAPI.Models.Abstract
{
    public abstract class BaseEntity
    {
        public int ID { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
