using GameGround.Core.ViewModel;
using GameGround.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGround.Core.Service
{
    public interface IRecordService
    {
        void MakeRecord(List<VmRecord> records);
    }
}
