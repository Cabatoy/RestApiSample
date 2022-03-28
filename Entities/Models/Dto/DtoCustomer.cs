using Entities.Abstract;

namespace EntitiesAndCore.Models.Dto
{
    public class DtoCustomer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Nationality { get; set; }
        public string NationalityNumber { get; set; }
        public string PhoneNumber { get; set; }
        public CustomerStatus CustomerStatus { get; set; }
        public bool Deleted { get; set; }
    }
}
