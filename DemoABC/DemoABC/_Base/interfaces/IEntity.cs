using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoABC.Base.interfaces
{
    public class Entity<TPrimaryKey> : IEntity<TPrimaryKey> where TPrimaryKey : struct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TPrimaryKey Id { get; set; }
    }

    public interface IEntity<TPrimaryKey> where TPrimaryKey : struct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TPrimaryKey Id { get; set; }
    }
}
