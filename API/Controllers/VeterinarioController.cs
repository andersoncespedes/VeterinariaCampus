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
public class VeterinarioController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public VeterinarioController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [Authorize(Roles = "Administrador, Empleado")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<VeterinarioDto>>> Paginacion([FromQuery] Params productParams)
    {
        var labs = await _unitOfWork.Veterinarios.paginacion(productParams.PageIndex, productParams.PageSize, productParams.Search);
        var mapeo = _mapper.Map<List<VeterinarioDto>>(labs.registros);
        return new Pager<VeterinarioDto>(mapeo, labs.totalRegistros, productParams.PageIndex, productParams.PageSize, productParams.Search);
    }
    [MapToApiVersion("1.0")]
    [HttpGet]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<VeterinarioDto>>> GetAll(){
        var datos = await _unitOfWork.Veterinarios.GetAll();
        var mapeo = _mapper.Map<List<VeterinarioDto>>(datos);
        return mapeo;
    }
    [Authorize(Roles = "Administrador")]
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<VeterinarioDto>> Post(VeterinarioDto dato)
    {
        var lab = _mapper.Map<Veterinario>(dato);
        if (lab == null)
        {
            return BadRequest();
        }
        _unitOfWork.Veterinarios.Add(lab);
        await _unitOfWork.SaveAsync();
        return dato;
    }
    [Authorize(Roles = "Administrador")]
    [HttpDelete("delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var dato = await _unitOfWork.Veterinarios.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Veterinarios.Remove(dato);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    [Authorize(Roles = "Administrador, Empleado")]
    [HttpGet("Obtener/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<VeterinarioDto>> GetById(int id)
    {
        var dato = await _unitOfWork.Veterinarios.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        return _mapper.Map<VeterinarioDto>(dato);
    }
    [Authorize(Roles = "Administrador")]
    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<VeterinarioDto>> Update(VeterinarioDto lab)
    {
        var dato = await _unitOfWork.Veterinarios.GetById(lab.Id);
        if (dato == null)
        {
            return BadRequest();
        }
        var datMap = _mapper.Map<Veterinario>(lab);
        _unitOfWork.Veterinarios.Update(datMap);
        await _unitOfWork.SaveAsync();
        return lab;
    }
    [Authorize(Roles = "Administrador, Empleado")]
    [HttpGet("GetCirujanos")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<IEnumerable<VeterinarioDto>> GetCirujano()
    {
        var datos = _unitOfWork.Veterinarios.Find(e => e.Especialidad.ToLower() == "cirujano vascular");
        var mapeo = _mapper.Map<List<VeterinarioDto>>(datos);
        return mapeo;
    }
}
