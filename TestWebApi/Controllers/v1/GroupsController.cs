using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestWebApi.Models;
using TestWebApi.Interfaces;
using TestWebApi.Models.Requests;
using System.Collections.Generic;

namespace TestWebApi.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IStudentRepository _studentRepository;

        public GroupsController(IGroupRepository groupRepository, IStudentRepository studentRepository)
        {
            _groupRepository = groupRepository;
            _studentRepository = studentRepository;
        }

        [Route("{Create}")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]GroupRequest groupRequest)
        {
            if (groupRequest == null)
            {
                return BadRequest();
            }

            var model = groupRequest.ToModel();
            var newGroup = await _groupRepository.PostAsync(model);
            return Ok(GroupResponse.Create(newGroup, new List<StudentModel>()));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var groups = await _groupRepository.GetAsync();
            List<GroupResponse> allGroups = new List<GroupResponse>();
            foreach (var item in groups)
            {
                allGroups.Add(GroupResponse.Create(item, await _studentRepository.GetStudentsByGroupIdAsync(item.Id)));
            }

            return Ok(allGroups);
        }

        [HttpGet("Names")]
        public async Task<IActionResult> GetAllNames()
        {
            var groupsNames = await _groupRepository.GetNamesAsync();
            if (groupsNames == null)
            {
                return NotFound();
            }

            return Ok(groupsNames);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            var group = await _groupRepository.GetAsync(id);
            if (group == null)
            {
                return NotFound();
            }

            var students = await _studentRepository.GetStudentsByGroupIdAsync(group.Id);
            var response = GroupResponse.Create(group, students);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> PutGroup([FromBody] GroupRequest groupRequest)
        {
            if (groupRequest == null || groupRequest.Id < 0)
            {
                return BadRequest();
            }

            var changedGroup = await _groupRepository.PutAsync(groupRequest.ToModel());
            if (changedGroup == null)
            {
                return NotFound();
            }

            var response = GroupResponse.Create(changedGroup, await _studentRepository.GetStudentsByGroupIdAsync(changedGroup.Id));
            return Ok(response);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            await _groupRepository.Delete(id);
            return Ok();
        }
    }
}