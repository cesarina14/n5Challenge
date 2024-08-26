using N5ChallengeFullStack.Model;

namespace N5ChallengeFullStack.Dto
{
    public class PermissionDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long PermissionTypeId { get; set; }
        public PermissionDto(string _name, string _description, long _permission_type_id)
        {
       
            Name =_name;
            Description = _description;
            PermissionTypeId = _permission_type_id;
        }
    }
}
