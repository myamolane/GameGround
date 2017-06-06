using GameGround.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGround.Core
{
    public interface IPlayerService
    {
        VmAccount Login(VmLogin model);

        void AddPlayer(VmRegistry model);

        void EditPlayer(VmPlayer model);
    }
}
