using System;
using MarcaModelo.Data;

namespace MarcaModelo.TestDataBuilders
{
    public class MarcaBuilder
    {
        private Marca _marca;

        private MarcaBuilder(Marca marca)
        {
            this._marca = marca;
        }

        public static Marca DefaultPersistent()
        {
            return StartRec().
                WithId(1).
                With(m => m.IdMarca = 1).
                With(m => m.Descripcion = "Descripcion 1").
                With(m => m.Estado = "A").
                Build();
        }

        public static Marca Default()
        {
            return StartRec().
                With(m => m.Descripcion = "Descripcion 1").
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
            _marca.SetId(id);
            return this;
        }

        public MarcaBuilder With(Action<Marca> action)
        {
            action(_marca);
            return this;
        }

        public Marca Build()
        {
            return _marca;
        }
    }
}
