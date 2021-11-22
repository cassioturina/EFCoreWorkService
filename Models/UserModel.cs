using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreWorkService.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}
