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
public class MovimientoMedicamentoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public MovimientoMedicamentoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [MapToApiVersion("1.1")]
    [Authorize(Roles = "Administrador, Empleado")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<MovimientoMedicamentoDto>>> Paginacion([FromQuery] Params productParams)
    {
        var labs = await _unitOfWork.MovimientoMedicamentos.paginacion(productParams.PageIndex, productParams.PageSize, productParams.Search);
        var mapeo = _mapper.Map<List<MovimientoMedicamentoDto>>(labs.registros);
        return new Pager<MovimientoMedicamentoDto>(mapeo, labs.totalRegistros, productParams.PageIndex, productParams.PageSize, productParams.Search);
    }
    [MapToApiVersion("1.0")]
    [HttpGet]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MovimientoMedicamentoDto>>> GetAll(){
        var datos = await _unitOfWork.MovimientoMedicamentos.GetAll();
        var mapeo = _mapper.Map<List<MovimientoMedicamentoDto>>(datos);
        return mapeo;
    }
    [Authorize(Roles = "Admininstrador")]
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PostMovimientoMedicamentoDto>> Post(PostMovimientoMedicamentoDto dato)
    {
        var lab = _mapper.Map<MovimientoMedicamento>(dato);
        if (lab == null)
        {
            return BadRequest();
        }
        _unitOfWork.MovimientoMedicamentos.Add(lab);
        await _unitOfWork.SaveAsync();
        return dato;
    }
    [Authorize(Roles = "Administrador")]
    [HttpDelete("delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var dato = await _unitOfWork.MovimientoMedicamentos.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.MovimientoMedicamentos.Remove(dato);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    [Authorize(Roles = "Administrador, Empleado")]
    [HttpGet("Obtener/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MovimientoMedicamentoDto>> GetById(int id)
    {
        var dato = await _unitOfWork.MovimientoMedicamentos.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        return _mapper.Map<MovimientoMedicamentoDto>(dato);
    }
    [Authorize(Roles = "Administrador")]
    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MovimientoMedicamentoDto>> Update(MovimientoMedicamentoDto lab)
    {
        var dato = await _unitOfWork.MovimientoMedicamentos.GetById(lab.Id);
        if (dato == null)
        {
            return BadRequest();
        }
        var datMap = _mapper.Map<MovimientoMedicamento>(lab);
        _unitOfWork.MovimientoMedicamentos.Update(datMap);
        await _unitOfWork.SaveAsync();
        return lab;
    }
    [Authorize(Roles = "Administrador, Empleado")]
    [HttpGet("GetWithPrice")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<MovMedPriceDto>>> GetWithPrice([FromQuery] Params productParams)
    {
        var labs = await _unitOfWork.MovimientoMedicamentos.paginacion(productParams.PageIndex, productParams.PageSize, productParams.Search);
        var mapeo = _mapper.Map<List<MovMedPriceDto>>(labs.registros);
        return new Pager<MovMedPriceDto>(mapeo, labs.totalRegistros, productParams.PageIndex, productParams.PageSize, productParams.Search);
    }
}