﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZavodConservbusinessLogic.Enums;

namespace ZavodConservDatabaseImplement.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int ConservId { get; set; }

        public int? ImplementerId { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public decimal Sum { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        [Required]
        public DateTime DateCreate { get; set; }

        public DateTime? DateImplement { get; set; }

        public Conserv Conserv { get; set; }

        public Client Client { get; set; }

        public Implementer Implementer { get; set; }
    }
}