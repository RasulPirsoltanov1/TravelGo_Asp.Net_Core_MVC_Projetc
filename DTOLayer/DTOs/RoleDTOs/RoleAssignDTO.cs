using EntityLayer.Concrete;

namespace DTOLayer.DTOs.RoleDTOs
{
    public class RoleAssignDTO
    {
        public int RoleId { get; set; }
        public string RoleName{ get; set; }
        public bool RoleExists{ get; set; }
    }
}
