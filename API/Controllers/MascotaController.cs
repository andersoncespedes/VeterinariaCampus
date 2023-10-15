using Microsoft.AspNetCore.Mvc;
using API.Dtos;
using API.Helpers;
using Domain.Interface;
using Domain.Entities;
using AutoMapper;


namespace API.Controllers;
public class MascotaController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public MascotaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<MascotaDto>>> Paginacion([FromQuery] Params productParams)
    {
        var products = await _unitOfWork.Mascotas.paginacion(productParams.PageIndex, productParams.PageSize, productParams.Search);
        var mapeo = _mapper.Map<List<MascotaDto>>(products.registros);
        return new Pager<MascotaDto>(mapeo, products.totalRegistros, productParams.PageIndex, productParams.PageSize, productParams.Search);
    }
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PostMascotaDto>> Post(PostMascotaDto dato)
    {
        var med = _mapper.Map<Mascota>(dato);
        if (med == null)
        {
            return BadRequest();
        }
        _unitOfWork.Mascotas.Add(med);
        await _unitOfWork.SaveAsync();
        return dato;
    }
    [HttpDelete("delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var dato = await _unitOfWork.Mascotas.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Mascotas.Remove(dato);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    [HttpGet("Obtener/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MascotaDto>> GetById(int id)
    {
        var dato = await _unitOfWork.Mascotas.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        return _mapper.Map<MascotaDto>(dato);
    }
    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MascotaDto>> Update(MascotaDto mascota)
    {
        var dato = await _unitOfWork.Mascotas.GetById(mascota.Id);
        if (dato == null)
        {
            return BadRequest();
        }
        var datMap = _mapper.Map<Mascota>(mascota);
        _unitOfWork.Mascotas.Update(datMap);
        await _unitOfWork.SaveAsync();
        return mascota;
    }
}
