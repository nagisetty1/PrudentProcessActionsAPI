using System.ComponentModel.DataAnnotations;

namespace PrudentProcessActionsAPI.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatus { get; set; }
        //add other properties here

    }

}
