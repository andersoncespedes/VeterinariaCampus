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
public class CitaController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public CitaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CitaDto>>> GetAll(){
        var datos = await _unitOfWork.Citas.GetAll();
        var mapeo = _mapper.Map<List<CitaDto>>(datos);
        return mapeo;
    }
    [MapToApiVersion("1.1")]
    [HttpGet]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<CitaDto>>> Paginacion([FromQuery] Params productParams)
    {
        var labs = await _unitOfWork.Citas.paginacion(productParams.PageIndex, productParams.PageSize, productParams.Search);
        var mapeo = _mapper.Map<List<CitaDto>>(labs.registros);
        return new Pager<CitaDto>(mapeo, labs.totalRegistros, productParams.PageIndex, productParams.PageSize, productParams.Search);
    }
    
    [Authorize(Roles = "Administrador")]
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CitaDto>> Post(CitaDto dato)
    {
        var lab = _mapper.Map<Citas>(dato);
        if (lab == null)
        {
            return BadRequest();
        }
        _unitOfWork.Citas.Add(lab);
        await _unitOfWork.SaveAsync();
        return dato;
    }
    [Authorize(Roles = "Administrador")]
    [HttpDelete("delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var dato = await _unitOfWork.Citas.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Citas.Remove(dato);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    [Authorize(Roles = "Administrador")]
    [HttpGet("Obtener/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CitaDto>> GetById(int id)
    {
        var dato = await _unitOfWork.Citas.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        return _mapper.Map<CitaDto>(dato);
    }
    [Authorize(Roles = "Administrador")]
    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CitaDto>> Update(CitaDto lab)
    {
        var dato = await _unitOfWork.Citas.GetById(lab.Id);
        if (dato == null)
        {
            return BadRequest();
        }
        var datMap = _mapper.Map<Citas>(lab);
        _unitOfWork.Citas.Update(datMap);
        await _unitOfWork.SaveAsync();
        return lab;
    }
    [Authorize(Roles = "Administrador, Empleado")]
    [HttpGet("CitaPrimerTrimestre2023")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<MascotaDto>>> GetPrimerTrimestre2023()
    {
        var dato = await _unitOfWork.Citas.FindCitasTrimestreVacunacion();
        var mapeo = _mapper.Map<List<MascotaDto>>(dato);
        return mapeo;
    }
    [Authorize(Roles = "Administrador, Empleado")]
    [HttpGet("GetPerVeterinario")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<MascotaDto>>> GetPerVeterinario([FromQuery] QueryCitaDto param)
    {
        var dato = await _unitOfWork.Citas.GetPerVeterinario(param.nombre);
        var mapeo = _mapper.Map<List<MascotaDto>>(dato);
        return mapeo;
    }
}
