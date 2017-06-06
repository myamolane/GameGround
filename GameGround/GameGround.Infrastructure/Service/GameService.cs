using GameGround.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Pattern.UnitOfWork;
using GameGround.ViewModel;
using GameGround.Entity;
using Utility;
using Repository.Pattern.Infrastructure;

namespace GameGround.Infrastructure
{
    public class GameService : ServiceBase, IGameService
    {

        public GameService(IUnitOfWorkAsync unitOfWork) : base(unitOfWork)
        {
        }
        public List<VmGame> SearchGame(VmGameSearch condition,out long total)
        {
            var repository = base.UnitOfWork.Repository<Game>();
            GameCategory category =(GameCategory)Convert.ToInt32(condition.Category);
            var query = from gameInfo in repository.Queryable()
                        select gameInfo;
            if (category != GameCategory.All)
                query = query.Where(m => m.Info.Category == category);
            if (!string.IsNullOrEmpty(condition.Name))
                query = query.Where(m => m.Info.Name.Contains(condition.Name));
            total = query.Count();
            return query.Select(m => new VmGame
            {
                Id = m.Id,
                Name = m.Info.Name,
                Description = m.Info.Description,
                Category = m.Info.Category,
                Rule = m.Info.Rule,
                Author=m.Info.Author.Name,
                AuthorId=m.Info.AuthorId
            }).ToList();

        }
        public void AddGame(VmGameInfo model)
        {
            
            var author = base.UnitOfWork.Repository<Player>().Queryable().FirstOrDefault(m=>m.Id==model.AuthorId);
            if (author==null || author.Name != "test")
                return;
            var repository = base.UnitOfWork.Repository<Game>();
            var entity = new Game
            {
                PlayedCount = 0,
                ObjectState=ObjectState.Added,

                Info = new GameInfo
                {
                    Name = model.Name,
                    AuthorId=model.AuthorId.Value,
                    Category = model.Category,
                    Description=model.Description,
                    Rule=model.Rule,
                    ObjectState=ObjectState.Added
                }
            };
            repository.Insert(entity);
            base.UnitOfWork.SaveChanges();
        }
    }
}
