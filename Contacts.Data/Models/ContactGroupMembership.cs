namespace Contacts.Data.Models
{
    public class ContactGroupMembership
    {
        public int ContactGroupMembershipId { get; set; }

        public int ParentContactGroupId { get; set; }

        public int ContactGroupId { get; set; }

        public int ContactId { get; set; }

        public string MemberShipType { get; set; }
    }
}
