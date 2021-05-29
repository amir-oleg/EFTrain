using System;
using System.ComponentModel.DataAnnotations;

namespace EFTrain.Entites
{
    public class CreditCard
    {
        public int CreditCardId { get; set; }
        [Required]
        public ulong Number { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }
        [Required]
        public byte CVC { get; set; }
        [Required]
        public string CardHolder { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
