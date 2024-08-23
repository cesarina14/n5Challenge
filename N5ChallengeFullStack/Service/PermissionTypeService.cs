using N5ChallengeFullStack.Dto;
using N5ChallengeFullStack.Interface;
using N5ChallengeFullStack.Model;
using N5ChallengeFullStack.Repository;
using Nest;
using System.Security;


namespace N5ChallengeFullStack.Service
{
    public class PermissionTypeService
    {

        private readonly UniOfWork _UnitOfWork;
        private readonly Repository.IRepository<PermissionType> _respo;
        private readonly ElasticSearchService<PermissionType> _elasticSearchService;
        public PermissionTypeService(UniOfWork _unit_of_work, Repository.IRepository<PermissionType> _repository, ElasticSearchService<PermissionType> _elastic_search_service)
        {
            _UnitOfWork = _unit_of_work;
            _respo = _repository;
            _elasticSearchService = _elastic_search_service;

        }
        public PermissionTypeDto AddEntity(PermissionType _entity)
        {
            try
            {
                _respo.AddEntity(_entity);
                _UnitOfWork.Commit();
                var response = _elasticSearchService.IndexDocumentAsync(_entity).GetAwaiter();
            

            
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
            var _list = _respo.ListAll();
            var _dtoList = _list.Select(_p => new PermissionTypeDto(_p)).ToList();
            return _dtoList;
        }

        public bool UpdateEntity(PermissionType entity)
        {
            var _entity = _respo.GetSingle(entity.Id);
            if (_entity == null) return false;
 
            _respo.Update(entity);
            _UnitOfWork.Commit();
            _elasticSearchService.IndexDocumentAsync(_entity).GetAwaiter();
            return true;

        }
        public PermissionTypeDto GetSingle(long Id)
        {
            var _entity = _respo.GetSingle(Id);
            if (_entity == null) return null;

            return new PermissionTypeDto(_entity);

        }
        public bool Remove(long Id)
        {
            var _entity = _respo.GetSingle(Id);
            if (_entity == null) return false;
            _respo.Remove(_entity);
            _UnitOfWork.Commit();
   
            return true;

        }
    }
}

