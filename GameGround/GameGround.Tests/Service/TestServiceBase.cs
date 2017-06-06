using GameGround.Api;
using GameGround.Tests.Fake;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace GameGround.Tests.Service
{
    //internal class LocalizedProvider : ILocalizedProvider
    //{
    //    public string GetString(string key)
    //    {
    //        return key;
    //    }
    //}

    public class ServiceBase
    {
        protected readonly UnityContainer Container = new UnityContainer();

        [TestInitialize]
        public virtual void Initialize()
        {
            var provider = LocalizedExceptionBase.LocalizedProvider = new LocalizedProvider();

            this.Container
                .RegisterInstance<IUnitOfWorkAsync>(new UnitOfWork(new GGFakeContext()))
                .RegisterType(typeof(IRepositoryAsync<>), typeof(Repository<>))
                .RegisterInstance<ILocalizedProvider>(provider);


        }

        [TestCleanup]
        public virtual void TestCleanup()
        {

        }
    }
}
