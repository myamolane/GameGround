using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;
using RepositoryEntity=Repository.Pattern.Ef6.Entity;
namespace GameGround.Entity
{
    public class Player : IdentityEntity
    {
        public string Name { get; set; }

        public Sex Sex { get; set; }

        public DateTime Birth { get; set; }

        public string Email { get; set; }

        public virtual Account Account { get; set; }

        public virtual List<GameRecord> GameRecords { get; set; }
        
        public virtual List<Game> CollectedGames { get; set; }

        public virtual List<HeartGame> HearttedGames { get; set; }

        
    }
}
namespace GameGround.Entity.Mapping
{
    public class PlayerMap : IdentityKeyEntityMap<Player>
    {
        public PlayerMap()
        {
            this.ToTable("Players");

            this.HasMany(m => m.GameRecords).WithRequired(m => m.Player).WillCascadeOnDelete(false);
            this.Property(m => m.Name).IsRequired().HasMaxLength(50);
            this.Property(m => m.Email).IsRequired().HasMaxLength(64).IsUnique();
            this.HasMany(m => m.CollectedGames)
                .WithMany(m => m.CollecttingPlayers)
                .Map(table =>
                        {
                            table.MapLeftKey("PlayerId");
                            table.MapRightKey("GameId");
                            table.ToTable("CollectGame");
                        });

            this.HasMany(m => m.HearttedGames)
                .WithMany(m => m.HearttingPlayers)
                .Map(table =>
                {
                    table.MapLeftKey("GameId");
                    table.MapRightKey("PlayerId");
                    table.ToTable("HeartGame");
                });
            
        }
    }
}
