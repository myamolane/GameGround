using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGround.Entity
{
    public class GameRecord : Repository.Pattern.Ef6.Entity
    {
        [ForeignKey("Game")]
        public long GameId { get; set; }
        public virtual Game Game { get; set; }

        [ForeignKey("Player")]
        public long PlayerId { get; set; }
        public virtual Player Player { get; set; }

        public long Score { get; set; }

        public long WinCount { get; set; }

        public long TotalCount { get; set; }
        
    }
}
namespace GameGround.Entity.Mapping
{
    public class GameRecordMap:EntityTypeConfiguration<GameRecord>
    {
        public GameRecordMap()
        {
            this.ToTable("GameRecords");

            this.HasKey(m => new { m.GameId, m.PlayerId });

            //this.HasRequired(m => m.Game).WithMany(m=>m.GameRecords).WillCascadeOnDelete(true);

            //this.HasRequired(m => m.Player).WithMany(m => m.GameRecords).WillCascadeOnDelete(true);
        }
    }
}

