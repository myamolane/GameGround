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
    public class GameServiceTest : ServiceBase
    {
        private IGameService _service;
        private ILocalizedProvider provider;
        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            base.Container.RegisterType<IGameService, GameService>();

            var unitOfWork = base.Container.Resolve<IUnitOfWorkAsync>();

            //var game = new Game
            //{

            //    ObjectState = ObjectState.Added
            //};

            //unitOfWork.Repository<Game>().Insert(game);
            //unitOfWork.SaveChanges();
            unitOfWork.Repository<Account>().Insert(new Account
            {
                Id=2,
                Login = "test",
                Password = "password".Md5Encrypt(),
                ObjectState = ObjectState.Added,
                Player=new Player
                {
                    Id=2,
                    Sex=Sex.Male,
                    Name="test",
                    Birth=DateTime.Now,
                    Email="email",
                    ObjectState=ObjectState.Added
                }
            });
            
            unitOfWork.SaveChanges();
            
            provider = (ILocalizedProvider)this.Container.Resolve(typeof(ILocalizedProvider));
            this._service = base.Container.Resolve<IGameService>();
        }
        [TestMethod]
        public void AddGameShouldSuccess()
        {
            var model = new VmGame
            {
                Name="snake",
                Category=GameCategory.Relax,
                Description="des",
                Rule="rule",
                Id=1,
                AuthorId=2,
                Author="test"
            };
            try
            {
                this._service.AddGame(model);
            }
            catch
            {
                throw;
            }

        }
        [TestMethod]
        public void AddPlayerDuplicate()
        {

            //var model = new VmRegistry
            //{
            //    Name = "name",
            //    Sex = 0,
            //    Birth = "1996-10-29",
            //    Email = "test-email",
            //    Id = 3,
            //    Password = "555",
            //    CheckPassword = "555",
            //    Login = "test-login"
            //};
            //try
            //{
            //    this._service.AddPlayer(model);
            //}
            //catch (DuplicateDataException e)
            //{
            //    Console.WriteLine(e.GetErrorMessage());

            //    Console.WriteLine(e.Parameter);
            //}
            //catch
            //{
            //    throw;
            //}
        }
    }
}
