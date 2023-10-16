using Microsoft.AspNetCore.Mvc;
using API.Dtos;
using API.Helpers;
using Domain.Interface;
using Domain.Entities;
using AutoMapper;

namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class TratamientoMedicoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public TratamientoMedicoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [MapToApiVersion("1.0")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<PropietarioDto>>> Paginacion([FromQuery] Params productParams)
    {
        var products = await _unitOfWork.Propietarios.paginacion(productParams.PageIndex, productParams.PageSize, productParams.Search);
        var mapeo = _mapper.Map<List<PropietarioDto>>(products.registros);
        return new Pager<PropietarioDto>(mapeo, products.totalRegistros, productParams.PageIndex, productParams.PageSize, productParams.Search);
    }
    [MapToApiVersion("1.1")]
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
    [MapToApiVersion("1.1")]
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
    [MapToApiVersion("1.1")]
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
    [MapToApiVersion("1.1")]
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
}
