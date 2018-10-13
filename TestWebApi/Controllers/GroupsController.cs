using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestWebApi.Models;
using TestWebApi.Interfaces;

namespace TestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupRepository _groupRepository;

        public GroupsController(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }
        [Route("{Create}")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]GroupModel group)
        {
            if (group == null)
            {
                return BadRequest();
            }
            var newGroup = await _groupRepository.PostAsync(group);
            return Ok(newGroup);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var groups = await _groupRepository.GetAsync();
            if (groups == null)
            {
                return NotFound();
            }
            return Ok(groups);
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
            return Ok(group);
        }

        [HttpPut]
        public async Task<IActionResult> PutGroup([FromBody] GroupModel group)
        {
            if (group == null || group.Id < 0)
            {
                return BadRequest();
            }
            var changedGroup = await _groupRepository.PutAsync(group);
            if (changedGroup == null)
            {
                return NotFound();
            }
            return Ok(changedGroup);

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