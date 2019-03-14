namespace MyBase.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
        public int? PictureId { get; set; }
        public Picture Picture { get; set; }
        public bool IsDeleted { get; set; }
    }
}
