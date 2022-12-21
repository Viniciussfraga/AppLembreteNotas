﻿using EsqueciMe.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EsqueciMe.Services {
    public class ServicesDBNotas {

        #region Conexão
        SQLiteConnection conn;
        #endregion

        #region Atributos
        public string StatusMessage { get; set; }
        #endregion

        #region Construtor
        public ServicesDBNotas(string dbPath)
        {
            if (dbPath == "") dbPath = App.DbPath;
            conn = new SQLiteConnection(dbPath); //define o banco
            conn.CreateTable<ModelNotas>(); //cria a tabela notas
        }
        #endregion

        #region Métodos
        public void Inserir(ModelNotas nota)
        {
            try
            {
                if (string.IsNullOrEmpty(nota.Titulo))
                    throw new Exception("Titulo da nota não informado");

                if (string.IsNullOrEmpty(nota.Dados))
                    throw new Exception("Os dados da nota não foram informados");

                int result = conn.Insert(nota);

                _ = (result > 0) ? StatusMessage = string.Format(result + " registro(s) adicionado(s): [Nota: " + nota.Titulo + "]") : StatusMessage = string.Format("0 registro(s) adicionado(s)");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public List<ModelNotas> ListarNotas()
        {
            List<ModelNotas> listaNotas = new List<ModelNotas>();
            try
            {
                listaNotas = conn.Table<ModelNotas>().ToList();
                StatusMessage = "Listagem das notas";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listaNotas;
        }
        public void Alterar(ModelNotas nota)
        {
            try
            {
                if (string.IsNullOrEmpty(nota.Titulo))
                    throw new Exception("Titulo da nota não informado");
                if (string.IsNullOrEmpty(nota.Dados))
                    throw new Exception("Os dados da nota não foram informados");
                if (nota.Id <= 0)
                    throw new Exception("Id da nota não informado");

                int result = conn.Update(nota);
                StatusMessage = string.Format("{0} Registros atualizados.", result);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro: {0}", ex.Message));
            }
        }

        public void Excluir(int id)
        {
            try
            {
                int result = conn.Table<ModelNotas>().Delete(x => x.Id == id);
                StatusMessage = string.Format("{0} Registros deletados.",result);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro: {0}", ex.Message));
            }
        }

        #endregion
    }
}
