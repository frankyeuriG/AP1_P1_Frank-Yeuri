using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using AP1_P1_FrankYeuri.DAL;
using AP1_P1_FrankYeuri.Models;

namespace AP1_P1_FrankYeuri.BLL
{
    public class AportesBLL{
        private Contexto _contexto;

        public AportesBLL(Contexto contexto){
            _contexto = contexto;
        }
        public bool Existe(int aportesId){
            return _contexto.Aportes.Any( o => o.AportesId == aportesId);
        }
        private bool Insertar(Aportes aportes){
            _contexto.Aportes.Add(aportes);
            return _contexto.SaveChanges()>0;
        }
    private bool Modificar(Aportes aportes){
        _contexto.Entry(aportes).State =  EntityState.Modified;
        return _contexto.SaveChanges()>0;

    }
    public bool Guardar(Aportes aportes){
        if(!Existe(aportes.AportesId))
            return this.Insertar(aportes);
        else
         return this.Modificar(aportes);
    }
    public bool Eliminar(Aportes aportes){
        _contexto.Entry(aportes).State = EntityState.Deleted;
        return _contexto.SaveChanges()>0;
    }
    public Aportes? Buscar(int aportesId){
        return _contexto.Aportes
        .Where(o => o.AportesId == aportesId)
        .AsNoTracking()
        .SingleOrDefault(); 
    }
    public List<Aportes> GetList(Expression<Func<Aportes, bool>> Criterio){
            return _contexto.Aportes
                .AsNoTracking()
                .Where(Criterio)
                .ToList();
    }

 }

}