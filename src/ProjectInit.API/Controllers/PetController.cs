using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectInit.API.Interfaces;
using ProjectInit.Core.Entities;
using ProjectInit.Infrastructure.DTOs;
using ProjectInit.Repositories.Common;

namespace ProjectInit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
            private readonly IRepository<Pet, Guid> _petRepository;
            private readonly IMapper _mapper;
            private readonly IFileService _fileService;
            public PetController(IRepository<Pet,Guid> petRepository, IMapper mapper, IFileService fs)
            {
                _petRepository = petRepository;
                _mapper = mapper;
                _fileService = fs;
            }
            [HttpGet("get-all")]
            public async Task<IActionResult> GetAllPet()
            {
                var pets = _mapper.Map<IEnumerable<Pet>>(await _petRepository.GetAllAsync());
                return Ok(pets);
            }
        [HttpPost("add")]
        public async Task<ActionResult<Pet>> AddPet(PetCreateDto pet)
        {
            if (pet == null)
            {
                return BadRequest(pet);
            }
            if (pet.ImageFile != null)
            {
                var fileResult = _fileService.SaveIFormFile(pet.ImageFile, "pets");
                if (fileResult.Contains("Only") || fileResult.Contains("Error")) 
                {
                    return BadRequest(fileResult);
                }
                else
                {
                    pet.ImagePath = fileResult;
                }
        
                await _petRepository.CreateAsync(_mapper.Map<Pet>(pet));
                    return Ok(pet);
                }

                await _petRepository.CreateAsync(_mapper.Map<Pet>(pet));
                return Ok(pet);
            }
            [HttpGet("{id}")]
            public async Task<ActionResult<List<Pet>>> GetPet(Guid id)
            {
                var badge = await _petRepository.GetAsync(id);
                if (badge is null)
                    return NotFound("Pet not found");
                return Ok(badge);
            }



            [HttpDelete("delete/{id}")]
            public async Task<ActionResult> DeleteBadge(Guid id)
            {
                var pet = await _petRepository.GetAsync(id);
                if (pet is null)
                    return NotFound("Pet not found");
                _fileService.DeleteImage(pet.ImagePath, "pets");
                await _petRepository.DeleteAsync(pet.Id);
                return Ok($"Pet {pet.Id} deleted");
            }


            [HttpPut("update")]
            public async Task<ActionResult<Pet>> UpdateBadge(PetUpdateDto petDTO)
            {
                var pet = _mapper.Map<Pet>(petDTO);
                if (pet.Id == null)
                {
                    return BadRequest("Pet not found");
                }

                var existingPet = await _petRepository.GetAsync(pet.Id);
                if (existingPet == null)
                {
                    return NotFound("Badge not found");
                }

                existingPet.Type = petDTO.Type;
                existingPet.Name= petDTO.Name;

                if (petDTO.ImageFile!= null)
                {
                    _fileService.DeleteImage(existingPet.ImagePath,"pets");
                    var fileResult = _fileService.SaveIFormFile(petDTO.ImageFile, "pets");
                    if (fileResult.Contains("Only") || fileResult.Contains("Error"))
                {
                        return BadRequest(fileResult);
                    }
                else
                    {
                        existingPet.ImagePath = fileResult;
                    }
                }

                await _petRepository.UpdateAsync(existingPet);

                return Ok(existingPet);
            
        }
    }
}
