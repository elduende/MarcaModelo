using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace MarcaModelo.WinForm.Common
{
    public static class FormConfigurationXmlHelper
    {
        public static void GuardarXml(Form pForm, int pPagina, int pTamanoPagina, Enums.EstadoRegistros pRegistrosGrilla, DataGridView pDataGrid = null)
        {
            var archivo = @"FormSettings\" + pForm.Text + ".xml";

            if (!Directory.Exists("FormSettings"))
            {
                Directory.CreateDirectory("FormSettings");
            }

            if (File.Exists(archivo))
            {
                File.Delete(archivo);
            }

            var doc = new XDocument(new XElement("HDF.NET"));
            doc.Save(archivo);

            var xmlDoc = XDocument.Load(archivo);

            var firstElement = xmlDoc.Element("HDF.NET");

            var nuevoElemento = new XElement("Form", new XAttribute("Name", pForm.Text),
                new XElement("WindowState", pForm.WindowState),
                new XElement("Left", pForm.Left),
                new XElement("Top", pForm.Top),
                new XElement("Width", pForm.Width),
                new XElement("Height", pForm.Height)
            );

            firstElement?.Add(nuevoElemento);

            if (pDataGrid != null)
            {
                var columnas = new XElement("Grilla",
                    new XAttribute("Name", pForm.Text),
                    new XAttribute("Pagina", pPagina),
                    new XAttribute("TamanoPagina", pTamanoPagina),
                    new XAttribute("RegistrosGrilla", pRegistrosGrilla));

                foreach (DataGridViewColumn columna in pDataGrid.Columns)
                {
                    if (columna.Visible)
                    {
                        var orden = columna.HeaderCell.SortGlyphDirection.ToString();
                        
                        var columnaXml = new XElement("Columna", new XAttribute("Name", columna.HeaderText),
                            new XAttribute("Width", Convert.ToInt32(columna.Width)),
                            new XAttribute("Sort", orden));
                        columnas.Add(columnaXml);
                    }
                }
                firstElement?.Add(columnas);
            }

            xmlDoc.Save(archivo);
        }

        public static void LeerXml(Form pForm, ref int pPagina, ref int pTamanoPagina, ref Enums.EstadoRegistros pRegistrosGrilla, DataGridView pDataGrid = null)
        {
            var archivo = @"FormSettings\" + pForm.Text + ".xml";

            if (File.Exists(archivo))
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.Load(archivo);
                var raiz = xmlDoc.GetElementsByTagName("HDF.NET");
                var form = ((XmlElement)raiz[0]).GetElementsByTagName("Form");
                var left = ((XmlElement)form[0]).GetElementsByTagName("Left");
                pForm.Left = Int32.Parse(left[0].InnerText);
                var top = ((XmlElement)form[0]).GetElementsByTagName("Top");
                pForm.Top = Int32.Parse(top[0].InnerText);
                var width = ((XmlElement)form[0]).GetElementsByTagName("Width");
                pForm.Width = Int32.Parse(width[0].InnerText);
                var height = ((XmlElement)form[0]).GetElementsByTagName("Height");
                pForm.Height = Int32.Parse(height[0].InnerText);

                var windowState = ((XmlElement)form[0]).GetElementsByTagName("WindowState");

                switch (windowState[0].Value)
                {
                    case "Maximized":
                        pForm.WindowState = FormWindowState.Maximized;
                        break;
                    case "Minimized":
                        pForm.WindowState = FormWindowState.Minimized;
                        break;
                    default:
                        pForm.WindowState = FormWindowState.Normal;
                        break;
                }

                if (pDataGrid != null)
                {
                    var grilla = xmlDoc.GetElementsByTagName("Grilla");

                    pPagina = Convert.ToInt32(((XmlElement)grilla[0]).GetAttribute("Pagina"));
                    pTamanoPagina = Convert.ToInt32(((XmlElement)grilla[0]).GetAttribute("TamanoPagina"));
                    if (pTamanoPagina == 0) pTamanoPagina = 25;
                    if (pPagina == 0) pPagina = 1;
                    pRegistrosGrilla = ((XmlElement)grilla[0]).GetAttribute("RegistrosGrilla") == Enums.EstadoRegistros.Habilitados.ToString()
                        ? Enums.EstadoRegistros.Habilitados
                        : Enums.EstadoRegistros.Inhabilitados;

                    XmlNodeList columnas = xmlDoc.GetElementsByTagName("Grilla");
                    XmlNodeList columnaLista = ((XmlElement)columnas[0]).GetElementsByTagName("Columna");
                    foreach (XmlElement columnaXml in columnaLista)
                    {
                        foreach (DataGridViewColumn columnaDataGrid in pDataGrid.Columns)
                        {
                            if (columnaDataGrid.Visible)
                            {
                                var attributeNode = columnaXml.GetAttributeNode("Name");
                                if (attributeNode != null && columnaDataGrid.HeaderText == attributeNode.Value)
                                {
                                    var xmlAttribute = columnaXml.GetAttributeNode("Width");
                                    if (xmlAttribute != null)
                                        columnaDataGrid.Width = Convert.ToInt32(xmlAttribute.Value);
                                    var attribute = columnaXml.GetAttributeNode("Sort");
                                    if (attribute != null)
                                        switch (attribute.Value)
                                        {
                                            case "Ascending":
                                                columnaDataGrid.HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                                                break;
                                            case "Descending":
                                                columnaDataGrid.HeaderCell.SortGlyphDirection = SortOrder.Descending;
                                                break;
                                            default:
                                                columnaDataGrid.HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                                                break;
                                        }
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
