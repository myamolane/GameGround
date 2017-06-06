using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace GameGround.Entity
{
    public class GameInfo : IdentityEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Rule { get; set; }
        public GameCategory Category { get; set; }

        [ForeignKey("Author")]
        public long AuthorId { get; set; }
        public virtual Player Author { get; set; }

        public virtual Game Game{get;set;}
        public virtual HeartGame HeartGame { get; set; }
    }
    public class Game : Repository.Pattern.Ef6.Entity
    {
        [ForeignKey("Info")]
        public long Id { get; set; }
        public virtual GameInfo Info { get; set; }

        public long PlayedCount { get; set; }

        public virtual List<Player> CollecttingPlayers { get; set; }

        public virtual List<GameRecord> GameRecords { get; set; }
    }
    public class HeartGame : Repository.Pattern.Ef6.Entity
    {
        [ForeignKey("Info")]
        public long Id { get; set; }
        public virtual GameInfo Info { get; set; }
        public virtual List<Player> HearttingPlayers { get; set; }

    }
}
namespace GameGround.Entity.Mapping
{
    public class GameMap : EntityTypeConfiguration<Game>
    {
        public GameMap()
        {
            this.ToTable("Games");
            this.HasKey(m => m.Id);
            this.HasRequired(m => m.Info).WithOptional(m => m.Game);
            this.HasMany(m => m.GameRecords).WithRequired(m => m.Game).WillCascadeOnDelete(false);

            

        }
    }
    public class HeartGameMap : EntityTypeConfiguration<HeartGame>
    {
        public HeartGameMap()
        {
            this.ToTable("HeartGames");
            this.HasKey(m => m.Id);
            
            this.HasRequired(m => m.Info).WithOptional(m => m.HeartGame);
        }
    }
}