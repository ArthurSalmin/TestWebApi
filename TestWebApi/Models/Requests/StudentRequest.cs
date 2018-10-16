namespace TestWebApi.Models.Requests
{
    public class StudentRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Group_id { get; set; }

        public StudentModel ToModel()
        {
            return new StudentModel
            {
                Id = this.Id,
                Name = this.Name,
                Group_id = this.Group_id
            };
        }
            
    }
}
