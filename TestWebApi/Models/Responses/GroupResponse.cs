﻿using System.Collections.Generic;

namespace TestWebApi.Models.Responses
{
    public class GroupResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<StudentModel> Students { get; set; }

        public static GroupResponse Create(GroupModel groupModel, List<StudentModel> students)
        {
            return new GroupResponse
            {
                Id = groupModel.Id,
                Name = groupModel.Name,
                Students = students
            };
        }

    }
}
