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
public class DetalleMovimientoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public DetalleMovimientoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [MapToApiVersion("1.1")]
    [Authorize(Roles = "Administrador, Empleado")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<DetalleMovimientoDto>>> Paginacion([FromQuery] Params productParams)
    {
        var labs = await _unitOfWork.DetalleMovimientos.paginacion(productParams.PageIndex, productParams.PageSize, productParams.Search);
        var mapeo = _mapper.Map<List<DetalleMovimientoDto>>(labs.registros);
        return new Pager<DetalleMovimientoDto>(mapeo, labs.totalRegistros, productParams.PageIndex, productParams.PageSize, productParams.Search);
    }
     [MapToApiVersion("1.0")]
    [HttpGet]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DetalleMovimientoDto>>> GetAll(){
        var datos = await _unitOfWork.DetalleMovimientos.GetAll();
        var mapeo = _mapper.Map<List<DetalleMovimientoDto>>(datos);
        return mapeo;
    }
    [Authorize(Roles = "Administrador")]
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PostDetalleMovimientoDto>> Post(PostDetalleMovimientoDto dato)
    {
        var lab = _mapper.Map<DetalleMovimiento>(dato);
        if (lab == null)
        {
            return BadRequest();
        }
        _unitOfWork.DetalleMovimientos.Add(lab);
        await _unitOfWork.SaveAsync();
        return dato;
    }
    [Authorize(Roles = "Administrador")]
    [HttpDelete("delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var dato = await _unitOfWork.DetalleMovimientos.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.DetalleMovimientos.Remove(dato);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    [Authorize(Roles = "Administrador, Empleado")]
    [HttpGet("Obtener/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DetalleMovimientoDto>> GetById(int id)
    {
        var dato = await _unitOfWork.DetalleMovimientos.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        return _mapper.Map<DetalleMovimientoDto>(dato);
    }
    [Authorize(Roles = "Administrador")]
    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PostDetalleMovimientoDto>> Update(PostDetalleMovimientoDto lab)
    {
        var dato = await _unitOfWork.DetalleMovimientos.GetById(lab.Id);
        if (dato == null)
        {
            return BadRequest();
        }
        var datMap = _mapper.Map<DetalleMovimiento>(lab);
        _unitOfWork.DetalleMovimientos.Update(datMap);
        await _unitOfWork.SaveAsync();
        return lab;
    }
}
