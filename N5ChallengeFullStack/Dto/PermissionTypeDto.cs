using N5ChallengeFullStack.Model;

namespace N5ChallengeFullStack.Dto
{
    public class PermissionTypeDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PermissionTypeDto( PermissionType _entity)
        {
            Id = _entity.Id;
            Description = _entity.Description;
            _entity.CreatedBy = "test";
            _entity.UpdatedBy = "test";
            _entity.UpdatedAt = DateTime.Now;
            _entity.CreatedAt = DateTime.Now;
        }
    }
}
