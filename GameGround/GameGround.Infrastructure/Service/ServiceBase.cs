using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGround.Infrastructure
{
    public abstract class ServiceBase
    {
        protected readonly IUnitOfWorkAsync UnitOfWork;
        protected ServiceBase(IUnitOfWorkAsync unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
            
        }
        
    }
}
