using Microsoft.EntityFrameworkCore;
using N5ChallengeFullStack.Dto;
using N5ChallengeFullStack.Model;
using N5ChallengeFullStack.Repository;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N5ChallengeFullStack.Service
{
    public class PermissionService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly Repository<Permission> _repository;
        private readonly ElasticSearchService<Permission> _elasticSearchService;

        public PermissionService(UnitOfWork unitOfWork, Repository<Permission> repository, ElasticSearchService<Permission> elasticSearchService)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _elasticSearchService = elasticSearchService ?? throw new ArgumentNullException(nameof(elasticSearchService));
        }

        public async Task<PermissionDto> Add(PermissionDto _dto)
        {
            try
            {
              
                var _entity = new Permission
                {
                    Name = _dto.Name,
                    Description = _dto.Description,
                    PermissionTypeId = _dto.PermissionTypeId,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedBy = "test",
                    UpdatedBy = "test",
                };
                _repository.AddEntity(_entity);

                await _unitOfWork.Commit();
                await _elasticSearchService.IndexDocumentAsync(_entity);

                return new PermissionDto(_entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in add: {ex.Message}");
                return null;
            }
        }

        public List<PermissionDto> GetList()
        {
            var list =  _repository.ListAll();
            return list.Select(p => new PermissionDto(p)).ToList();
        }

        public async Task<bool> UpdateEntityAsync(PermissionDto _dto)
        {
            var _entity = _repository.GetSingle(_dto.Id);
            if (_entity == null) return false;

            _entity.Description = _dto.Description;
            _entity.Name = _dto.Name;
            _entity.PermissionTypeId = _dto.PermissionTypeId;
            _entity.UpdatedAt = DateTime.Now;
            _repository.Update(_entity);
            await _unitOfWork.Commit();
            await _elasticSearchService.IndexDocumentAsync(_entity);

            return true;
        }

        public PermissionDto GetSingle(long id)
        {
            var entity =  _repository.GetSingle(id);
            return entity == null ? null : new PermissionDto(entity);
        }

        public async Task<bool> Remove(long id)
        {
            var entity =  _repository.GetSingle(id);
            if (entity == null)
            {
                return false;
            }

            _repository.Remove(entity);
            await _unitOfWork.Commit();

            return true;
        }
    }
}
