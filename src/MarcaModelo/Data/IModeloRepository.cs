using System;
using System.Collections.Generic;

namespace MarcaModelo.Data
{
    public interface IModeloRepository
    {
        int IdMarca { get; set; }
        //Marca Marca { get; set; }
        int IdModelo { get; set; }
        string Descripcion { get; set; }
        string Estado { get; set; }
        IEnumerable<Object> Componentes();
        Modelo GetById(int idModelo);
        IEnumerable<Modelo> GetModelos();
        IEnumerable<Modelo> GetModelos(int pPagina, int pTamanoPagina, string pBuscar);
        IEnumerable<Modelo> GetModelosInactivos();
        IEnumerable<Modelo> GetModelosInactivos(int pPagina, int pTamanoPagina, string pBuscar);
        int GetModelosCantidad(int pIdMarca);
        int GetModelosInactivosCantidad(int pIdMarca);
        //void Persist(Modelo pModelo);
        void AddComponente(object pComponente);
        void RemoveComponente(object pComponente);
        void Activate(int pIdModelo);
        void Inactivate(int pIdModelo);
    }
}
