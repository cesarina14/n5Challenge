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

        private readonly UnitOfWork _UnitOfWork;
        private readonly Repository<PermissionType> _respo;
        private readonly ElasticSearchService<PermissionType> _elasticSearchService;
        public PermissionTypeService(UnitOfWork _unit_of_work,
            Repository<PermissionType> _repository,
            ElasticSearchService<PermissionType> _elastic_search_service)
        {
            _UnitOfWork = _unit_of_work;
            _respo = _repository;
            _elasticSearchService = _elastic_search_service;

        }
        public PermissionTypeDto AddEntity(PermissionTypeDto _dto)
        {
            try
            {
                var _entity = new PermissionType
                {
                    Name = _dto.Name,
                    Description = _dto.Description,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedBy = "test",
                    UpdatedBy = "test",
                };
                _respo.AddEntity(_entity);
                _UnitOfWork.Commit();
                var response = _elasticSearchService.IndexDocumentAsync(_entity).GetAwaiter();
                return new PermissionTypeDto(_entity);


            }
            catch (Exception ex)
            {
                return null;
                /// save exception to log
            }


        }

        public List<PermissionTypeDto> GetList()
        {
            var _list = _respo.ListAll();
            var _dtoList = _list.Select(_p => new PermissionTypeDto(_p)).ToList();
            return _dtoList;
        }

        public async Task<bool> UpdateEntity(PermissionTypeDto _dto)
        {
            var _entity = _respo.GetSingle(_dto.Id);
            if (_entity == null) return false;

            _entity.Description = _dto.Description;
            _entity.Name = _dto.Name;
            _entity.UpdatedAt = DateTime.Now;
            _respo.Update(_entity);
            await _UnitOfWork.Commit();
            await _elasticSearchService.IndexDocumentAsync(_entity);
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

