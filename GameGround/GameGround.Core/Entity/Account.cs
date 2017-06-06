using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryEntity=Repository.Pattern.Ef6.Entity;
namespace GameGround.Entity
{
    public class Account : RepositoryEntity
    {
        [ForeignKey("Player")]
        public long Id { get; set; }

        public virtual Player Player { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public DateTime? CreateAt { get; set; }

    }
}
namespace GameGround.Entity.Mapping
{
    public class AccountMap:EntityTypeConfiguration<Account>
    {
        public AccountMap()
        {
            this.ToTable("Accounts");

            this.HasKey(m => m.Id);
            this.HasRequired(m => m.Player).WithOptional(m => m.Account);
            this.Property(m => m.Login).IsRequired().HasMaxLength(50).IsUnique();
            this.Property(m => m.Password).IsRequired().HasMaxLength(32).IsFixedLength();
        }
    }
}
