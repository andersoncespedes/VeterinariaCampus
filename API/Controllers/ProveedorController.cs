using Microsoft.AspNetCore.Mvc;
using API.Dtos;
using API.Helpers;
using Domain.Interface;
using Domain.Entities;
using AutoMapper;

namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class ProveedorController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public ProveedorController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [MapToApiVersion("1.0")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<ProveedorDto>>> Paginacion([FromQuery] Params productParams)
    {
        var products = await _unitOfWork.Proveedores.paginacion(productParams.PageIndex, productParams.PageSize, productParams.Search);
        var mapeo = _mapper.Map<List<ProveedorDto>>(products.registros);
        return new Pager<ProveedorDto>(mapeo, products.totalRegistros, productParams.PageIndex, productParams.PageSize, productParams.Search);
    }
    [MapToApiVersion("1.1")]
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProveedorDto>> Post(ProveedorDto dato)
    {
        var med = _mapper.Map<Proveedor>(dato);
        if (med == null)
        {
            return BadRequest();
        }
        _unitOfWork.Proveedores.Add(med);
        await _unitOfWork.SaveAsync();
        return dato;
    }
    [MapToApiVersion("1.1")]
    [HttpDelete("delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var dato = await _unitOfWork.Proveedores.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Proveedores.Remove(dato);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    [MapToApiVersion("1.1")]
    [HttpGet("Obtener/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProveedorDto>> GetById(int id)
    {
        var dato = await _unitOfWork.Proveedores.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        return _mapper.Map<ProveedorDto>(dato);
    }
    [MapToApiVersion("1.1")]
    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProveedorDto>> Update(ProveedorDto mascota)
    {
        var dato = await _unitOfWork.Proveedores.GetById(mascota.Id);
        if (dato == null)
        {
            return BadRequest();
        }
        var datMap = _mapper.Map<Proveedor>(mascota);
        _unitOfWork.Proveedores.Update(datMap);
        await _unitOfWork.SaveAsync();
        return mascota;
    }
    [MapToApiVersion("1.1")]
    [HttpPut("GetPerMed")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProveedorDto>>> GetPerMed([FromQuery] QueryCitaDto param)
    {
        var datos = await _unitOfWork.Proveedores.GetPerMedicamento(param.nombre);
        var mapeo = _mapper.Map<List<ProveedorDto>>(datos);
        return mapeo;
    }

}
