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
public class EspecieController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public EspecieController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [MapToApiVersion("1.1")]
    [Authorize(Roles = "Administrador, Empleado")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<EspecieDto>>> Paginacion([FromQuery] Params productParams)
    {
        var labs = await _unitOfWork.Especies.paginacion(productParams.PageIndex, productParams.PageSize, productParams.Search);
        var mapeo = _mapper.Map<List<EspecieDto>>(labs.registros);
        return new Pager<EspecieDto>(mapeo, labs.totalRegistros, productParams.PageIndex, productParams.PageSize, productParams.Search);
    }
    [MapToApiVersion("1.0")]
    [HttpGet]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<EspecieDto>>> GetAll(){
        var datos = await _unitOfWork.Especies.GetAll();
        var mapeo = _mapper.Map<List<EspecieDto>>(datos);
        return mapeo;
    }
    [Authorize(Roles = "Administrador")]
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EspecieDto>> Post(EspecieDto dato)
    {
        var lab = _mapper.Map<Especie>(dato);
        if (lab == null)
        {
            return BadRequest();
        }
        _unitOfWork.Especies.Add(lab);
        await _unitOfWork.SaveAsync();
        return dato;
    }
    [Authorize(Roles = "Administrador")]
    [HttpDelete("delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var dato = await _unitOfWork.Especies.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Especies.Remove(dato);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    [Authorize(Roles = "Administrador, Empleado")]
    [HttpGet("Obtener/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EspecieDto>> GetById(int id)
    {
        var dato = await _unitOfWork.Especies.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        return _mapper.Map<EspecieDto>(dato);
    }
    [Authorize(Roles = "Administrador")]
    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EspecieDto>> Update(EspecieDto lab)
    {
        var dato = await _unitOfWork.Especies.GetById(lab.Id);
        if (dato == null)
        {
            return BadRequest();
        }
        var datMap = _mapper.Map<Especie>(lab);
        _unitOfWork.Especies.Update(datMap);
        await _unitOfWork.SaveAsync();
        return lab;
    }
    [Authorize(Roles = "Administrador, Empleado")]
    [HttpGet("WithPets")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<EspecieWithPetDto>>> GetWithPet([FromQuery] Params productParams)
    {
        var labs = await _unitOfWork.Especies.paginacion(productParams.PageIndex, productParams.PageSize, productParams.Search);
        var mapeo = _mapper.Map<List<EspecieWithPetDto>>(labs.registros);
        return new Pager<EspecieWithPetDto>(mapeo, labs.totalRegistros, productParams.PageIndex, productParams.PageSize, productParams.Search);
    }
}
