using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interface
{
    public interface IUserRepo
    {
        public UserDTO GetUser(int id);
        public bool AddUser(UserDTO user);
    }
}
