using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transparencia.BLL
{
    class EstadisticasBLL
    {
        DBDidecoEntities context;

        public List<Solicitudes> ObtenerTransparenciaMotivo(int motivo, int anno)
        {
            context = new DBDidecoEntities();
            List<Solicitudes> listado = new List<Solicitudes>();
            if (motivo == 0) listado = (from l in context.Solicitudes where l.Vivienda == true && l.FechaAprobacionDirector.Value.Year == anno && l.AprobacionDirector == "APROBADO" orderby l.FechaAprobacionDirector descending select l).ToList();
            if (motivo == 1) listado = (from l in context.Solicitudes where l.Alimentacion == true && l.FechaAprobacionDirector.Value.Year == anno && l.AprobacionDirector == "APROBADO" orderby l.FechaAprobacionDirector descending select l).ToList();
            if (motivo == 2) listado = (from l in context.Solicitudes where l.Salud == true && l.FechaAprobacionDirector.Value.Year == anno && l.AprobacionDirector == "APROBADO" orderby l.FechaAprobacionDirector descending select l).ToList();
            if (motivo == 3) listado = (from l in context.Solicitudes where l.Infancia == true && l.FechaAprobacionDirector.Value.Year == anno && l.AprobacionDirector == "APROBADO" orderby l.FechaAprobacionDirector descending select l).ToList();
            if (motivo == 4) listado = (from l in context.Solicitudes where l.Defunciones == true && l.FechaAprobacionDirector.Value.Year == anno && l.AprobacionDirector == "APROBADO" orderby l.FechaAprobacionDirector descending select l).ToList();
            if (motivo == 5) listado = (from l in context.Solicitudes where l.Microemprendimiento == true && l.FechaAprobacionDirector.Value.Year == anno && l.AprobacionDirector == "APROBADO" orderby l.FechaAprobacionDirector descending select l).ToList();
            if (motivo == 6) listado = (from l in context.Solicitudes where l.PSGubernamental == true && l.FechaAprobacionDirector.Value.Year == anno && l.AprobacionDirector == "APROBADO" orderby l.FechaAprobacionDirector descending select l).ToList();
            if (motivo == 7) listado = (from l in context.Solicitudes where l.Maquinaria == true && l.FechaAprobacionDirector.Value.Year == anno && l.AprobacionDirector == "APROBADO" orderby l.FechaAprobacionDirector descending select l).ToList();
            if (motivo == 8) listado = (from l in context.Solicitudes where l.PersonalMunicipal == true && l.FechaAprobacionDirector.Value.Year == anno && l.AprobacionDirector == "APROBADO" orderby l.FechaAprobacionDirector descending select l).ToList();
            if (motivo == 9) listado = (from l in context.Solicitudes where l.RebajaAseo == true && l.FechaAprobacionDirector.Value.Year == anno && l.AprobacionDirector == "APROBADO" orderby l.FechaAprobacionDirector descending select l).ToList();
            if (motivo == 10) listado = (from l in context.Solicitudes where l.EntregaAgua == true && l.FechaAprobacionDirector.Value.Year == anno && l.AprobacionDirector == "APROBADO" orderby l.FechaAprobacionDirector descending select l).ToList();
            if (motivo == 11) listado = (from l in context.Solicitudes where l.Otros == true && l.FechaAprobacionDirector.Value.Year == anno && l.AprobacionDirector == "APROBADO" orderby l.FechaAprobacionDirector descending select l).ToList();
            return listado;
        }

        public List<Solicitudes> ObtenerTransparenciaTodas(int anno) {
            context = new DBDidecoEntities();
            return (from l in context.Solicitudes where l.FechaAprobacionDirector.Value.Year == anno && l.AprobacionDirector == "APROBADO" orderby l.FechaAprobacionDirector descending select l).ToList();
        }

    }
}
