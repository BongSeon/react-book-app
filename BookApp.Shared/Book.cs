using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookApp.Shared
{
    public class BookBase
    {
        /// <summary>
        /// 일련 번호
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "번호")]
        public int Id { get; set; }
        /// <summary>
        /// 책 제목
        /// </summary>
        [MaxLength(255)]
        [Required(ErrorMessage = "책 제목을 입력하세요")]
        [Display(Name = "책 제목")]
        [Column(TypeName = "NVarChar(255)")]
        public string Title { get; set; }
        /// <summary>
        /// 책 설명
        /// </summary>
        [Display(Name = "책 설명")]
        public string Description { get; set; }
    }

    [Table("Books")]
    public class Book : BookBase
    {
        // PM> Install-Package System.ComponentModel.Annotations
        // PM> Install-Package System.ComponentModel.DataAnnotations

        // Empty
    }
}
