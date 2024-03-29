﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestingCore.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool IsSuscribedInNewsletter { get; set; }
        public byte MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }
    }
}
