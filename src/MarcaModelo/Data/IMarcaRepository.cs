﻿using System.Collections.Generic;

namespace MarcaModelo.Data
{
    public interface IMarcaRepository
    {
        int IdMarca { get; set; }
        string Descripcion { get; set; }
        string Estado { get; set; }
        IEnumerable<Modelo> Modelos();
        Marca GetById(int idMarca);
        IEnumerable<Marca> GetMarcas();
        IEnumerable<Marca> GetMarcas(int pPagina, int pTamanoPagina, string pBuscar);
        IEnumerable<Marca> GetMarcasInactivas();
        IEnumerable<Marca> GetMarcasInactivas(int pPagina, int pTamanoPagina, string pBuscar);
        int GetMarcasCantidad(string pBuscar);
        int GetMarcasInactivasCantidad(string pBuscar);
        void Persist(Marca marca);
        void AddModelo(Modelo modelo);
        void RemoveModelo(Modelo modelo);
        void Activate(int idMarca);
        void Inactivate(int iDMarca);
    }
}
