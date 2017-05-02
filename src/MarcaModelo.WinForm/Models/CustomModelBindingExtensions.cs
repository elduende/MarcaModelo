using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace MarcaModelo.WinForm.Models
{
    public static class CustomModelBindingExtensions
    {
        public static void Bind<TModel, T>(this ListView control, TModel model, Expression<Func<TModel, IEnumerable<T>>> anomalias) where T : AnomaliaInput
        {
            var startAnomalias = anomalias.Compile().Invoke(model);
            control.Columns.Add("Motivo");
            control.Items.AddRange(startAnomalias.Select(x => MapAnomaliaInputListViewItem(x)).ToArray());
            control.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            var bindingList = startAnomalias as BindingList<AnomaliaInput>;
            if (bindingList == null)
            {
                return;
            }
            bindingList.ListChanged += (sender, args) =>
            {
                switch (args.ListChangedType)
                {
                    case ListChangedType.ItemAdded:
                        var itemAdded = bindingList[args.NewIndex];
                        control.Items.Add(MapAnomaliaInputListViewItem(itemAdded));
                        break;
                    case ListChangedType.Reset:
                    case ListChangedType.ItemDeleted:
                    case ListChangedType.ItemMoved:
                    case ListChangedType.ItemChanged:
                    case ListChangedType.PropertyDescriptorAdded:
                    case ListChangedType.PropertyDescriptorDeleted:
                    case ListChangedType.PropertyDescriptorChanged:
                    default:
                        control.Items.Clear();
                        control.Items.AddRange(bindingList.Select(x => MapAnomaliaInputListViewItem(x)).ToArray());
                        break;
                }
                control.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            };
        }

        private static ListViewItem MapAnomaliaInputListViewItem(AnomaliaInput source)
        {
            var item = new ListViewItem(source.Mensaje);
            switch (source.Nivel)
            {
                case NivelAnomaliaInput.Informacion:
                    item.ImageKey = "Information";
                    break;
                case NivelAnomaliaInput.Atencion:
                    item.ImageKey = "Warning";
                    break;
                case NivelAnomaliaInput.Error:
                    item.ImageKey = "Error";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return item;
        }
    }
}
