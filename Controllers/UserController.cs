using System.Threading.Tasks;
using AutoSAAS.Dtos;
using AutoSAAS.models;
using AutoSAAS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

//using AutoSAAS.Models;

namespace AutoSAAS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        private readonly DataContext _context;
        public UserController(IAuthRepository repo, IConfiguration config, DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _config = config;
            _repo = repo;
            _context = context;
        }


        // POST api/user/register
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {

            userForRegisterDto.Name = userForRegisterDto.Name.ToLower();

            if (await _repo.UserExists(userForRegisterDto.Name))
                return BadRequest("Name already exists");

            var userToCreate = new User
            {
                Name = userForRegisterDto.Name
            };

            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userFromRepo = await _repo.Login(userForLoginDto.Name.ToLower(), userForLoginDto.Password);

            if (userFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims), /* The subject part of the token */
                Expires = DateTime.Now.AddDays(1), /* Expiry Stamp */
                SigningCredentials = creds /* Securing hashed key */
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
        }


        // GET /api/user
        [HttpGet("")]
        public async Task<IActionResult> GetUsers()
        {
            var usersDto = new List<UserForDataDto>();
            var users = await _context.Users.ToListAsync();
            // Mapper.Map<User, UserForDataDto>
            foreach (var user in users)
            {
                
                usersDto.Add(_mapper.Map<UserForDataDto>(user));
            }
            return Ok(usersDto);
        }

        // GET /api/user/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            var userDto = _mapper.Map<UserForDataDto>(user);

            return Ok(userDto);
        }

 
        // PUT api/user/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserForDataDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            userDto.Id = id;
            var userInDb = _context.Users.SingleOrDefault(u => u.Id == id);
            if (userInDb == null)
                return NotFound();

            _mapper.Map(userDto, userInDb);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (DbUpdateException)
            {
                if (!CompanyExists(id))
                {
                    return NotFound("Company Id doesnt exist in database");
                }
                else if (!UserGroupExists(id))
                {
                    return NotFound("Company Id doesnt exist in database");
                }
                else
                {
                    throw;
                }
            }

            return Ok(userDto);
        }
        // // TODO: delete by id

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
        private bool CompanyExists(int id)
        {
            return _context.Companies.Any(e => e.Id == id);
        }
        private bool UserGroupExists(int id)
        {
            return _context.UserGroups.Any(e => e.Id == id);
        }
    }
}