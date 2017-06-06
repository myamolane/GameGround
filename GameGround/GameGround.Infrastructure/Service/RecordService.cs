using GameGround.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Pattern.UnitOfWork;
using GameGround.Entity;
using GameGround.Core.ViewModel;

namespace GameGround.Infrastructure.Service
{
    public class RecordService : ServiceBase, IRecordService

    {
        public RecordService(IUnitOfWorkAsync unitOfWork) : base(unitOfWork)
        {
        }

        public void MakeRecord(List<VmRecord> records)
        {
            
            throw new NotImplementedException();
        }
    }
}
