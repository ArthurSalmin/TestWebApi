namespace TestWebApi.Models.Responses
{
    public class StudentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Group_id { get; set; }

        public static StudentResponse Create(StudentModel studentModel)
        {
            return new StudentResponse
            {
                Id = studentModel.Id,
                Name = studentModel.Name,
                Group_id = studentModel.Group_id
            };
        }
    }
}
