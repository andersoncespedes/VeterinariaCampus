using Microsoft.AspNetCore.Mvc;
using API.Dtos;
using API.Helpers;
using Domain.Interface;
using Domain.Entities;
using AutoMapper;
using Application.Repository;
namespace API.Controllers;
public class RazaController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public RazaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<RazaDto>>> Paginacion([FromQuery] Params productParams)
    {
        var products = await _unitOfWork.Razas.paginacion(productParams.PageIndex, productParams.PageSize, productParams.Search);
        var mapeo = _mapper.Map<List<RazaDto>>(products.registros);
        return new Pager<RazaDto>(mapeo, products.totalRegistros, productParams.PageIndex, productParams.PageSize, productParams.Search);
    }
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
}
