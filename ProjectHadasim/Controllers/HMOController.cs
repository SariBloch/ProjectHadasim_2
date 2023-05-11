using BL.Interface;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectHadasim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HMOController : ControllerBase
    {
        private IUserRepo _userRepo;
        public HMOController(IUserRepo userRepo)
        {

            _userRepo = userRepo;
        }

        [HttpGet("/{userId}")]

        public UserDTO GetUser(int userId)
        {
            return _userRepo.GetUser(userId);
        }

        [HttpPost]
        public bool AddUser(UserDTO userDTO)
        {
            return _userRepo.AddUser(userDTO);
        }
    }
}
