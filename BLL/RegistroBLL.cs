using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using AP1_P1_FrankYeuri.DAL;
using AP1_P1_FrankYeuri.Models;

namespace AP1_P1_FrankYeuri.BLL
{
    public class RegistroBLL{
        private Contexto _contexto;

        public RegistroBLL(Contexto contexto){
            _contexto = contexto;
        }
        public bool Existe(int registroId){
            return _contexto.Registro.Any( o => o.RegistroId == registroId);
        }
        private bool Insertar(Registro registro){
            _contexto.Registro.Add(registro);
            return _contexto.SaveChanges()>0;
        }
    private bool Modificar(Registro registro){
        _contexto.Entry(registro).State =  EntityState.Modified;
        return _contexto.SaveChanges()>0;

    }
    public bool Guardar(Registro registro){
        if(!Existe(registro.RegistroId))
        return this.Insertar(registro);
        else
        return this.Modificar(registro);
    }
    public bool Eliminar(Registro registro){
        _contexto.Entry(registro).State = EntityState.Deleted;
        return _contexto.SaveChanges()>0;
    }
    public Registro? Buscar(int registroId){
        return _contexto.Registro
        .Where(o => o.RegistroId == registroId)
        .AsNoTracking()
        .SingleOrDefault(); 
    }
    public List<Registro> GetList(Expression<Func<Registro, bool>> Criterio){
            return _contexto.Registro
                .AsNoTracking()
                .Where(Criterio)
                .ToList();
    }

 }

}