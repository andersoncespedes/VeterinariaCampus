using Microsoft.AspNetCore.Mvc;
using API.Dtos;
using API.Helpers;
using Domain.Interface;
using Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class PropietarioController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public PropietarioController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [MapToApiVersion("1.1")]
    [Authorize(Roles = "Administrador, Empleado")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<PropietarioDto>>> Paginacion([FromQuery] Params productParams)
    {
        var products = await _unitOfWork.Propietarios.paginacion(productParams.PageIndex, productParams.PageSize, productParams.Search);
        var mapeo = _mapper.Map<List<PropietarioDto>>(products.registros);
        return new Pager<PropietarioDto>(mapeo, products.totalRegistros, productParams.PageIndex, productParams.PageSize, productParams.Search);
    }
    [MapToApiVersion("1.0")]
    [HttpGet]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MovimientoMedicamentoDto>>> GetAll(){
        var datos = await _unitOfWork.MovimientoMedicamentos.GetAll();
        var mapeo = _mapper.Map<List<MovimientoMedicamentoDto>>(datos);
        return mapeo;
    }
    [Authorize(Roles = "Administrador")]
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PropietarioDto>> Post(PropietarioDto dato)
    {
        var med = _mapper.Map<Propietario>(dato);
        if (med == null)
        {
            return BadRequest();
        }
        _unitOfWork.Propietarios.Add(med);
        await _unitOfWork.SaveAsync();
        return dato;
    }
    [Authorize(Roles = "Administrador")]
    [HttpDelete("delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var dato = await _unitOfWork.Propietarios.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Propietarios.Remove(dato);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    [Authorize(Roles = "Administrador, Empleado")]
    [HttpGet("Obtener/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PropietarioDto>> GetById(int id)
    {
        var dato = await _unitOfWork.Propietarios.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        return _mapper.Map<PropietarioDto>(dato);
    }
    [Authorize(Roles = "Administrador")]
    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PropietarioDto>> Update(PropietarioDto medicamento)
    {
        var dato = await _unitOfWork.Propietarios.GetById(medicamento.Id);
        if (dato == null)
        {
            return BadRequest();
        }
        var datMap = _mapper.Map<Propietario>(medicamento);
        _unitOfWork.Propietarios.Update(datMap);
        await _unitOfWork.SaveAsync();
        return medicamento;
    }
    [Authorize(Roles = "Administrador, Empleado")]
    [HttpGet("GetWithPets")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PropWithPetDto>>> GetWithMascota()
    {
        var datos = await _unitOfWork.Propietarios.ObtenerConMascota();
        var mapeo = _mapper.Map<List<PropWithPetDto>>(datos);
        return mapeo;
    }

}
