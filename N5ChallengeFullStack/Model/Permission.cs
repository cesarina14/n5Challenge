namespace N5ChallengeFullStack.Model
{
    public partial class Permission
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long? PermissionTypeId { get; set; }
        public DateTime? CreatedAt { get; set; } 
        public DateTime? UpdatedAt { get; set; }
        public PermissionType PermissionType { get; set; }

    }
}
