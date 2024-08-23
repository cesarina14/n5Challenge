using N5ChallengeFullStack.Model;

namespace N5ChallengeFullStack.Dto
{
    public class PermissionTypeDto
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public PermissionTypeDto( PermissionType _entity)
        {
            Id = _entity.Id;
            Description = _entity.Description;
        }
    }
}
