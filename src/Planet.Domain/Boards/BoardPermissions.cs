namespace Planet.Domain.Boards
{
    [Flags]
    public enum BoardPermissions : short
    {
        View = 0,
        ChangeSpecs = 1,
        InviteMember = 2,
        ManageMembers = 4,
        ManageLists = 8,
        CreateAndEditCard = 16,
        AssignCard = 32,
        EditAssignedCard = 64,
        EditNotOwnedCard = 128,

        All = View
            | ChangeSpecs
            | InviteMember
            | ManageMembers
            | ManageLists
            | CreateAndEditCard
            | AssignCard
            | EditAssignedCard
            | EditNotOwnedCard
    }
}
