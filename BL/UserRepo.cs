using AutoMapper;
using BL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UserRepo : IUserRepo
    {
        private readonly IMapper _mapper;
        public UserRepo(IMapper mapper)
        {
            _mapper = mapper;
        }
        public bool AddUser(UserDTO user)
        {
            try
            {
                var userDB = _mapper.Map<User>(user);
                using (var context = new HmocaronaContext())
                {
                    context.Add(userDB);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public UserDTO GetUser(int id)
        {
            try
            {
                using (var context = new HmocaronaContext())
                {
                    var user = context.Users.FirstOrDefault(u => u.Id == id);
                    user.Vaccinations= context.Vaccinations.Where(u => u.UserId == id).ToList();
                    user.Sicks = context.Sicks.Where(u => u.UserId == id).ToList();
                    return _mapper.Map<UserDTO>(user);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
