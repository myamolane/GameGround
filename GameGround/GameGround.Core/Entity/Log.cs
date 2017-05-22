using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Beian.Entity
{
    public class Log : IdentityEntity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public LogType Type { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public Log()
        {
            CreatedAt = DateTime.Now;
        }
    }
}

namespace Beian.Entity.Mapping
{
    public class LogMap : IdentityKeyEntityMap<Log>
    {
        public LogMap()
        {
            this.ToTable("Logs");

            this.Property(m => m.Name).IsRequired().HasMaxLength(50);
            this.Property(m => m.PhoneNumber).IsRequired().HasMaxLength(50);
        }
    }
}
