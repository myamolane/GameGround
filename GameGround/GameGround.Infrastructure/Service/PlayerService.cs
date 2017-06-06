using GameGround.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameGround.ViewModel;
using GameGround.Entity;
using Repository.Pattern.UnitOfWork;
using System.Data.Entity;
using Utility;
using Repository.Pattern.Infrastructure;

namespace GameGround.Infrastructure
{
    public class PlayerService : ServiceBase, IPlayerService
    {
        public PlayerService(IUnitOfWorkAsync unitOfWork) : base(unitOfWork)
        {

        }

        public VmAccount Login(VmLogin model)
        {
            if (string.IsNullOrEmpty(model.Login) && string.IsNullOrEmpty(model.Password))
                return new VmAccount
                {
                    Name = "Tourist",
                    Login = "tourist",
                    Id = -1
                };
            ValidationProvider.Validate(model);
            var repository = UnitOfWork.Repository<Account>();
            
            var entity = repository.Queryable().Include(m => m.Player).Where(m => m.Login == model.Login).FirstOrDefault();
            if (entity == null) throw new DataNotFoundException("User");

            if (entity.Password != ("GG" + model.Password + model.Login).Md5Encrypt()) throw new LocalizedException("IncorrectPassword");
            
            return new VmAccount
            {
                Name = entity.Player.Name,
                Login = entity.Login,
                Id = entity.Id
            };
            
        }
        public void EditPlayer(VmPlayer model)
        {
            var repository = base.UnitOfWork.Repository<Player>();
            var entity = repository.Find(model.Id);
            entity.Name = model.Name;
            entity.Sex = model.Sex;
            entity.Birth = DateTime.Parse(model.Birth);
            repository.Update(entity);
            base.UnitOfWork.SaveChanges();
        }
        public void AddPlayer(VmRegistry model)
        {
            ValidationProvider.Validate(model);
            var repository = base.UnitOfWork.Repository<Player>();
            var exist_entity=repository.Queryable().FirstOrDefault(m => m.Account.Login == model.Login || m.Email == model.Email);
            if (exist_entity!=null)
            {
                if (exist_entity.Email == model.Email)
                    throw new DuplicateDataException("Email");
                else
                    throw new DuplicateDataException("Login");
            }
            var entity = new Player
            {
                Name = model.Name,
                Birth = DateTime.Parse(model.Birth),
                Sex = model.Sex,
                Email = model.Email,
                ObjectState = ObjectState.Added,
                Account = new Account
                {
                    Login = model.Login,
                    Password = ("GG"+model.Password+model.Login).Md5Encrypt(),
                    CreateAt = DateTime.Now,
                    ObjectState = ObjectState.Added,
                }
            };
            repository.Insert(entity);
            base.UnitOfWork.SaveChanges();
        }
    }
}
