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

        public virtual Account Account { get; set; }

        //public virtual ICollection<Player> friends { get; set; }

        public virtual ICollection<GameRecord> GameRecords { get; set; }
        
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
            //this.HasOptional(m => m.Account).WithRequired(m => m.Player).WillCascadeOnDelete(true);

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
                    table.ToTable("CollectGame");
                });
            //this.HasMany(m => m.friends)
            //    .WithMany(m => m.friends)
            //    .Map(table =>
            //            {
            //                table.MapLeftKey("Player1_Id");
            //                table.MapRightKey("Player2_Id");
            //                table.ToTable("Friends");
            //            });
        }
    }
}
