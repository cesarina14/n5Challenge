using N5ChallengeFullStack.Model;

namespace N5ChallengeFullStack.Dto
{
    public class PermissionDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long? PermissionTypeId { get; set; }
        public PermissionDto( Permission _entity)
        {
            Id = _entity.Id;
            Name = _entity.Name;
            Description = _entity.Description;
            PermissionTypeId = _entity.PermissionTypeId;
        }
    }
}
