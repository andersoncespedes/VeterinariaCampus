using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class EspecieWithPetDto
    {
        public string Nombre { get; set; }
        public ICollection<MascotaDto> Mascotas { get; set; }
    }
}