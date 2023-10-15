using Microsoft.AspNetCore.Mvc;
using API.Dtos;
using API.Helpers;
using Domain.Interface;
using Domain.Entities;
using AutoMapper;

namespace API.Controllers;
public class LaboratorioController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public LaboratorioController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<LaboratorioDto>>> Paginacion([FromQuery] Params productParams)
    {
        var labs = await _unitOfWork.Laboratorios.paginacion(productParams.PageIndex, productParams.PageSize, productParams.Search);
        var mapeo = _mapper.Map<List<LaboratorioDto>>(labs.registros);
        return new Pager<LaboratorioDto>(mapeo, labs.totalRegistros, productParams.PageIndex, productParams.PageSize, productParams.Search);
    }
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
