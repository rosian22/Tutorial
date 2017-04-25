namespace Common.Enums
{
    [Foundation.Preserve(AllMembers = true)]
    public enum UserStatus : int
    {
        Rejected = -1,
        Pending = 0,
        Approved = 1,
        Deleted = 2
    }
}
