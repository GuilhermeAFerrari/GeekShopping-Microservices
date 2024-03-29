﻿using GeekShopping.Product.API.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.Product.API.Models
{
    [Table("product")]
    public class ProductEntity : BaseEntity
    {
        [Column("name")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; } = null!;

        [Column("price")]
        [Required]
        [Range(1, 10000)]
        public decimal Price { get; set; }

        [Column("description")]
        [StringLength(500)]
        public string Description { get; set; } = null!;

        [Column("category_name")]
        [StringLength(50)]
        public string CategoryName { get; set; } = null!;

        [Column("image_url")]
        [StringLength(300)]
        public string ImageUrl { get; set; } = null!;
    }
}
