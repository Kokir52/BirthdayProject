using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RodjendaniProjekat.APIRecords;
using RodjendaniProjekat.Exceptions;
using RodjendaniProjekat.Handlers;
using RodjendaniProjekat.Handlers.addBirthday;
using RodjendaniProjekat.Handlers.edit;
using RodjendaniProjekat.Handlers.get;
using RodjendaniProjekat.Handlers.getAll;
using RodjendaniProjekat.Handlers.getMonth;
using RodjendaniProjekat.Handlers.getSorted;
using RodjendaniProjekat.Handlers.remove;
using RodjendaniProjekat.Models;
using RodjendaniProjekat.Services;

namespace RodjendaniProjekat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BirthdayController : ControllerBase
    {
        private readonly IBirthdayService _service;
        private readonly IHandler<addBirthdayRequest, addBirthdayResponse> _addBirthdayHandler;
        private readonly IHandler<getAllRequest, getAllResponse> _getAllHandler;
        private readonly IHandler<getRequest, getResponse> _getHandler;
        private readonly IHandler<RemoveRequest, RemoveResponse> _removeHandler;
        private readonly IHandler<editRequest, editResponse> _editHandler;
        private readonly IHandler<GetSortedRequest, GetSortedResponse> _getSortedHandler;
        private readonly IHandler<GetMonthRequest, GetMonthResponse> _getMonthHandler;
        private readonly IMapper _mapper;

        public BirthdayController(IBirthdayService service, IHandler<addBirthdayRequest, addBirthdayResponse> handler,
            IHandler<getAllRequest,getAllResponse> getAllHandler, IHandler<getRequest, getResponse> getHandler,
            IHandler<RemoveRequest, RemoveResponse> removeHandler, IHandler<editRequest, editResponse> editHandler,
            IHandler<GetSortedRequest, GetSortedResponse> getSortedHandler, IHandler<GetMonthRequest, GetMonthResponse> getMonthHandler,
            IMapper mapper)
        {
            _service = service;
            _addBirthdayHandler = handler;
            _getAllHandler = getAllHandler;
            _getHandler = getHandler;
            _removeHandler = removeHandler;
            _editHandler = editHandler;
            _getSortedHandler = getSortedHandler;
            _getMonthHandler = getMonthHandler;
            _mapper = mapper;
        }

        [HttpGet("getMonth/{month}")]
        public async Task<ActionResult<IEnumerable<Birthday>>> GetBirthdaysByMonth(int month)
        {
            if (month < 1 || month > 12)
                throw new ArgumentOutOfRangeException(nameof(month), "Month must be between 1 and 12.");
            GetMonthRequest request = new GetMonthRequest(month);
            GetMonthResponse response = await _getMonthHandler.Handle(request);

            var dto = _mapper.Map<IEnumerable<BirthdayResponseDto>>(response.GetBirthdays());
            return Ok(dto);
        }


        [HttpGet("getSorted")]
        public async Task<ActionResult<IEnumerable<Birthday>>> GetSorted()
        {
            var people = await _getSortedHandler.Handle(new GetSortedRequest());
            if (people == null)
                return NotFound();

            var dto = _mapper.Map<IEnumerable<BirthdayResponseDto>>(response.GetBirthdays());
            return Ok(dto);
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<IEnumerable<Birthday>>> GetAll()
        {
            var people = await _getAllHandler.Handle(new getAllRequest());
            if (people == null)
                return NotFound();
            var dto = _mapper.Map<IEnumerable<BirthdayResponseDto>>(people.GetBirthdays());
            return Ok(dto);
        }

        [HttpGet("get/{name}")]
        public async Task<ActionResult<IEnumerable<Birthday>>> GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Name cannot be empty.");
            }
            getRequest request = new getRequest(name);
            getResponse response = await _getHandler.Handle(request);
            IEnumerable<Birthday> birthday = response.getBirthday();
            if (birthday == null)
            {
                throw new BirthdayNotFoundException(name);
            }
            return Ok(_mapper.Map<BirthdayResponseDto>(birthday));
        }

        [HttpPost("add")]
        public async Task<ActionResult<IEnumerable<Birthday>>> AddBirthday([FromBody] BirthdayDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.FirstName))
            {
                return BadRequest("Name cannot be empty.");
            }

            var request = new addBirthdayRequest(_mapper.Map<Birthday>(dto));
            var response = await _addBirthdayHandler.Handle(request);

            return Ok(_mapper.Map<BirthdayResponseDto>(response.getResponseCode()));
        }

        [HttpDelete("remove/{name}")]
        public async Task<ActionResult<IEnumerable<Birthday>>> RemoveBirthday(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Name cannot be empty.");
            }
            RemoveRequest request = new RemoveRequest(name);
            RemoveResponse response = await _removeHandler.Handle(request);
            if (response.getResponseCode() == true)
            {
                return Ok(name + " has been removed.");
            }
            else
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("edit/{name}")]
        public async Task<ActionResult<IEnumerable<Birthday>>> EditBirthday([FromBody] BirthdayDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.FirstName) || string.IsNullOrWhiteSpace(dto.LastName))
            {
                return BadRequest("Name cannot be empty.");
            }
            editRequest request = new editRequest(_mapper.Map<Birthday>(dto));
            editResponse response = await _editHandler.Handle(request);

            return Ok(_mapper.Map<BirthdayResponseDto>(response.getBirthday().First()));
        }

        
   
    }
}
