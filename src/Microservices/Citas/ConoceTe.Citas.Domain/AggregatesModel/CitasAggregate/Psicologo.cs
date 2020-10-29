using ConoceTe.Citas.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConoceTe.Citas.Domain.AggregatesModel.CitasAggregate
{
    public class Psicologo : Entity, IAggregateRoot
    {
        public string Apellidos { get; private set; }
        public string Nombres { get; private set; }
        public string Direccion { get; private set; }
        public DateTime FechaNacimiento { get; private set; }
        public string CuentaDeposito { get; private set; }
        public string GradoTitulacion { get; private set; }
        public string Especialidad { get; private set; }
        public int Estado { get; private set; }

        enum Estados
        {
            Inactivo = 0,
            Activo = 1,
            Elimado = 2
        }

        public Psicologo(string apellidos, string nombres, string direccion, DateTime fechaNacimiento, string cuentaDeposito, string gradoTitulacion, string especialidad, int estado)
        {
            Apellidos = apellidos ?? throw new ArgumentNullException(nameof(apellidos));
            Nombres = nombres ?? throw new ArgumentNullException(nameof(nombres));
            Direccion = direccion ?? throw new ArgumentNullException(nameof(direccion));
            FechaNacimiento = fechaNacimiento;
            CuentaDeposito = cuentaDeposito ?? throw new ArgumentNullException(nameof(cuentaDeposito));
            GradoTitulacion = gradoTitulacion ?? throw new ArgumentNullException(nameof(gradoTitulacion));
            Especialidad = especialidad ?? throw new ArgumentNullException(nameof(especialidad));
            Estado = estado;
        }

        public Psicologo(int psicologoId, string apellidos, string nombres, string direccion, DateTime fechaNacimiento, string cuentaDeposito, string gradoTitulacion, string especialidad, int estado)
        {
            Id = psicologoId;
            Apellidos = apellidos ?? throw new ArgumentNullException(nameof(apellidos));
            Nombres = nombres ?? throw new ArgumentNullException(nameof(nombres));
            Direccion = direccion ?? throw new ArgumentNullException(nameof(direccion));
            FechaNacimiento = fechaNacimiento;
            CuentaDeposito = cuentaDeposito ?? throw new ArgumentNullException(nameof(cuentaDeposito));
            GradoTitulacion = gradoTitulacion ?? throw new ArgumentNullException(nameof(gradoTitulacion));
            Especialidad = especialidad ?? throw new ArgumentNullException(nameof(especialidad));
            Estado = estado;
        }

        public void EstadoActivo()
        {
            Estado = (int)Estados.Activo;
        }
    }
}
