namespace TestWebApi.Models.Requests
{
    public class GroupRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public GroupModel ToModel()
        {
            return new GroupModel
            {
                Id = this.Id,
                Name = this.Name
            };
        }

    }
}
