using System.ComponentModel.DataAnnotations;

namespace PrudentProcessActionsAPI.Models
{
    public class OrderCancellation
    {
        [Key]
        public int OrderCancellationId { get; set; }
        public string Reason { get; set; }
        // Add other properties as needed
    }
}
