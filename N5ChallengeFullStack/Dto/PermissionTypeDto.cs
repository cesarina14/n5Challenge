using N5ChallengeFullStack.Model;

namespace N5ChallengeFullStack.Dto
{
    public class PermissionTypeDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PermissionTypeDto(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
