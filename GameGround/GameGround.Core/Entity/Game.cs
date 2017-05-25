using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGround.Entity
{
    public class GameInfo : IdentityEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Rule { get; set; }

        [ForeignKey("Author")]
        public long AuthorId { get; set; }
        public virtual Player Author{get;set;}
    }
    public class Game 
    {
        [ForeignKey("Id")]
        public long Id { get; set; }
        public GameInfo Info { get; set; }

        public long PlayedCount { get; set; }

        public virtual ICollection<Player> CollecttingPlayers { get; set; }

        public virtual ICollection<GameRecord> GameRecords { get; set; }
    }
    public class HeartGame
    {
        public virtual ICollection<Player> HearttingPlayers { get; set; }

    }
}
namespace GameGround.Entity.Mapping
{
    public class GameMap : IdentityKeyEntityMap<Game>
    {
        public GameMap()
        {
            this.ToTable("Games");

            this.HasMany(m => m.GameRecords).WithRequired(m => m.Game).WillCascadeOnDelete(false);

        }
    }
    public class HeartGameMap : IdentityKeyEntityMap<HeartGame>
    {
        public HeartGameMap()
        {
            this.ToTable("HeartGames");

            
        }
    }
}