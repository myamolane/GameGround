using GameGround.Core;
using GameGround.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameGround.ViewModel;
using Repository.Pattern.UnitOfWork;
using GameGround.Entity;
using Utility;
using System.Diagnostics;
using Repository.Pattern.Infrastructure;

namespace GameGround.Tests.Service
{
    [TestClass]
    public class playerServiceTest : ServiceBase
    {
        private IPlayerService _service;
        private ILocalizedProvider provider;
        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            base.Container.RegisterType<IPlayerService, PlayerService>();

            var unitOfWork = base.Container.Resolve<IUnitOfWorkAsync>();

            var player = new Player
            {
                Id = 1,
                Name = "test-name",
                Email = "test-email",
                Birth = DateTime.Parse("2017-5-29"),
                Sex = 0,
                Account = new Account
                {
                    Id = 1,
                    Login = "test-login",
                    Password = "test-password",
                    ObjectState = ObjectState.Added
                },
                ObjectState = ObjectState.Added
            };

            unitOfWork.Repository<Player>().Insert(player);
            unitOfWork.SaveChanges();
            //unitOfWork.Repository<Account>().Insert(new Account
            //{
            //    playerId = 1,
            //    CreatedAt = DateTime.Now,
            //    Login = "test",
            //    Password = "password".Md5Encrypt(),
            //    ObjectState = ObjectState.Added,
            //    player = player
            //});
            //unitOfWork.SaveChanges();
            provider = (ILocalizedProvider)this. Container.Resolve(typeof(ILocalizedProvider));
            this._service = base.Container.Resolve<IPlayerService>();
        }
        [TestMethod]
        public void AddPlayerShouldSuccess()
        {
            var model = new VmRegistry
            {
                Name = "name",
                Sex = 0,
                Birth = "2017-5-30",
                Password = "password",
                CheckPassword = "password",
                Email = "email",
                Login = "login"
            };
            try
            {
                this._service.AddPlayer(model);
            }
            catch
            {
                throw;
            }

        }
        [TestMethod]
        public void AddPlayerDuplicate()
        {
           
            var model = new VmRegistry
            {
                Name = "name",
                Sex = 0,
                Birth = "1996-10-29",
                Email = "test-email",
                Id = 3,
                Password = "555",
                CheckPassword = "555",
                Login = "test-login"
            };
            try
            {
                this._service.AddPlayer(model);
            }
            catch (DuplicateDataException e)
            {
                Console.WriteLine(e.GetErrorMessage());

                Console.WriteLine(e.Parameter);
            }
            catch
            {
                throw;
            }
        }
    }
}
