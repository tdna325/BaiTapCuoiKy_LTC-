﻿namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [StringLength(255)]
        [Required(ErrorMessage ="Không được để trống")]
        public string ID { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Không được để trống")]
        public string Name { get; set; }

        [Column(TypeName = "money")]
        [Required(ErrorMessage = "Không được để trống")]
        public decimal? UnitCost { get; set; }
        [Range(0,Int32.MaxValue, ErrorMessage ="Bạn phải nhập số")]
        public int? Quantity { get; set; }

        [StringLength(255)]
        public string Category_ID { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        [StringLength(255)]
        public string Status { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
        public virtual Category Category { get; set; }
    }
}
