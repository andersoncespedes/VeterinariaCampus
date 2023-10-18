using Microsoft.AspNetCore.Mvc;
using API.Dtos;
using API.Helpers;
using Domain.Interface;
using Domain.Entities;
using AutoMapper;
using Application.Repository;
using Microsoft.AspNetCore.Authorization;
namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class RazaController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public RazaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [MapToApiVersion("1.1")]
    [Authorize(Roles = "Administrador, Empleado")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<RazaDto>>> Paginacion([FromQuery] Params productParams)
    {
        var products = await _unitOfWork.Razas.paginacion(productParams.PageIndex, productParams.PageSize, productParams.Search);
        var mapeo = _mapper.Map<List<RazaDto>>(products.registros);
        return new Pager<RazaDto>(mapeo, products.totalRegistros, productParams.PageIndex, productParams.PageSize, productParams.Search);
    }
    [MapToApiVersion("1.0")]
    [HttpGet]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<RazaDto>>> GetAll(){
        var datos = await _unitOfWork.Razas.GetAll();
        var mapeo = _mapper.Map<List<RazaDto>>(datos);
        return mapeo;
    }
    [Authorize(Roles = "Administrador")]
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RazaDto>> Post(RazaDto dato)
    {
        var med = _mapper.Map<Raza>(dato);
        if (med == null)
        {
            return BadRequest();
        }
        _unitOfWork.Razas.Add(med);
        await _unitOfWork.SaveAsync();
        return dato;
    }
    [Authorize(Roles = "Administrador")]
    [HttpDelete("delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var dato = await _unitOfWork.Razas.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Razas.Remove(dato);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    [Authorize(Roles = "Administrador, Empleado")]
    [HttpGet("Obtener/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RazaDto>> GetById(int id)
    {
        var dato = await _unitOfWork.Razas.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        return _mapper.Map<RazaDto>(dato);
    }
    [Authorize(Roles = "Administrador")]
    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RazaDto>> Update(RazaDto medicamento)
    {
        var dato = await _unitOfWork.Razas.GetById(medicamento.Id);
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
    [HttpGet("GetWithCount")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<RazaWithCount>>> GetRazaWithCount([FromQuery] Params productParams){
        var products = await _unitOfWork.Razas.paginacion(productParams.PageIndex, productParams.PageSize, productParams.Search);
        var mapeo = _mapper.Map<List<RazaWithCount>>(products.registros);
        return new Pager<RazaWithCount>(mapeo, products.totalRegistros, productParams.PageIndex, productParams.PageSize, productParams.Search);
    }
}
