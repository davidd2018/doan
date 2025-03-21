using System.ComponentModel.DataAnnotations;

namespace doan.Models
{
    public class Bai02Model
    {
        public int Id { get; set; }  // Khóa chính
        public string? TuVung { get; set; }
        public string? PhatAm { get; set; }
        public string? AmHan { get; set; }
        public string? HanTu { get; set; }
        public string? Nghia { get; set; }
    }
}
