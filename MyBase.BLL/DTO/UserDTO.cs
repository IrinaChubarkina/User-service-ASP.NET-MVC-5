﻿namespace MyBase.BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public byte[] Image { get; set; }
        public string PictureName { get; set; }

        public int ContactId { get; set; }
        public int PictureId { get; set; }
    }
}
