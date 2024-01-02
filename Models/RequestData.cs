using System.ComponentModel.DataAnnotations;

namespace PrudentProcessActionsAPI.Models
{
    public class RequestData
    {
        [Key]
        public int RequestDataId { get; set; }
        public string JsonData { get; set; }
    }
}
