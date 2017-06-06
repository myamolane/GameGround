using GameGround.Entity;
using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameGround.Tests.Fake
{
    public class DbSets
    {
        
        public class AccountDbSet : FakeDbSet<Account>
        {
            public override Account Find(params object[] keyValues)
            {
                return this.SingleOrDefault(t => t.Id == (long)keyValues.FirstOrDefault());
            }

            public override Task<Account> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
            {
                return new Task<Account>(() => Find(keyValues));
            }
        }

        public class PlayerDbSet : FakeDbSet<Player>
        {
            public override Player Find(params object[] keyValues)
            {
                return this.SingleOrDefault(t => t.Id == (long)keyValues.FirstOrDefault());
            }

            public override Task<Player> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
            {
                return new Task<Player>(() => Find(keyValues));
            }
        }

    }
}
