namespace N5ChallengeFullStack.Model
{
    public partial class PermissionType
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public ICollection<Permission> Permissions { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
