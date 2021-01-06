namespace Contacts.Data.Models
{
    public class ContactGroup
    {

        public int ContactGroupId { get; set; }
        public string ContactGroupName { get; set; }

        public int CreatedDate { get; set; }

        public int ModifiedDate { get; set; }

        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
    }
}
