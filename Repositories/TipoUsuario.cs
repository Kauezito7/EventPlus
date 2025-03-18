using Event_plus.Interfaces;
using Event_plus.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Event_plus.Context;

namespace Event_plus.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly Evento_Context _context;

        public TipoUsuarioRepository(Evento_Context context)
        {
            _context = context;
        }

        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            try
            {
                _context.TipoUsuario.Add(novoTipoUsuario);
                _context.SaveChanges();
            }
            catch (Exception )
            {
                throw;
            }          
        }

        public TipoUsuario BuscarTipoUsuarioPorId(Guid id)
        {
            try
            {
                return _context.TipoUsuario.Find(id);
            }
            catch (Exception)
            {
                
                return null;
            }
        }

        public void Atualizar(Guid id, TipoUsuario tipoUsuarioAtualizado)
        {
            try
            {
                var tipoUsuarioExistente = _context.TipoUsuario.Find(id);
                if (tipoUsuarioExistente != null)
                {
                    _context.Entry(tipoUsuarioExistente).CurrentValues.SetValues(tipoUsuarioAtualizado);
                    _context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("TipoUsuario não encontrado para atualização com ID: {id}");
                    throw new Exception("TipoUsuario não encontrado para atualização com ID: {id}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                var tipoUsuario = _context.TipoUsuario.Find(id);
                if (tipoUsuario != null)
                {
                    _context.TipoUsuario.Remove(tipoUsuario);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("TipoUsuario não encontrado para exclusão com ID: {id}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro inesperado ao deletar TipoUsuario com ID: {id}: {e.Message}");
                throw new Exception("Erro inesperado ao deletar TipoUsuario.");
            }
        }

        public List<TipoUsuario> Listar()
        {
            try
            {
                return _context.TipoUsuario.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}