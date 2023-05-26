using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dolphin.Freight
{
    public class CreateUpdateAccountGroupDto
    {
        [Required]
        [StringLength(324)]
        public string AccountGroupName { get; set; }    
    }
}
