using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.Models.Domain.HomeWork;
using SchoolAdministration.Models.DTO;
using SchoolAdministration.Repositories.Interfaces;


namespace SchoolAdministration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeWorkController : ControllerBase
    {
        private readonly IHomeWorkRepository _homeWorkRepository;
        private readonly ILogger<HomeWorkController> _logger;
        private readonly IMapper _mapper;

        public HomeWorkController(IHomeWorkRepository homeWorkRepository, ILogger<HomeWorkController> logger, IMapper mapper)
        {
           _homeWorkRepository = homeWorkRepository;
           _logger = logger;
           _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CourseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<HomeWorkDTO>>> GetAllHomeWorks()
        {
            var allHomeWorks = await _homeWorkRepository.GetAllAsync();
            var HomeWorkDTO = _mapper.Map<List<HomeWorkDTO>>(allHomeWorks);
            return Ok(HomeWorkDTO);
        }

        [HttpGet("getById/{id}")]
        [ProducesResponseType(typeof(ClassDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CourseDTO>> GetHomeworkById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var homeWork = await _homeWorkRepository.GetByIdAsync(id);

            if (homeWork == null)
            {
                return NotFound();
            }

            var homeWorkDTO = _mapper.Map<HomeWorkDTO>(homeWork);
            return Ok(homeWorkDTO);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ClassDTO>> CreateHomeWork(HomeWorkCreateDTO homeWorkCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            HomeWork homeWork = _mapper.Map<HomeWork>(homeWorkCreateDTO);

            await _homeWorkRepository.AddHomeWorkAsync(homeWork);
            return CreatedAtAction(nameof(GetHomeworkById), new { id = homeWork.Id }, homeWork);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateHomeWorkAsync(int id, HomeWorkUpdateDTO homeWorkUpdateDTO)
        {
            if (id != homeWorkUpdateDTO.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            HomeWork homeWork = _mapper.Map<HomeWork>(homeWorkUpdateDTO);
            await _homeWorkRepository.UpdateHomeWorkAsync(homeWork);
            return CreatedAtAction(nameof(GetHomeworkById), new { id = homeWork.Id }, homeWork);
        }
    }
}
