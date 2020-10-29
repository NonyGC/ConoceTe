using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ConoceTe.Citas.API.Application.Commands
{
    [DataContract]
    public class PsicologoCommand : IRequest<bool>
    {

        [DataMember]
        public string Apellidos { get; protected set; }

        [DataMember]
        public string Nombres { get; protected set; }

        [DataMember]
        public string Direccion { get; protected set; }

        [DataMember]
        public string FechaNacimiento { get; protected set; }

        [DataMember]
        public string CuentaDeposito { get; protected set; }
        
        [DataMember]
        public string GradoTitulacion { get; protected set; }

        [DataMember]
        public string Especialidad { get; protected set; }

        [DataMember]
        public int Estado { get; protected set; }

    }

    //public class DocumentosPsicologoDTO
    //{
    //    public int PsicologoId { get; set; }
    //    public string UrlDocumento { get; set; }
    //    public int Estado { get; set; }
    //}


    public class CrearPsicologoCommand : PsicologoCommand
    {
        public CrearPsicologoCommand(string apellidos, string nombres, string direccion, string fechaNacimiento, string cuentaDeposito, string gradoTitulacion, string especialidad, int estado)
        {
            Apellidos = apellidos ?? throw new ArgumentNullException(nameof(apellidos));
            Nombres = nombres ?? throw new ArgumentNullException(nameof(nombres));
            Direccion = direccion ?? throw new ArgumentNullException(nameof(direccion));
            FechaNacimiento = fechaNacimiento ?? throw new ArgumentNullException(nameof(fechaNacimiento));
            CuentaDeposito = cuentaDeposito ?? throw new ArgumentNullException(nameof(cuentaDeposito));
            GradoTitulacion = gradoTitulacion ?? throw new ArgumentNullException(nameof(gradoTitulacion));
            Especialidad = especialidad ?? throw new ArgumentNullException(nameof(especialidad));
            Estado = estado;
        }

    }


    public class ActualizarPsicologoCommand : PsicologoCommand
    {
        [DataMember]
        public int PsicologoId { get; private set; }

        public ActualizarPsicologoCommand(int psicologoId, string apellidos, string nombres, string direccion, string fechaNacimiento, string cuentaDeposito, string gradoTitulacion, string especialidad, int estado)
        {
            PsicologoId = psicologoId;
            Apellidos = apellidos ?? throw new ArgumentNullException(nameof(apellidos));
            Nombres = nombres ?? throw new ArgumentNullException(nameof(nombres));
            Direccion = direccion ?? throw new ArgumentNullException(nameof(direccion));
            FechaNacimiento = fechaNacimiento ?? throw new ArgumentNullException(nameof(fechaNacimiento));
            CuentaDeposito = cuentaDeposito ?? throw new ArgumentNullException(nameof(cuentaDeposito));
            GradoTitulacion = gradoTitulacion ?? throw new ArgumentNullException(nameof(gradoTitulacion));
            Especialidad = especialidad ?? throw new ArgumentNullException(nameof(especialidad));
            Estado = estado;
        }
    }

    [DataContract]
    public class EliminarPsicologoCommand : IRequest<bool>
    {
        [DataMember]
        public int PsicologoId { get; private set; }

        public EliminarPsicologoCommand(int psicologoId)
        {
            PsicologoId = psicologoId;
        }
    }
}
