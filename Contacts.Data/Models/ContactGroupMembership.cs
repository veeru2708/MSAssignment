namespace Contacts.Data.Models
{
    class ContactGroupMembership
    {
        public int GroupMembershipId { get; set; }

        public int ParentId { get; set; }

        public int ChildId { get; set; }

        public string MemberShipType { get; set; }
    }
}
