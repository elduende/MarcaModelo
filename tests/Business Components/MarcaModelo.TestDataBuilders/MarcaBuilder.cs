using System;
using MarcaModelo.Data;

namespace MarcaModelo.TestDataBuilders
{
    public class MarcaBuilder
    {
        private Marca marca;

        private MarcaBuilder(Marca marca)
        {
            this.marca = marca;
        }

        public static Marca DefaultPersistent()
        {
            return StartRec().
                WithId(1).
                With(m => m.Descripcion = "Marca").
                With(m => m.Estado = "A").
                Build();
        }

        public static Marca Default()
        {
            return StartRec().
                With(m => m.Descripcion = "Marca").
                With(m => m.Estado = "A").
                Build();
        }

        public static MarcaBuilder StartRec()
        {
            var def = new Marca();
            return new MarcaBuilder(def);
        }

        public MarcaBuilder WithId(int id)
        {
            marca.SetId(id);
            return this;
        }

        public MarcaBuilder With(Action<Marca> action)
        {
            action(marca);
            return this;
        }

        public Marca Build()
        {
            return marca;
        }
    }
}
