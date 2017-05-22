using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Repository.Pattern.Infrastructure;

namespace Beian.Entity
{
    public abstract class IdentityEntity : Repository.Pattern.Ef6.Entity
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }
    }
}

namespace Beian.Entity.Mapping
{
    public abstract class KeyEntityMap<T> : EntityTypeConfiguration<T>
            where T : IdentityEntity
    {
        protected KeyEntityMap()
        {
            this.HasKey(m => m.Id);
        }
    }

    public abstract class IdentityKeyEntityMap<T> : KeyEntityMap<T>
        where T : IdentityEntity
    {
        protected IdentityKeyEntityMap()
        {
            this.Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}