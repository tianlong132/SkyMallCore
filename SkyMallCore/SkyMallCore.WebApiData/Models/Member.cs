﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SkyMallCore.WebApiData.Models
{
    [Table("Member")]
    public class Member
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
