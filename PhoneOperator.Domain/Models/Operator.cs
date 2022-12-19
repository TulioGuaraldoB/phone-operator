using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneOperator.Domain.Models
{
    public class Operator
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int OperatorCode { get; set; }
    }
}