using GameGround.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGround.Core
{
    public interface IGameService
    {
        void AddGame(VmGameInfo model);

        List<VmGame> SearchGame(VmGameSearch condition, out long total);
    }
}
