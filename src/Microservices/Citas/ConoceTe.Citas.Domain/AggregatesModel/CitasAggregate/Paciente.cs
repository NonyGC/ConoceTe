using ConoceTe.Citas.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConoceTe.Citas.Domain.AggregatesModel.CitasAggregate
{
    public class Paciente : Entity, IAggregateRoot
    {
        public string Apellidos { get; private set; }
        public string Nombres { get; private set; }
        public string Direccion { get; private set; }
        public DateTime FechaNacimiento { get; private set; }
        public int Estado { get;private set; }

        enum Estados
        {
            Inactivo = 0,
            Activo = 1,
            Elimado = 2
        }

        public Paciente(int pacienteId, string apellidos, string nombres, string direccion, DateTime fechaNacimiento)
        {
            Id = pacienteId;
            Apellidos = apellidos ?? throw new ArgumentNullException(nameof(apellidos));
            Nombres = nombres ?? throw new ArgumentNullException(nameof(nombres));
            Direccion = direccion ?? throw new ArgumentNullException(nameof(direccion));
            FechaNacimiento = fechaNacimiento;
        }     
        
        public Paciente(string apellidos, string nombres, string direccion, DateTime fechaNacimiento)
        {
            Apellidos = apellidos ?? throw new ArgumentNullException(nameof(apellidos));
            Nombres = nombres ?? throw new ArgumentNullException(nameof(nombres));
            Direccion = direccion ?? throw new ArgumentNullException(nameof(direccion));
            FechaNacimiento = fechaNacimiento;
        }

        public void EstadoActivo()
        {
            Estado = (int)Estados.Activo;
        }
    }
}
