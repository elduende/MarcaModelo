using System;
using MarcaModelo.Data;
namespace MarcaModelo.TestDataBuilders
{
    public class ModeloBuilder
    {
        private Modelo modelo;

        private ModeloBuilder(Modelo modelo)
        {
            this.modelo = modelo;
        }

        public static Modelo DefaultPersistent()
        {
            return StartRec().
                WithId(1).
                With(m => m.Descripcion = "Modelo").
                With(m => m.Estado = "A").
                With(m => m.Marca = MarcaBuilder.Default()).
                Build();
        }

        public static Modelo Default()
        {
            return StartRec().
                With(m => m.Descripcion = "Modelo").
                With(m => m.Estado = "A").
                With(m => m.Marca = MarcaBuilder.Default()).
                Build();
        }

        public static ModeloBuilder StartRec()
        {
            var def = new Modelo();
            return new ModeloBuilder(def);
        }

        public ModeloBuilder WithId(int id)
        {
            modelo.SetId(id);
            return this;
        }

        public ModeloBuilder With(Action<Modelo> action)
        {
            action(modelo);
            return this;
        }

        public Modelo Build()
        {
            return modelo;
        }
    }
}
