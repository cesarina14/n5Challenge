using Microsoft.EntityFrameworkCore;
using N5ChallengeFullStack.Dto;
using N5ChallengeFullStack.Model;
using N5ChallengeFullStack.Repository;

namespace N5ChallengeFullStack.Service
{
    public class PemissionService 
    {
        private readonly UniOfWork _UnitOfWork;
        private readonly IRepository<Permission> _rep;
        public PemissionService( UniOfWork _unit_of_work, IRepository<Permission> _repository)
        {
            _UnitOfWork = _unit_of_work;
            _rep = _repository;

        }
        public PermissionDto AddEntity(Permission _entity)
        {
            try
            {
                 _rep.AddEntity(_entity);
                _UnitOfWork.Commit();
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public List<PermissionDto> GetList()
        {
            var _list = _rep.ListAll();
            var _dtoList =  _list.Select( _p=>  new PermissionDto(_p)).ToList();
            return _dtoList;
        }

        public bool UpdateEntity(Permission entity)
        {
           var _entity = _rep.GetSingle(entity.Id);
            if(_entity == null)
            {
                return false;

            }
            _rep.Update(entity);
            _UnitOfWork.Commit();
            return true;

        }
        public PermissionDto GetSingle(long Id)
        {
            var _entity = _rep.GetSingle(Id);
            if (_entity == null) return null;
       
            return new PermissionDto(_entity);

        }
        public bool  Remove(long Id)
        {
            var _entity = _rep.GetSingle(Id);
            if (_entity == null) return false;
             _rep.Remove(_entity);
            _UnitOfWork.Commit();

            return true;

        }
    }
}
