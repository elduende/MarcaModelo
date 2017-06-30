using System;
using MarcaModelo.Data;
namespace MarcaModelo.TestDataBuilders
{
    public class ModeloBuilder
    {
        private Modelo _modelo;

        private ModeloBuilder(Modelo modelo)
        {
            this._modelo = modelo;
        }

        public static Modelo DefaultPersistent(Marca pMarca)
        {
            return StartRec().
                WithId(1).
                With(m => m.IdModelo = 1).
                With(m => m.Descripcion = "Descripcion 1").
                With(m => m.Estado = "A").
                With(m => m.IdMarca = pMarca.IdMarca).
                Build();
        }

        public static Modelo Default(Marca pMarca)
        {
            return StartRec().
                With(m => m.Descripcion = "Descripcion 1").
                With(m => m.Estado = "A").
                With(m => m.IdMarca = pMarca.IdMarca).
                Build();
        }

        public static ModeloBuilder StartRec()
        {
            var def = new Modelo(MarcaBuilder.Default());
            return new ModeloBuilder(def);
        }

        public ModeloBuilder WithId(int id)
        {
            _modelo.SetId(id);
            return this;
        }

        public ModeloBuilder With(Action<Modelo> action)
        {
            action(_modelo);
            return this;
        }

        public Modelo Build()
        {
            return _modelo;
        }
    }
}
