using System.ComponentModel.DataAnnotations;

namespace Starbucks.Ecommerce.Infraestructure.Data.DataModels
{
    public class ProvinceDataModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Igv { get; set; }
    }
}
