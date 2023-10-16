using Microsoft.AspNetCore.Mvc;
using API.Dtos;
using API.Helpers;
using Domain.Interface;
using Domain.Entities;
using AutoMapper;

namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class MedicamentoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public MedicamentoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [MapToApiVersion("1.0")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<MedicamentoDto>>> Paginacion([FromQuery] Params productParams)
    {
        var products = await _unitOfWork.Medicamentos.paginacion(productParams.PageIndex, productParams.PageSize, productParams.Search);
        var mapeo = _mapper.Map<List<MedicamentoDto>>(products.registros);
        return new Pager<MedicamentoDto>(mapeo, products.totalRegistros, productParams.PageIndex, productParams.PageSize, productParams.Search);
    }
    [MapToApiVersion("1.1")]
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MedicamentoDto>> Post(MedicamentoDto dato)
    {
        var med = _mapper.Map<Medicamento>(dato);
        if (med == null)
        {
            return BadRequest();
        }
        _unitOfWork.Medicamentos.Add(med);
        await _unitOfWork.SaveAsync();
        return dato;
    }
    [MapToApiVersion("1.1")]
    [HttpDelete("delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var dato = await _unitOfWork.Medicamentos.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Medicamentos.Remove(dato);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    [MapToApiVersion("1.1")]
    [HttpGet("Obtener/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MedicamentoDto>> GetById(int id)
    {
        var dato = await _unitOfWork.Medicamentos.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        return _mapper.Map<MedicamentoDto>(dato);
    }
    [MapToApiVersion("1.1")]
    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MedicamentoDto>> Update(MedicamentoDto medicamento)
    {
        var dato = await _unitOfWork.Medicamentos.GetById(medicamento.Id);
        if (dato == null)
        {
            return BadRequest();
        }
        var datMap = _mapper.Map<Medicamento>(medicamento);
        _unitOfWork.Medicamentos.Update(datMap);
        await _unitOfWork.SaveAsync();
        return medicamento;
    }
    [MapToApiVersion("1.0")]
    [HttpGet("genfar")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MedicamentoDto>>> GetGenfar()
    {
        var dato = _unitOfWork.Medicamentos.Find(e => e.Nombre.ToLower() == "genfar");
        var mapeo = _mapper.Map<List<MedicamentoDto>>(dato);
        return mapeo;
    }
    [MapToApiVersion("1.0")]
    [HttpGet("morethan5000")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MedicamentoDto>>> GetMoreThan5mil()
    {
        var dato = _unitOfWork.Medicamentos.Find(e => e.Precio > 5000);
        var mapeo = _mapper.Map<List<MedicamentoDto>>(dato);
        return mapeo;
    }
}
