namespace Domain.Entities;
public class TratamientoMedico : BaseEntity
{
    public int IdCitaFk {get; set;}
    public Citas Citas {get; set;}
    public int IdMedicamentoFk {get; set;}
    public Medicamento Medicamento {get; set;}
    public int Dosis {get; set;}
    public DateOnly FechaAdministracion {get;set;}
    public string Observacion {get; set;}
}
