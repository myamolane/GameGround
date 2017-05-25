using GameGround.Entity;
using GameGround.Entity.Mapping;
using System;
using System.Data.Entity;
using System.Linq;
namespace GameGround.Infrastructure
{
    public class GGContext : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“GGContext”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“GameGround.Infrastructure.GGContext”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“GGContext”
        //连接字符串。
        public GGContext()
            : base("name=GGContext")
        {

            Database.SetInitializer(new DropCreateDatabaseAlways<GGContext>());
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameRecord> GameRecords { get; set; }
        //public DbSet<HeartGame> HeartGames { get; set; }
        public DbSet<Player> Players { get; set; }
        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AccountMap());
            //modelBuilder.Configurations.Add(new GameMap());
            modelBuilder.Configurations.Add(new GameRecordMap());
            //modelBuilder.Configurations.Add(new HeartGameMap());
            modelBuilder.Configurations.Add(new PlayerMap());
        }

        static GGContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GGContext, Migrations.Configuration>());
        }
    }
    
    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}