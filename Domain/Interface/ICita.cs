using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interface;
public interface ICita : IGenericRepository<Citas>
{
    Task<IEnumerable<Mascota>> FindCitasTrimestreVacunacion();
    Task<IEnumerable<Mascota>> GetPerVeterinario(string nombreVet);
}
