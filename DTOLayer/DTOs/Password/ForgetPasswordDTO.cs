using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.Password
{
    public class ForgetPasswordDTO
    {
        [EmailAddress]
        public string? Mail { get; set; }
    }
}
