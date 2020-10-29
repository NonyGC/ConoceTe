using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ConoceTe.Citas.API.Application.Commands
{
    [DataContract]
    public class PacienteCommand
        : IRequest<bool>
    {
        [DataMember]
        public int PacienteId { get; protected set; }

        [DataMember]
        public string Apellidos { get; protected set; }

        [DataMember]
        public string Nombres { get; protected set; }

        [DataMember]
        public string Direccion { get; protected set; }

        [DataMember]
        public string FechaNacimiento { get; protected set; }

        [DataMember]
        public int Estado { get; protected set; }
    }

    public class CrearPacienteCommand : PacienteCommand
    {
        public CrearPacienteCommand(string apellidos, string nombres, string direccion, string fechaNacimiento, int estado)
        {
            Apellidos = apellidos ?? throw new ArgumentNullException(nameof(apellidos));
            Nombres = nombres ?? throw new ArgumentNullException(nameof(nombres));
            Direccion = direccion ?? throw new ArgumentNullException(nameof(direccion));
            FechaNacimiento = fechaNacimiento;
            Estado = estado;
        }
    }


    public class ActualizarPacienteCommand : PacienteCommand
    {


        public ActualizarPacienteCommand(int pacienteId, string apellidos, string nombres, string direccion, string fechaNacimiento, int estado)
        {
            PacienteId = pacienteId;
            Apellidos = apellidos ?? throw new ArgumentNullException(nameof(apellidos));
            Nombres = nombres ?? throw new ArgumentNullException(nameof(nombres));
            Direccion = direccion ?? throw new ArgumentNullException(nameof(direccion));
            FechaNacimiento = fechaNacimiento;
            Estado = estado;
        }
    }

    [DataContract]
    public class EliminarPacienteCommand : IRequest<bool>
    {
        [DataMember]
        public int PacienteId { get; private set; }

        public EliminarPacienteCommand(int pacienteId)
        {
            PacienteId = pacienteId;
        }
    }
}