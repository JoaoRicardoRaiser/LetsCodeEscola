﻿using LestsCodeEscola.Comum;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace AtividadeScrumLetsCode.Repositories
{
    public class GenericRepository<T> where T : EntidadeBase
    {
        protected string Host { get; set; }

        protected List<T> GetDatabase()
        {
            var registros = File.ReadAllText(Host);
            if (registros == "")
            {
                return new List<T>();
            }

            return JsonSerializer.Deserialize<List<T>>(registros);
        }

        protected void UpdateDatabase(List<T> database)
        {
            File.WriteAllTextAsync(Host, JsonSerializer.Serialize(database));
        }

        public List<T> GetAll()
        {
            return GetDatabase().ToList();
        }

        public void Criar(T entidade)
        {
            var database = GetDatabase();
            database.Add(entidade);
            UpdateDatabase(database);
        }

        public void Atualizar(T entidade)
        {
            var database = GetDatabase();
            var entidadeSalva = database.SingleOrDefault(x => x.Id == entidade.Id);
            database.Remove(entidadeSalva);
            database.Add(entidade);
            UpdateDatabase(database);
        }

        public void Deletar(T entidade)
        {
            var database = GetDatabase();
            var entidadeSalva = database.SingleOrDefault(x => x.Id == entidade.Id);
            database.Remove(entidadeSalva);
            UpdateDatabase(database);
        }
    }
}