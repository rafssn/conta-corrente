using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Transacoes.Api.Models
{
    public class MovementViewModel
    {
        [Required(ErrorMessage = "A valid type is required")]
        public MovementType Type { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        [Required(ErrorMessage = "Value is required")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "AccountId is required")]
        public int AccountId { get; set; }

    }
}
