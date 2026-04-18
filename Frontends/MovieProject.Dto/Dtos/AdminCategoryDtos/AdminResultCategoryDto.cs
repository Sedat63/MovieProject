using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Dto.Dtos.AdminCategoryDtos
{
    public class AdminResultCategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int MovieCount { get; set; } //film sayısı
        public int ReviewCount { get; set; } // yorum sayısı
        public double AvgRating { get; set; } //  ortalama rating
        public bool IsActive { get; set; }
    }
}
