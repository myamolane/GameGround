using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGround.Tests.Fake
{
    public class DbSets
    {
        /*
        public class UserDbSet : FakeDbSet<User>
        {
            public override User Find(params object[] keyValues)
            {
                return this.SingleOrDefault(t => t.Id == (long)keyValues.FirstOrDefault());
            }

            public override Task<User> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
            {
                return new Task<User>(() => Find(keyValues));
            }
        }
        */
    }
}
