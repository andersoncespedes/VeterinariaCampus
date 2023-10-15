using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interface;
public interface IUser : IGenericRepository<Usuario>
{
    Task<Usuario> GetByUsernameAsync(string username);
    Task<Usuario> GetByRefreshTokenAsync(string username);
}
