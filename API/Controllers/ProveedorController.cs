using Microsoft.AspNetCore.Mvc;
using API.Dtos;
using API.Helpers;
using Domain.Interface;
using Domain.Entities;
using AutoMapper;

namespace API.Controllers;
public class ProveedorController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public ProveedorController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<ProveedorDto>>> Paginacion([FromQuery] Params productParams)
    {
        var products = await _unitOfWork.Proveedores.paginacion(productParams.PageIndex, productParams.PageSize, productParams.Search);
        var mapeo = _mapper.Map<List<ProveedorDto>>(products.registros);
        return new Pager<ProveedorDto>(mapeo, products.totalRegistros, productParams.PageIndex, productParams.PageSize, productParams.Search);
    }
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

}
