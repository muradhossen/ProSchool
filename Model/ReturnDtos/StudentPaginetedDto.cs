using Model.Entities;

namespace Model.ReturnDtos
{
    public class StudentPaginetedDto
    {
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
        public IEnumerable<StudentReturnDto> Data { get; set; }
    }
}
