namespace PediosEvertec.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pedido")]
    public partial class Pedido
    {
        public int id { get; set; }

        [StringLength(80)]
        public string customer_name { get; set; }

        [StringLength(120)]
        public string customer_email { get; set; }

        [StringLength(40)]
        public string customer_mobile { get; set; }

        [StringLength(80)]
        public string customer_lastname { get; set; }

        [StringLength(50)]
        public string customer_document { get; set; }

        [StringLength(20)]
        public string status { get; set; }

        [StringLength(50)]
        public string requestId { get; set; }

        [StringLength(150)]
        public string processUrl { get; set; }

        public DateTime? created_at { get; set; }

        public DateTime? fechaProcess { get; set; }

        public DateTime? updated_at { get; set; }

        public int? product_id { get; set; }

        public virtual product product { get; set; }
    }
}
