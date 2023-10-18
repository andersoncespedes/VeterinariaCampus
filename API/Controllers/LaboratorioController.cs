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
public class LaboratorioController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public LaboratorioController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [MapToApiVersion("1.1")]
    [Authorize(Roles = "Administrador, Empleado")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<LaboratorioDto>>> Paginacion([FromQuery] Params productParams)
    {
        var labs = await _unitOfWork.Laboratorios.paginacion(productParams.PageIndex, productParams.PageSize, productParams.Search);
        var mapeo = _mapper.Map<List<LaboratorioDto>>(labs.registros);
        return new Pager<LaboratorioDto>(mapeo, labs.totalRegistros, productParams.PageIndex, productParams.PageSize, productParams.Search);
    }
    [MapToApiVersion("1.0")]
    [HttpGet]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<LaboratorioDto>>> GetAll(){
        var datos = await _unitOfWork.Laboratorios.GetAll();
        var mapeo = _mapper.Map<List<LaboratorioDto>>(datos);
        return mapeo;
    }

    [Authorize(Roles = "Administrador")]
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<LaboratorioDto>> Post(LaboratorioDto dato)
    {
        var lab = _mapper.Map<Laboratorio>(dato);
        if (lab == null)
        {
            return BadRequest();
        }
        _unitOfWork.Laboratorios.Add(lab);
        await _unitOfWork.SaveAsync();
        return dato;
    }
    [Authorize(Roles = "Administrador")]
    [HttpDelete("delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var dato = await _unitOfWork.Laboratorios.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Laboratorios.Remove(dato);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    [Authorize(Roles = "Administrador, Empleado")]
    [HttpGet("Obtener/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<LaboratorioDto>> GetById(int id)
    {
        var dato = await _unitOfWork.Laboratorios.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        return _mapper.Map<LaboratorioDto>(dato);
    }
    [Authorize(Roles = "Administrador")]
    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<LaboratorioDto>> Update(LaboratorioDto lab)
    {
        var dato = await _unitOfWork.Laboratorios.GetById(lab.Id);
        if (dato == null)
        {
            return BadRequest();
        }
        var datMap = _mapper.Map<Laboratorio>(lab);
        _unitOfWork.Laboratorios.Update(datMap);
        await _unitOfWork.SaveAsync();
        return lab;
    }
}
