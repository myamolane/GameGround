using GameGround.Entity;
using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Pattern.DataContext;
using static GameGround.Tests.Fake.DbSets;

namespace GameGround.Tests.Fake
{
    public class GGFakeContext : FakeDbContext
    {
        public GGFakeContext()
        {
            AddFakeDbSet<Account, AccountDbSet>();
            AddFakeDbSet<Player, PlayerDbSet>();
        }
    }
}
