using N5ChallengeFullStack.Dto;
using N5ChallengeFullStack.Model;
using N5ChallengeFullStack.Repository;

namespace N5ChallengeFullStack.Service
{
    public class PermissionTypeService
    {

        private readonly UniOfWork _UnitOfWork;
        private readonly IRepository<PermissionType> _rep;
        public PermissionTypeService(UniOfWork _unit_of_work, IRepository<PermissionType> _repository)
        {
            _UnitOfWork = _unit_of_work;
            _rep = _repository;

        }
        public PermissionTypeDto AddEntity(PermissionType _entity)
        {
            try
            {
                _rep.AddEntity(_entity);
                _UnitOfWork.Commit();
            }
            catch (Exception ex)
            {
                return null;
               /// save exception to log
            }
            return new PermissionTypeDto(_entity);
          
        }

        public List<PermissionTypeDto> GetList()
        {
            var _list = _rep.ListAll();
            var _dtoList = _list.Select(_p => new PermissionTypeDto(_p)).ToList();
            return _dtoList;
        }

        public bool UpdateEntity(PermissionType entity)
        {
            var _entity = _rep.GetSingle(entity.Id);
            if (_entity == null) return false;
 
            _rep.Update(entity);
            _UnitOfWork.Commit();
            return true;

        }
        public PermissionTypeDto GetSingle(long Id)
        {
            var _entity = _rep.GetSingle(Id);
            if (_entity == null) return null;

            return new PermissionTypeDto(_entity);

        }
        public bool Remove(long Id)
        {
            var _entity = _rep.GetSingle(Id);
            if (_entity == null) return false;
            _rep.Remove(_entity);
            _UnitOfWork.Commit();

            return true;

        }
    }
}

