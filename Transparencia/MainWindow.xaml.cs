using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Transparencia.Entity;
using Transparencia.BLL;
using System.IO;

namespace Transparencia
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Motivos> lista = new List<Motivos>();

            lista.Add(new Motivos("Vivienda", 0));
            lista.Add(new Motivos("Alimentacion", 1));
            lista.Add(new Motivos("Salud", 2));
            lista.Add(new Motivos("Infancia", 3));
            lista.Add(new Motivos("Defunciones", 4));
            lista.Add(new Motivos("Microemprendimiento", 5));
            lista.Add(new Motivos("Programa Social Gubernamental", 6));
            lista.Add(new Motivos("Maquinaria", 7));
            lista.Add(new Motivos("Personal Municipal", 8));
            lista.Add(new Motivos("Rebaja Aseo", 9));
            lista.Add(new Motivos("Entrega de agua", 10));
            lista.Add(new Motivos("Otros", 11));
            CmbMotivo.DisplayMemberPath = "Name";
            CmbMotivo.SelectedValuePath = "Value";
            CmbMotivo.ItemsSource = lista;

            List<Motivos> lista2 = new List<Motivos>();
            int anno = Convert.ToInt32(DateTime.Now.Year);
            for (int i = 2017; i <= anno; i++)
            {
                lista2.Add(new Motivos(i.ToString(), i));
            }
            CmbAnno.DisplayMemberPath = "Name";
            CmbAnno.SelectedValuePath = "Value";
            CmbAnno.ItemsSource = lista2;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int motivo = Convert.ToInt32(CmbMotivo.SelectedValue);
            int year = Convert.ToInt32(CmbAnno.SelectedValue);
            List<Solicitudes> listado = (new EstadisticasBLL()).ObtenerTransparenciaMotivo(motivo, year);
            if (motivo == 0)
            {
                StreamWriter file = new StreamWriter("D:\\Pagina web\\Subsidios\\" + year.ToString() + "\\vivienda" + year.ToString() + ".php"); // Abrir el txt
                // Cabeceras del html
                file.WriteLine("<? include (\"header.php\"); ?>");
                //Body del html
                file.WriteLine("<div class=\"row\">");
                file.WriteLine("<div class=\"col-sm-12\">");
                file.WriteLine(string.Format("<h3><center><b>Beneficiarios de Vivienda - {0}</b></center></h3> </br>", year));
                file.WriteLine("<style type=\"text/css\">");
                file.WriteLine(".tg  {border-collapse:collapse;border-spacing:0;border-color:#999;margin:0px auto;}");
                file.WriteLine(".tg td{font-family:Arial, sans-serif;font-size:10px;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:#999;color:#444;background-color:#F7FDFA;}");
                file.WriteLine(".tg th{font-family:Arial, sans-serif;font-size:10px;font-weight:normal;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:#999;color:#fff;background-color:#26ADE4;}");
                file.WriteLine(".tg .tg-yw4l{vertical-align:top}");
                file.WriteLine("th.tg-sort-header::-moz-selection { background:transparent; }th.tg-sort-header::selection      { background:transparent; }th.tg-sort-header { cursor:pointer; }table th.tg-sort-header:after {  content:'';  float:right;  margin-top:7px;  border-width:0 4px 4px;  border-style:solid;  border-color:#404040 transparent;  visibility:hidden;  }table th.tg-sort-header:hover:after {  visibility:visible;  }table th.tg-sort-desc:after,table th.tg-sort-asc:after,table th.tg-sort-asc:hover:after {  visibility:visible;  opacity:0.4;  }table th.tg-sort-desc:after {  border-bottom:none;  border-width:4px 4px 0;  }@media screen and (max-width: 767px) {.tg {width: auto !important;}.tg col {width: auto !important;}.tg-wrap {overflow-x: auto;-webkit-overflow-scrolling: touch;margin: auto 0px;}}</style>");
                //Crear tabla            
                file.WriteLine("<div class=\"tg-wrap\"><table id=\"tg-duF9v\" class=\"tg\">");
                //Cabecera de la tabla
                file.WriteLine("<tr>");
                file.WriteLine("<th class=\"tg-yw4l\">A&ntildeo</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Mes</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Nombre Programa</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Fecha otorgamiento</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Tipo Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Denominaci&oacuten Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Fecha Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Numero Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Raz&oacuten Social</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Nombre</th>");
                file.WriteLine("</tr>");
                if (listado.Count == 0)
                {
                    string lines = "";
                    lines = "<tr><td colspan=\"10\">NO EXISTEN BENEFICIARIOS A LA FECHA </td></tr>";
                    file.WriteLine(lines);
                }
                else
                {
                    foreach (Solicitudes item in listado)
                    {
                        string mes = "";
                        switch (item.FechaAprobacionDirector.Value.Month)
                        {
                            case 1:
                                mes = "ENERO";
                                break;
                            case 2:
                                mes = "FEBRERO";
                                break;
                            case 3:
                                mes = "MARZO";
                                break;
                            case 4:
                                mes = "ABRIL";
                                break;
                            case 5:
                                mes = "MAYO";
                                break;
                            case 6:
                                mes = "JUNIO";
                                break;
                            case 7:
                                mes = "JULIO";
                                break;
                            case 8:
                                mes = "AGOSTO";
                                break;
                            case 9:
                                mes = "SEPTIEMBRE";
                                break;
                            case 10:
                                mes = "OCTUBRE";
                                break;
                            case 11:
                                mes = "NOVIEMBRE";
                                break;
                            case 12:
                                mes = "DICIEMBRE";
                                break;
                        }
                        string lines = "";
                        lines = "<tr>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + item.FechaAprobacionDirector.Value.Year + "</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + mes + "</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">VIVIENDA</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + item.FechaAprobacionDirector.Value + "</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">Decreto Alcaldicio</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">Otorga Beneficio Proyecto Social</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">25/11/2013</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">2197</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">No aplica</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + item.Beneficiario.Nombre + "</td>";
                        file.WriteLine(lines);
                        lines = "</tr>";
                        file.WriteLine(lines);
                    }
                    //Cerrar tabla
                }
                file.WriteLine("</table></div>");
                System.IO.StreamReader file2 = new System.IO.StreamReader("...\\...\\Script\\script.txt"); // Abrir el txt
                string linea;
                while ((linea = file2.ReadLine()) != null) file.WriteLine(linea);
                file.WriteLine();
                file.WriteLine("</div></div>");
                //Footer
                file.WriteLine("<? include (\"footer.php\"); ?>");
                //Cerrar archivo
                file.Close();
            }
            if (motivo == 1)
            {
                StreamWriter file = new StreamWriter("D:\\Pagina web\\Subsidios\\" + year.ToString() + "\\alimentacion" + year.ToString() + ".php"); // Abrir el txt
                // Cabeceras del html
                file.WriteLine("<? include (\"header.php\"); ?>");
                //Body del html
                file.WriteLine("<div class=\"row\">");
                file.WriteLine("<div class=\"col-sm-12\">");
                file.WriteLine(string.Format("<h3><center><b>Beneficiarios de Alimentaci&oacuten - {0}</b></center></h3></br>", year));
                file.WriteLine("<style type=\"text/css\">");
                file.WriteLine(".tg  {border-collapse:collapse;border-spacing:0;border-color:#999;margin:0px auto;}");
                file.WriteLine(".tg td{font-family:Arial, sans-serif;font-size:10px;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:#999;color:#444;background-color:#F7FDFA;}");
                file.WriteLine(".tg th{font-family:Arial, sans-serif;font-size:10px;font-weight:normal;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:#999;color:#fff;background-color:#26ADE4;}");
                file.WriteLine(".tg .tg-yw4l{vertical-align:top}");
                file.WriteLine("th.tg-sort-header::-moz-selection { background:transparent; }th.tg-sort-header::selection      { background:transparent; }th.tg-sort-header { cursor:pointer; }table th.tg-sort-header:after {  content:'';  float:right;  margin-top:7px;  border-width:0 4px 4px;  border-style:solid;  border-color:#404040 transparent;  visibility:hidden;  }table th.tg-sort-header:hover:after {  visibility:visible;  }table th.tg-sort-desc:after,table th.tg-sort-asc:after,table th.tg-sort-asc:hover:after {  visibility:visible;  opacity:0.4;  }table th.tg-sort-desc:after {  border-bottom:none;  border-width:4px 4px 0;  }@media screen and (max-width: 767px) {.tg {width: auto !important;}.tg col {width: auto !important;}.tg-wrap {overflow-x: auto;-webkit-overflow-scrolling: touch;margin: auto 0px;}}</style>");
                //Crear tabla            
                file.WriteLine("<div class=\"tg-wrap\"><table id=\"tg-duF9v\" class=\"tg\">");
                //Cabecera de la tabla
                file.WriteLine("<tr>");
                file.WriteLine("<th class=\"tg-yw4l\">A&ntildeo</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Mes</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Nombre Programa</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Fecha otorgamiento</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Tipo Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Denominaci&oacuten Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Fecha Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Numero Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Raz&oacuten Social</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Nombre</th>");
                file.WriteLine("</tr>");
                if (listado.Count == 0)
                {
                    string lines = "";
                    lines = "<tr><td colspan=\"10\">NO EXISTEN BENEFICIARIOS A LA FECHA </td></tr>";
                    file.WriteLine(lines);
                }
                else
                {
                    foreach (Solicitudes item in listado)
                    {
                        string mes = "";
                        switch (item.FechaAprobacionDirector.Value.Month)
                        {
                            case 1:
                                mes = "ENERO";
                                break;
                            case 2:
                                mes = "FEBRERO";
                                break;
                            case 3:
                                mes = "MARZO";
                                break;
                            case 4:
                                mes = "ABRIL";
                                break;
                            case 5:
                                mes = "MAYO";
                                break;
                            case 6:
                                mes = "JUNIO";
                                break;
                            case 7:
                                mes = "JULIO";
                                break;
                            case 8:
                                mes = "AGOSTO";
                                break;
                            case 9:
                                mes = "SEPTIEMBRE";
                                break;
                            case 10:
                                mes = "OCTUBRE";
                                break;
                            case 11:
                                mes = "NOVIEMBRE";
                                break;
                            case 12:
                                mes = "DICIEMBRE";
                                break;
                        }
                        string lines = "";
                        lines = "<tr>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + item.FechaAprobacionDirector.Value.Year + "</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + mes + "</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">ALIMENTACI&OacuteN</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + item.FechaAprobacionDirector.Value + "</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">Decreto Alcaldicio</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">Otorga Beneficio Proyecto Social</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">25/11/2013</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">2197</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">No aplica</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + item.Beneficiario.Nombre + "</td>";
                        file.WriteLine(lines);
                        lines = "</tr>";
                        file.WriteLine(lines);
                    }
                }
                //Cerrar tabla
                file.WriteLine("</table></div>");
                System.IO.StreamReader file2 = new System.IO.StreamReader("...\\...\\Script\\script.txt"); // Abrir el txt
                string linea;
                while ((linea = file2.ReadLine()) != null) file.WriteLine(linea);
                file.WriteLine();
                file.WriteLine("</div>");
                file.WriteLine("</div>");
                //Footer
                file.WriteLine("<? include (\"footer.php\"); ?>");
                //Cerrar archivo
                file.Close();
            }
            if (motivo == 2)
            {
                StreamWriter file = new StreamWriter("D:\\Pagina web\\Subsidios\\" + year.ToString() + "\\salud" + year.ToString() + ".php"); // Abrir el txt
                // Cabeceras del html
                file.WriteLine("<? include (\"header.php\"); ?>");
                //Body del html
                file.WriteLine("<div class=\"row\">");
                file.WriteLine("<div class=\"col-sm-12\">");
                file.WriteLine(string.Format("<h3><center><b>Beneficiarios de Salud - {0}</b></center></h3></br>", year));
                file.WriteLine("<style type=\"text/css\">");
                file.WriteLine(".tg  {border-collapse:collapse;border-spacing:0;border-color:#999;margin:0px auto;}");
                file.WriteLine(".tg td{font-family:Arial, sans-serif;font-size:10px;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:#999;color:#444;background-color:#F7FDFA;}");
                file.WriteLine(".tg th{font-family:Arial, sans-serif;font-size:10px;font-weight:normal;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:#999;color:#fff;background-color:#26ADE4;}");
                file.WriteLine(".tg .tg-yw4l{vertical-align:top}");
                file.WriteLine("th.tg-sort-header::-moz-selection { background:transparent; }th.tg-sort-header::selection      { background:transparent; }th.tg-sort-header { cursor:pointer; }table th.tg-sort-header:after {  content:'';  float:right;  margin-top:7px;  border-width:0 4px 4px;  border-style:solid;  border-color:#404040 transparent;  visibility:hidden;  }table th.tg-sort-header:hover:after {  visibility:visible;  }table th.tg-sort-desc:after,table th.tg-sort-asc:after,table th.tg-sort-asc:hover:after {  visibility:visible;  opacity:0.4;  }table th.tg-sort-desc:after {  border-bottom:none;  border-width:4px 4px 0;  }@media screen and (max-width: 767px) {.tg {width: auto !important;}.tg col {width: auto !important;}.tg-wrap {overflow-x: auto;-webkit-overflow-scrolling: touch;margin: auto 0px;}}</style>");
                //Crear tabla            
                file.WriteLine("<div class=\"tg-wrap\"><table id=\"tg-duF9v\" class=\"tg\">");
                //Cabecera de la tabla
                file.WriteLine("<tr>");
                file.WriteLine("<th class=\"tg-yw4l\">A&ntildeo</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Mes</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Nombre Programa</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Fecha otorgamiento</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Tipo Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Denominaci&oacuten Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Fecha Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Numero Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Raz&oacuten Social</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Nombre</th>");
                file.WriteLine("</tr>");
                if (listado.Count == 0)
                {
                    string lines = "";
                    lines = "<tr><td colspan=\"10\">NO EXISTEN BENEFICIARIOS A LA FECHA </td></tr>";
                    file.WriteLine(lines);
                }
                else
                {
                    foreach (Solicitudes item in listado)
                    {
                        string mes = "";
                        switch (item.FechaAprobacionDirector.Value.Month)
                        {
                            case 1:
                                mes = "ENERO";
                                break;
                            case 2:
                                mes = "FEBRERO";
                                break;
                            case 3:
                                mes = "MARZO";
                                break;
                            case 4:
                                mes = "ABRIL";
                                break;
                            case 5:
                                mes = "MAYO";
                                break;
                            case 6:
                                mes = "JUNIO";
                                break;
                            case 7:
                                mes = "JULIO";
                                break;
                            case 8:
                                mes = "AGOSTO";
                                break;
                            case 9:
                                mes = "SEPTIEMBRE";
                                break;
                            case 10:
                                mes = "OCTUBRE";
                                break;
                            case 11:
                                mes = "NOVIEMBRE";
                                break;
                            case 12:
                                mes = "DICIEMBRE";
                                break;
                        }
                        string lines = "";
                        lines = "<tr>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + item.FechaAprobacionDirector.Value.Year + "</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + mes + "</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">SALUD</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + item.FechaAprobacionDirector.Value + "</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">Decreto Alcaldicio</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">Otorga Beneficio Proyecto Social</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">25/11/2013</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">2197</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">No aplica</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + item.Beneficiario.Nombre + "</td>";
                        file.WriteLine(lines);
                        lines = "</tr>";
                        file.WriteLine(lines);
                    }
                }
                //Cerrar tabla
                file.WriteLine("</table></div>");
                System.IO.StreamReader file2 = new System.IO.StreamReader("...\\...\\Script\\script.txt"); // Abrir el txt
                string linea;
                while ((linea = file2.ReadLine()) != null) file.WriteLine(linea);
                file.WriteLine();
                file.WriteLine("</div>");
                file.WriteLine("</div>");
                //Footer
                file.WriteLine("<? include (\"footer.php\"); ?>");
                //Cerrar archivo
                file.Close();
            }
            if (motivo == 3)
            {
                StreamWriter file = new StreamWriter("D:\\Pagina web\\Subsidios\\" + year.ToString() + "\\infancia" + year.ToString() + ".php"); // Abrir el txt
                // Cabeceras del html
                file.WriteLine("<? include (\"header.php\"); ?>");
                //Body del html
                file.WriteLine("<div class=\"row\">");
                file.WriteLine("<div class=\"col-sm-12\">");
                file.WriteLine(string.Format("<h3><center><b>Beneficiarios de Infancia - {0}</b></center></h3></br>", year));
                file.WriteLine("<style type=\"text/css\">");
                file.WriteLine(".tg  {border-collapse:collapse;border-spacing:0;border-color:#999;margin:0px auto;}");
                file.WriteLine(".tg td{font-family:Arial, sans-serif;font-size:10px;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:#999;color:#444;background-color:#F7FDFA;}");
                file.WriteLine(".tg th{font-family:Arial, sans-serif;font-size:10px;font-weight:normal;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:#999;color:#fff;background-color:#26ADE4;}");
                file.WriteLine(".tg .tg-yw4l{vertical-align:top}");
                file.WriteLine("th.tg-sort-header::-moz-selection { background:transparent; }th.tg-sort-header::selection      { background:transparent; }th.tg-sort-header { cursor:pointer; }table th.tg-sort-header:after {  content:'';  float:right;  margin-top:7px;  border-width:0 4px 4px;  border-style:solid;  border-color:#404040 transparent;  visibility:hidden;  }table th.tg-sort-header:hover:after {  visibility:visible;  }table th.tg-sort-desc:after,table th.tg-sort-asc:after,table th.tg-sort-asc:hover:after {  visibility:visible;  opacity:0.4;  }table th.tg-sort-desc:after {  border-bottom:none;  border-width:4px 4px 0;  }@media screen and (max-width: 767px) {.tg {width: auto !important;}.tg col {width: auto !important;}.tg-wrap {overflow-x: auto;-webkit-overflow-scrolling: touch;margin: auto 0px;}}</style>");
                //Crear tabla            
                file.WriteLine("<div class=\"tg-wrap\"><table id=\"tg-duF9v\" class=\"tg\">");
                //Cabecera de la tabla
                file.WriteLine("<tr>");
                file.WriteLine("<th class=\"tg-yw4l\">A&ntildeo</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Mes</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Nombre Programa</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Fecha otorgamiento</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Tipo Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Denominaci&oacuten Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Fecha Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Numero Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Raz&oacuten Social</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Nombre</th>");
                file.WriteLine("</tr>");
                if (listado.Count == 0)
                {
                    string lines = "";
                    lines = "<tr><td colspan=\"10\">NO EXISTEN BENEFICIARIOS A LA FECHA </td></tr>";
                    file.WriteLine(lines);
                }
                else
                {
                    foreach (Solicitudes item in listado)
                    {
                        string mes = "";
                        switch (item.FechaAprobacionDirector.Value.Month)
                        {
                            case 1:
                                mes = "ENERO";
                                break;
                            case 2:
                                mes = "FEBRERO";
                                break;
                            case 3:
                                mes = "MARZO";
                                break;
                            case 4:
                                mes = "ABRIL";
                                break;
                            case 5:
                                mes = "MAYO";
                                break;
                            case 6:
                                mes = "JUNIO";
                                break;
                            case 7:
                                mes = "JULIO";
                                break;
                            case 8:
                                mes = "AGOSTO";
                                break;
                            case 9:
                                mes = "SEPTIEMBRE";
                                break;
                            case 10:
                                mes = "OCTUBRE";
                                break;
                            case 11:
                                mes = "NOVIEMBRE";
                                break;
                            case 12:
                                mes = "DICIEMBRE";
                                break;
                        }
                        string lines = "";
                        lines = "<tr>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + item.FechaAprobacionDirector.Value.Year + "</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + mes + "</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">INFANCIA</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + item.FechaAprobacionDirector.Value + "</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">Decreto Alcaldicio</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">Otorga Beneficio Proyecto Social</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">25/11/2013</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">2197</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">No aplica</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + item.Beneficiario.Nombre + "</td>";
                        file.WriteLine(lines);
                        lines = "</tr>";
                        file.WriteLine(lines);
                    }
                }
                //Cerrar tabla
                file.WriteLine("</table></div>");
                System.IO.StreamReader file2 = new System.IO.StreamReader("...\\...\\Script\\script.txt"); // Abrir el txt
                string linea;
                while ((linea = file2.ReadLine()) != null) file.WriteLine(linea);
                file.WriteLine();
                file.WriteLine("</div>");
                file.WriteLine("</div>");
                //Footer
                file.WriteLine("<? include (\"footer.php\"); ?>");
                //Cerrar archivo
                file.Close();
            }
            if (motivo == 4)
            {
                StreamWriter file = new StreamWriter("D:\\Pagina web\\Subsidios\\" + year.ToString() + "\\defunciones" + year.ToString() + ".php"); // Abrir el txt
                // Cabeceras del html
                file.WriteLine("<? include (\"header.php\"); ?>");
                //Body del html
                file.WriteLine("<div class=\"row\">");
                file.WriteLine("<div class=\"col-sm-12\">");
                file.WriteLine(string.Format("<h3><center><b>Beneficiarios de Defunciones - {0}</b></center></h3></br>", year));
                file.WriteLine("<style type=\"text/css\">");
                file.WriteLine(".tg  {border-collapse:collapse;border-spacing:0;border-color:#999;margin:0px auto;}");
                file.WriteLine(".tg td{font-family:Arial, sans-serif;font-size:10px;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:#999;color:#444;background-color:#F7FDFA;}");
                file.WriteLine(".tg th{font-family:Arial, sans-serif;font-size:10px;font-weight:normal;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:#999;color:#fff;background-color:#26ADE4;}");
                file.WriteLine(".tg .tg-yw4l{vertical-align:top}");
                file.WriteLine("th.tg-sort-header::-moz-selection { background:transparent; }th.tg-sort-header::selection      { background:transparent; }th.tg-sort-header { cursor:pointer; }table th.tg-sort-header:after {  content:'';  float:right;  margin-top:7px;  border-width:0 4px 4px;  border-style:solid;  border-color:#404040 transparent;  visibility:hidden;  }table th.tg-sort-header:hover:after {  visibility:visible;  }table th.tg-sort-desc:after,table th.tg-sort-asc:after,table th.tg-sort-asc:hover:after {  visibility:visible;  opacity:0.4;  }table th.tg-sort-desc:after {  border-bottom:none;  border-width:4px 4px 0;  }@media screen and (max-width: 767px) {.tg {width: auto !important;}.tg col {width: auto !important;}.tg-wrap {overflow-x: auto;-webkit-overflow-scrolling: touch;margin: auto 0px;}}</style>");
                //Crear tabla            
                file.WriteLine("<div class=\"tg-wrap\"><table id=\"tg-duF9v\" class=\"tg\">");
                //Cabecera de la tabla
                file.WriteLine("<tr>");
                file.WriteLine("<th class=\"tg-yw4l\">A&ntildeo</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Mes</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Nombre Programa</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Fecha otorgamiento</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Tipo Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Denominaci&oacuten Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Fecha Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Numero Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Raz&oacuten Social</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Nombre</th>");
                file.WriteLine("</tr>");
                if (listado.Count == 0)
                {
                    string lines = "";
                    lines = "<tr><td colspan=\"10\">NO EXISTEN BENEFICIARIOS A LA FECHA </td></tr>";
                    file.WriteLine(lines);
                }
                else
                {
                    foreach (Solicitudes item in listado)
                    {
                        string mes = "";
                        switch (item.FechaAprobacionDirector.Value.Month)
                        {
                            case 1:
                                mes = "ENERO";
                                break;
                            case 2:
                                mes = "FEBRERO";
                                break;
                            case 3:
                                mes = "MARZO";
                                break;
                            case 4:
                                mes = "ABRIL";
                                break;
                            case 5:
                                mes = "MAYO";
                                break;
                            case 6:
                                mes = "JUNIO";
                                break;
                            case 7:
                                mes = "JULIO";
                                break;
                            case 8:
                                mes = "AGOSTO";
                                break;
                            case 9:
                                mes = "SEPTIEMBRE";
                                break;
                            case 10:
                                mes = "OCTUBRE";
                                break;
                            case 11:
                                mes = "NOVIEMBRE";
                                break;
                            case 12:
                                mes = "DICIEMBRE";
                                break;
                        }
                        string lines = "";
                        lines = "<tr>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + item.FechaAprobacionDirector.Value.Year + "</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + mes + "</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">DEFUNCIONES</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + item.FechaAprobacionDirector.Value + "</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">Decreto Alcaldicio</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">Otorga Beneficio Proyecto Social</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">25/11/2013</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">2197</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">No aplica</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + item.Beneficiario.Nombre + "</td>";
                        file.WriteLine(lines);
                        lines = "</tr>";
                        file.WriteLine(lines);
                    }
                }
                //Cerrar tabla
                file.WriteLine("</table></div>");
                System.IO.StreamReader file2 = new System.IO.StreamReader("...\\...\\Script\\script.txt"); // Abrir el txt
                string linea;
                while ((linea = file2.ReadLine()) != null) file.WriteLine(linea);
                file.WriteLine();
                file.WriteLine("</div>");
                file.WriteLine("</div>");
                //Footer
                file.WriteLine("<? include (\"footer.php\"); ?>");
                //Cerrar archivo
                file.Close();
            }
            if (motivo == 5)
            {
                StreamWriter file = new StreamWriter("D:\\Pagina web\\Subsidios\\" + year.ToString() + "\\microemprendimiento" + year.ToString() + ".php"); // Abrir el txt
                // Cabeceras del html
                file.WriteLine("<? include (\"header.php\"); ?>");
                //Body del html
                file.WriteLine("<div class=\"row\">");
                file.WriteLine("<div class=\"col-sm-12\">");
                file.WriteLine(string.Format("<center><b>Beneficiarios de Microemprendimiento - {0}</b></center>", year));
                file.WriteLine("<style type=\"text/css\">");
                file.WriteLine(".tg  {border-collapse:collapse;border-spacing:0;border-color:#999;margin:0px auto;}");
                file.WriteLine(".tg td{font-family:Arial, sans-serif;font-size:10px;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:#999;color:#444;background-color:#F7FDFA;}");
                file.WriteLine(".tg th{font-family:Arial, sans-serif;font-size:10px;font-weight:normal;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:#999;color:#fff;background-color:#26ADE4;}");
                file.WriteLine(".tg .tg-yw4l{vertical-align:top}");
                file.WriteLine("th.tg-sort-header::-moz-selection { background:transparent; }th.tg-sort-header::selection      { background:transparent; }th.tg-sort-header { cursor:pointer; }table th.tg-sort-header:after {  content:'';  float:right;  margin-top:7px;  border-width:0 4px 4px;  border-style:solid;  border-color:#404040 transparent;  visibility:hidden;  }table th.tg-sort-header:hover:after {  visibility:visible;  }table th.tg-sort-desc:after,table th.tg-sort-asc:after,table th.tg-sort-asc:hover:after {  visibility:visible;  opacity:0.4;  }table th.tg-sort-desc:after {  border-bottom:none;  border-width:4px 4px 0;  }@media screen and (max-width: 767px) {.tg {width: auto !important;}.tg col {width: auto !important;}.tg-wrap {overflow-x: auto;-webkit-overflow-scrolling: touch;margin: auto 0px;}}</style>");
                //Crear tabla            
                file.WriteLine("<div class=\"tg-wrap\"><table id=\"tg-duF9v\" class=\"tg\">");
                //Cabecera de la tabla
                file.WriteLine("<tr>");
                file.WriteLine("<th class=\"tg-yw4l\">A&ntildeo</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Mes</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Nombre Programa</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Fecha otorgamiento</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Tipo Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Denominaci&oacuten Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Fecha Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Numero Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Raz&oacuten Social</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Nombre</th>");
                file.WriteLine("</tr>");
                if (listado.Count == 0)
                {
                    string lines = "";
                    lines = "<tr><td colspan=\"10\">NO EXISTEN BENEFICIARIOS A LA FECHA </td></tr>";
                    file.WriteLine(lines);
                }
                else
                {
                    foreach (Solicitudes item in listado)
                    {
                        string mes = "";
                        switch (item.FechaAprobacionDirector.Value.Month)
                        {
                            case 1:
                                mes = "ENERO";
                                break;
                            case 2:
                                mes = "FEBRERO";
                                break;
                            case 3:
                                mes = "MARZO";
                                break;
                            case 4:
                                mes = "ABRIL";
                                break;
                            case 5:
                                mes = "MAYO";
                                break;
                            case 6:
                                mes = "JUNIO";
                                break;
                            case 7:
                                mes = "JULIO";
                                break;
                            case 8:
                                mes = "AGOSTO";
                                break;
                            case 9:
                                mes = "SEPTIEMBRE";
                                break;
                            case 10:
                                mes = "OCTUBRE";
                                break;
                            case 11:
                                mes = "NOVIEMBRE";
                                break;
                            case 12:
                                mes = "DICIEMBRE";
                                break;
                        }
                        string lines = "";
                        lines = "<tr>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + item.FechaAprobacionDirector.Value.Year + "</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + mes + "</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">MICROEMPRENDIMIENTO</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + item.FechaAprobacionDirector.Value + "</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">Decreto Alcaldicio</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">Otorga Beneficio Proyecto Social</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">25/11/2013</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">2197</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">No aplica</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + item.Beneficiario.Nombre + "</td>";
                        file.WriteLine(lines);
                        lines = "</tr>";
                        file.WriteLine(lines);
                    }
                }
                //Cerrar tabla
                file.WriteLine("</table></div>");
                System.IO.StreamReader file2 = new System.IO.StreamReader("...\\...\\Script\\script.txt"); // Abrir el txt
                string linea;
                while ((linea = file2.ReadLine()) != null) file.WriteLine(linea);
                file.WriteLine();
                file.WriteLine("</div>");
                file.WriteLine("</div>");
                //Footer
                file.WriteLine("<? include (\"footer.php\"); ?>");
                //Cerrar archivo
                file.Close();
            }
            if (motivo == 6)
            {
                StreamWriter file = new StreamWriter("D:\\Pagina web\\Subsidios\\" + year.ToString() + "\\psgubernamental" + year.ToString() + ".php"); // Abrir el txt
                // Cabeceras del html
                file.WriteLine("<? include (\"header.php\"); ?>");
                //Body del html
                file.WriteLine("<div class=\"row\">");
                file.WriteLine("<div class=\"col-sm-12\">");
                file.WriteLine(string.Format("<center><b>Beneficiarios de Programa Social Gubernamental - {0}</b></center>", year));
                file.WriteLine("<style type=\"text/css\">");
                file.WriteLine(".tg  {border-collapse:collapse;border-spacing:0;border-color:#999;margin:0px auto;}");
                file.WriteLine(".tg td{font-family:Arial, sans-serif;font-size:10px;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:#999;color:#444;background-color:#F7FDFA;}");
                file.WriteLine(".tg th{font-family:Arial, sans-serif;font-size:10px;font-weight:normal;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:#999;color:#fff;background-color:#26ADE4;}");
                file.WriteLine(".tg .tg-yw4l{vertical-align:top}");
                file.WriteLine("th.tg-sort-header::-moz-selection { background:transparent; }th.tg-sort-header::selection      { background:transparent; }th.tg-sort-header { cursor:pointer; }table th.tg-sort-header:after {  content:'';  float:right;  margin-top:7px;  border-width:0 4px 4px;  border-style:solid;  border-color:#404040 transparent;  visibility:hidden;  }table th.tg-sort-header:hover:after {  visibility:visible;  }table th.tg-sort-desc:after,table th.tg-sort-asc:after,table th.tg-sort-asc:hover:after {  visibility:visible;  opacity:0.4;  }table th.tg-sort-desc:after {  border-bottom:none;  border-width:4px 4px 0;  }@media screen and (max-width: 767px) {.tg {width: auto !important;}.tg col {width: auto !important;}.tg-wrap {overflow-x: auto;-webkit-overflow-scrolling: touch;margin: auto 0px;}}</style>");
                //Crear tabla            
                file.WriteLine("<div class=\"tg-wrap\"><table id=\"tg-duF9v\" class=\"tg\">");
                //Cabecera de la tabla
                file.WriteLine("<tr>");
                file.WriteLine("<th class=\"tg-yw4l\">A&ntildeo</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Mes</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Nombre Programa</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Fecha otorgamiento</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Tipo Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Denominaci&oacuten Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Fecha Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Numero Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Raz&oacuten Social</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Nombre</th>");
                file.WriteLine("</tr>");
                if (listado.Count == 0)
                {
                    string lines = "";
                    lines = "<tr><td colspan=\"10\">NO EXISTEN BENEFICIARIOS A LA FECHA </td></tr>";
                    file.WriteLine(lines);
                }
                else
                {
                    foreach (Solicitudes item in listado)
                    {
                        string mes = "";
                        switch (item.FechaAprobacionDirector.Value.Month)
                        {
                            case 1:
                                mes = "ENERO";
                                break;
                            case 2:
                                mes = "FEBRERO";
                                break;
                            case 3:
                                mes = "MARZO";
                                break;
                            case 4:
                                mes = "ABRIL";
                                break;
                            case 5:
                                mes = "MAYO";
                                break;
                            case 6:
                                mes = "JUNIO";
                                break;
                            case 7:
                                mes = "JULIO";
                                break;
                            case 8:
                                mes = "AGOSTO";
                                break;
                            case 9:
                                mes = "SEPTIEMBRE";
                                break;
                            case 10:
                                mes = "OCTUBRE";
                                break;
                            case 11:
                                mes = "NOVIEMBRE";
                                break;
                            case 12:
                                mes = "DICIEMBRE";
                                break;
                        }
                        string lines = "";
                        lines = "<tr>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + item.FechaAprobacionDirector.Value.Year + "</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + mes + "</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">PROGRAMA SOCIAL GUBERNAMENTAL</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + item.FechaAprobacionDirector.Value + "</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">Decreto Alcaldicio</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">Otorga Beneficio Proyecto Social</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">25/11/2013</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">2197</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">No aplica</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + item.Beneficiario.Nombre + "</td>";
                        file.WriteLine(lines);
                        lines = "</tr>";
                        file.WriteLine(lines);
                    }
                }
                //Cerrar tabla
                file.WriteLine("</table></div>");
                System.IO.StreamReader file2 = new System.IO.StreamReader("...\\...\\Script\\script.txt"); // Abrir el txt
                string linea;
                while ((linea = file2.ReadLine()) != null) file.WriteLine(linea);
                file.WriteLine();
                file.WriteLine("</div>");
                file.WriteLine("</div>");
                //Footer
                file.WriteLine("<? include (\"footer.php\"); ?>");
                //Cerrar archivo
                file.Close();
            }
            if (motivo == 7)
            {
                StreamWriter file = new StreamWriter("D:\\Pagina web\\Subsidios\\" + year.ToString() + "\\maquinaria" + year.ToString() + ".php"); // Abrir el txt
                // Cabeceras del html
                file.WriteLine("<? include (\"header.php\"); ?>");
                //Body del html
                file.WriteLine("<div class=\"row\">");
                file.WriteLine("<div class=\"col-sm-12\">");
                file.WriteLine(string.Format("<center><b>Beneficiarios de Maquinaria - {0}</b></center>", year));
                file.WriteLine("<style type=\"text/css\">");
                file.WriteLine(".tg  {border-collapse:collapse;border-spacing:0;border-color:#999;margin:0px auto;}");
                file.WriteLine(".tg td{font-family:Arial, sans-serif;font-size:10px;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:#999;color:#444;background-color:#F7FDFA;}");
                file.WriteLine(".tg th{font-family:Arial, sans-serif;font-size:10px;font-weight:normal;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:#999;color:#fff;background-color:#26ADE4;}");
                file.WriteLine(".tg .tg-yw4l{vertical-align:top}");
                file.WriteLine("th.tg-sort-header::-moz-selection { background:transparent; }th.tg-sort-header::selection      { background:transparent; }th.tg-sort-header { cursor:pointer; }table th.tg-sort-header:after {  content:'';  float:right;  margin-top:7px;  border-width:0 4px 4px;  border-style:solid;  border-color:#404040 transparent;  visibility:hidden;  }table th.tg-sort-header:hover:after {  visibility:visible;  }table th.tg-sort-desc:after,table th.tg-sort-asc:after,table th.tg-sort-asc:hover:after {  visibility:visible;  opacity:0.4;  }table th.tg-sort-desc:after {  border-bottom:none;  border-width:4px 4px 0;  }@media screen and (max-width: 767px) {.tg {width: auto !important;}.tg col {width: auto !important;}.tg-wrap {overflow-x: auto;-webkit-overflow-scrolling: touch;margin: auto 0px;}}</style>");
                //Crear tabla            
                file.WriteLine("<div class=\"tg-wrap\"><table id=\"tg-duF9v\" class=\"tg\">");
                //Cabecera de la tabla
                file.WriteLine("<tr>");
                file.WriteLine("<th class=\"tg-yw4l\">A&ntildeo</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Mes</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Nombre Programa</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Fecha otorgamiento</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Tipo Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Denominaci&oacuten Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Fecha Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Numero Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Raz&oacuten Social</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Nombre</th>");
                file.WriteLine("</tr>");
                if (listado.Count == 0)
                {
                    string lines = "";
                    lines = "<tr><td colspan=\"10\">NO EXISTEN BENEFICIARIOS A LA FECHA </td></tr>";
                    file.WriteLine(lines);
                }
                else
                {
                    foreach (Solicitudes item in listado)
                    {
                        string mes = "";
                        switch (item.FechaAprobacionDirector.Value.Month)
                        {
                            case 1:
                                mes = "ENERO";
                                break;
                            case 2:
                                mes = "FEBRERO";
                                break;
                            case 3:
                                mes = "MARZO";
                                break;
                            case 4:
                                mes = "ABRIL";
                                break;
                            case 5:
                                mes = "MAYO";
                                break;
                            case 6:
                                mes = "JUNIO";
                                break;
                            case 7:
                                mes = "JULIO";
                                break;
                            case 8:
                                mes = "AGOSTO";
                                break;
                            case 9:
                                mes = "SEPTIEMBRE";
                                break;
                            case 10:
                                mes = "OCTUBRE";
                                break;
                            case 11:
                                mes = "NOVIEMBRE";
                                break;
                            case 12:
                                mes = "DICIEMBRE";
                                break;
                        }
                        string lines = "";
                        lines = "<tr>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + item.FechaAprobacionDirector.Value.Year + "</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + mes + "</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">MAQUINARIA</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + item.FechaAprobacionDirector.Value + "</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">Decreto Alcaldicio</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">Otorga Beneficio Proyecto Social</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">25/11/2013</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">2197</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">No aplica</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + item.Beneficiario.Nombre + "</td>";
                        file.WriteLine(lines);
                        lines = "</tr>";
                        file.WriteLine(lines);
                    }
                }
                //Cerrar tabla
                file.WriteLine("</table></div>");
                System.IO.StreamReader file2 = new System.IO.StreamReader("...\\...\\Script\\script.txt"); // Abrir el txt
                string linea;
                while ((linea = file2.ReadLine()) != null) file.WriteLine(linea);
                file.WriteLine();
                file.WriteLine("</div>");
                file.WriteLine("</div>");
                //Footer
                file.WriteLine("<? include (\"footer.php\"); ?>");
                //Cerrar archivo
                file.Close();
            }
            if (motivo == 8)
            {
                StreamWriter file = new StreamWriter("D:\\Pagina web\\Subsidios\\" + year.ToString() + "\\personalmunicipal" + year.ToString() + ".php"); // Abrir el txt
                // Cabeceras del html
                file.WriteLine("<? include (\"header.php\"); ?>");
                //Body del html
                file.WriteLine("<div class=\"row\">");
                file.WriteLine("<div class=\"col-sm-12\">");
                file.WriteLine(string.Format("<center><b>Beneficiarios de Personal Municipal - {0}</b></center>", year));
                file.WriteLine("<style type=\"text/css\">");
                file.WriteLine(".tg  {border-collapse:collapse;border-spacing:0;border-color:#999;margin:0px auto;}");
                file.WriteLine(".tg td{font-family:Arial, sans-serif;font-size:10px;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:#999;color:#444;background-color:#F7FDFA;}");
                file.WriteLine(".tg th{font-family:Arial, sans-serif;font-size:10px;font-weight:normal;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:#999;color:#fff;background-color:#26ADE4;}");
                file.WriteLine(".tg .tg-yw4l{vertical-align:top}");
                file.WriteLine("th.tg-sort-header::-moz-selection { background:transparent; }th.tg-sort-header::selection      { background:transparent; }th.tg-sort-header { cursor:pointer; }table th.tg-sort-header:after {  content:'';  float:right;  margin-top:7px;  border-width:0 4px 4px;  border-style:solid;  border-color:#404040 transparent;  visibility:hidden;  }table th.tg-sort-header:hover:after {  visibility:visible;  }table th.tg-sort-desc:after,table th.tg-sort-asc:after,table th.tg-sort-asc:hover:after {  visibility:visible;  opacity:0.4;  }table th.tg-sort-desc:after {  border-bottom:none;  border-width:4px 4px 0;  }@media screen and (max-width: 767px) {.tg {width: auto !important;}.tg col {width: auto !important;}.tg-wrap {overflow-x: auto;-webkit-overflow-scrolling: touch;margin: auto 0px;}}</style>");
                //Crear tabla            
                file.WriteLine("<div class=\"tg-wrap\"><table id=\"tg-duF9v\" class=\"tg\">");
                //Cabecera de la tabla
                file.WriteLine("<tr>");
                file.WriteLine("<th class=\"tg-yw4l\">A&ntildeo</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Mes</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Nombre Programa</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Fecha otorgamiento</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Tipo Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Denominaci&oacuten Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Fecha Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Numero Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Raz&oacuten Social</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Nombre</th>");
                file.WriteLine("</tr>");
                if (listado.Count == 0)
                {
                    string lines = "";
                    lines = "<tr><td colspan=\"10\">NO EXISTEN BENEFICIARIOS A LA FECHA </td></tr>";
                    file.WriteLine(lines);
                }
                else
                {
                    foreach (Solicitudes item in listado)
                    {
                        string mes = "";
                        switch (item.FechaAprobacionDirector.Value.Month)
                        {
                            case 1:
                                mes = "ENERO";
                                break;
                            case 2:
                                mes = "FEBRERO";
                                break;
                            case 3:
                                mes = "MARZO";
                                break;
                            case 4:
                                mes = "ABRIL";
                                break;
                            case 5:
                                mes = "MAYO";
                                break;
                            case 6:
                                mes = "JUNIO";
                                break;
                            case 7:
                                mes = "JULIO";
                                break;
                            case 8:
                                mes = "AGOSTO";
                                break;
                            case 9:
                                mes = "SEPTIEMBRE";
                                break;
                            case 10:
                                mes = "OCTUBRE";
                                break;
                            case 11:
                                mes = "NOVIEMBRE";
                                break;
                            case 12:
                                mes = "DICIEMBRE";
                                break;
                        }
                        string lines = "";
                        lines = "<tr>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + item.FechaAprobacionDirector.Value.Year + "</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + mes + "</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">PERSONAL MUNICIPAL</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + item.FechaAprobacionDirector.Value + "</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">Decreto Alcaldicio</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">Otorga Beneficio Proyecto Social</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">25/11/2013</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">2197</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">No aplica</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + item.Beneficiario.Nombre + "</td>";
                        file.WriteLine(lines);
                        lines = "</tr>";
                        file.WriteLine(lines);
                    }
                }
                //Cerrar tabla
                file.WriteLine("</table></div>");
                System.IO.StreamReader file2 = new System.IO.StreamReader("...\\...\\Script\\script.txt"); // Abrir el txt
                string linea;
                while ((linea = file2.ReadLine()) != null) file.WriteLine(linea);
                file.WriteLine();
                file.WriteLine("</div>");
                file.WriteLine("</div>");
                //Footer
                file.WriteLine("<? include (\"footer.php\"); ?>");
                //Cerrar archivo
                file.Close();
            }
            if (motivo == 9)
            {
                StreamWriter file = new StreamWriter("D:\\Pagina web\\Subsidios\\" + year.ToString() + "\\rebajaaseo" + year.ToString() + ".php"); // Abrir el txt
                // Cabeceras del html
                file.WriteLine("<? include (\"header.php\"); ?>");
                //Body del html
                file.WriteLine("<div class=\"row\">");
                file.WriteLine("<div class=\"col-sm-12\">");
                file.WriteLine(string.Format("<center><b>Beneficiarios de Rebaja de Aseo - {0}</b></center>", year));
                file.WriteLine("<style type=\"text/css\">");
                file.WriteLine(".tg  {border-collapse:collapse;border-spacing:0;border-color:#999;margin:0px auto;}");
                file.WriteLine(".tg td{font-family:Arial, sans-serif;font-size:10px;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:#999;color:#444;background-color:#F7FDFA;}");
                file.WriteLine(".tg th{font-family:Arial, sans-serif;font-size:10px;font-weight:normal;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:#999;color:#fff;background-color:#26ADE4;}");
                file.WriteLine(".tg .tg-yw4l{vertical-align:top}");
                file.WriteLine("th.tg-sort-header::-moz-selection { background:transparent; }th.tg-sort-header::selection      { background:transparent; }th.tg-sort-header { cursor:pointer; }table th.tg-sort-header:after {  content:'';  float:right;  margin-top:7px;  border-width:0 4px 4px;  border-style:solid;  border-color:#404040 transparent;  visibility:hidden;  }table th.tg-sort-header:hover:after {  visibility:visible;  }table th.tg-sort-desc:after,table th.tg-sort-asc:after,table th.tg-sort-asc:hover:after {  visibility:visible;  opacity:0.4;  }table th.tg-sort-desc:after {  border-bottom:none;  border-width:4px 4px 0;  }@media screen and (max-width: 767px) {.tg {width: auto !important;}.tg col {width: auto !important;}.tg-wrap {overflow-x: auto;-webkit-overflow-scrolling: touch;margin: auto 0px;}}</style>");
                //Crear tabla            
                file.WriteLine("<div class=\"tg-wrap\"><table id=\"tg-duF9v\" class=\"tg\">");
                //Cabecera de la tabla
                file.WriteLine("<tr>");
                file.WriteLine("<th class=\"tg-yw4l\">A&ntildeo</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Mes</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Nombre Programa</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Fecha otorgamiento</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Tipo Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Denominaci&oacuten Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Fecha Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Numero Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Raz&oacuten Social</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Nombre</th>");
                file.WriteLine("</tr>");
                foreach (Solicitudes item in listado)
                {
                    string mes = "";
                    switch (item.FechaAprobacionDirector.Value.Month)
                    {
                        case 1:
                            mes = "ENERO";
                            break;
                        case 2:
                            mes = "FEBRERO";
                            break;
                        case 3:
                            mes = "MARZO";
                            break;
                        case 4:
                            mes = "ABRIL";
                            break;
                        case 5:
                            mes = "MAYO";
                            break;
                        case 6:
                            mes = "JUNIO";
                            break;
                        case 7:
                            mes = "JULIO";
                            break;
                        case 8:
                            mes = "AGOSTO";
                            break;
                        case 9:
                            mes = "SEPTIEMBRE";
                            break;
                        case 10:
                            mes = "OCTUBRE";
                            break;
                        case 11:
                            mes = "NOVIEMBRE";
                            break;
                        case 12:
                            mes = "DICIEMBRE";
                            break;
                    }
                    string lines = "";
                    lines = "<tr>";
                    file.WriteLine(lines);
                    lines = "<td class=\"tg-yw41\">" + item.FechaAprobacionDirector.Value.Year + "</td>";
                    file.WriteLine(lines);
                    lines = "<td class=\"tg-yw41\">" + mes + "</td>";
                    file.WriteLine(lines);
                    lines = "<td class=\"tg-yw41\">REBAJA DE ASEO</td>";
                    file.WriteLine(lines);
                    lines = "<td class=\"tg-yw41\">" + item.FechaAprobacionDirector.Value + "</td>";
                    file.WriteLine(lines);
                    lines = "<td class=\"tg-yw41\">Decreto Alcaldicio</td>";
                    file.WriteLine(lines);
                    lines = "<td class=\"tg-yw41\">Otorga Beneficio Proyecto Social</td>";
                    file.WriteLine(lines);
                    lines = "<td class=\"tg-yw41\">25/11/2013</td>";
                    file.WriteLine(lines);
                    lines = "<td class=\"tg-yw41\">2197</td>";
                    file.WriteLine(lines);
                    lines = "<td class=\"tg-yw41\">No aplica</td>";
                    file.WriteLine(lines);
                    lines = "<td class=\"tg-yw41\">" + item.Beneficiario.Nombre + "</td>";
                    file.WriteLine(lines);
                    lines = "</tr>";
                    file.WriteLine(lines);
                }
                //Cerrar tabla
                file.WriteLine("</table></div>");
                System.IO.StreamReader file2 = new System.IO.StreamReader("...\\...\\Script\\script.txt"); // Abrir el txt
                string linea;
                while ((linea = file2.ReadLine()) != null) file.WriteLine(linea);
                file.WriteLine();
                file.WriteLine("</div>");
                file.WriteLine("</div>");
                //Footer
                file.WriteLine("<? include (\"footer.php\"); ?>");
                //Cerrar archivo
                file.Close();
            }
            if (motivo == 10)
            {
                StreamWriter file = new StreamWriter("D:\\Pagina web\\Subsidios\\" + year.ToString() + "\\entregaagua" + year.ToString() + ".php"); // Abrir el txt
                // Cabeceras del html
                file.WriteLine("<? include (\"header.php\"); ?>");
                //Body del html
                file.WriteLine("<div class=\"row\">");
                file.WriteLine("<div class=\"col-sm-12\">");
                file.WriteLine(string.Format("<center><b>Beneficiarios de Entrega de Agua - {0}</b></center>", year));
                file.WriteLine("<style type=\"text/css\">");
                file.WriteLine(".tg  {border-collapse:collapse;border-spacing:0;border-color:#999;margin:0px auto;}");
                file.WriteLine(".tg td{font-family:Arial, sans-serif;font-size:10px;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:#999;color:#444;background-color:#F7FDFA;}");
                file.WriteLine(".tg th{font-family:Arial, sans-serif;font-size:10px;font-weight:normal;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:#999;color:#fff;background-color:#26ADE4;}");
                file.WriteLine(".tg .tg-yw4l{vertical-align:top}");
                file.WriteLine("th.tg-sort-header::-moz-selection { background:transparent; }th.tg-sort-header::selection      { background:transparent; }th.tg-sort-header { cursor:pointer; }table th.tg-sort-header:after {  content:'';  float:right;  margin-top:7px;  border-width:0 4px 4px;  border-style:solid;  border-color:#404040 transparent;  visibility:hidden;  }table th.tg-sort-header:hover:after {  visibility:visible;  }table th.tg-sort-desc:after,table th.tg-sort-asc:after,table th.tg-sort-asc:hover:after {  visibility:visible;  opacity:0.4;  }table th.tg-sort-desc:after {  border-bottom:none;  border-width:4px 4px 0;  }@media screen and (max-width: 767px) {.tg {width: auto !important;}.tg col {width: auto !important;}.tg-wrap {overflow-x: auto;-webkit-overflow-scrolling: touch;margin: auto 0px;}}</style>");
                //Crear tabla            
                file.WriteLine("<div class=\"tg-wrap\"><table id=\"tg-duF9v\" class=\"tg\">");
                //Cabecera de la tabla
                file.WriteLine("<tr>");
                file.WriteLine("<th class=\"tg-yw4l\">A&ntildeo</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Mes</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Nombre Programa</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Fecha otorgamiento</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Tipo Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Denominaci&oacuten Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Fecha Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Numero Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Raz&oacuten Social</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Nombre</th>");
                file.WriteLine("</tr>");
                if (listado.Count == 0)
                {
                    string lines = "";
                    lines = "<tr><td colspan=\"10\">NO EXISTEN BENEFICIARIOS A LA FECHA </td></tr>";
                    file.WriteLine(lines);
                }
                else
                {
                    foreach (Solicitudes item in listado)
                    {
                        string mes = "";
                        switch (item.FechaAprobacionDirector.Value.Month)
                        {
                            case 1:
                                mes = "ENERO";
                                break;
                            case 2:
                                mes = "FEBRERO";
                                break;
                            case 3:
                                mes = "MARZO";
                                break;
                            case 4:
                                mes = "ABRIL";
                                break;
                            case 5:
                                mes = "MAYO";
                                break;
                            case 6:
                                mes = "JUNIO";
                                break;
                            case 7:
                                mes = "JULIO";
                                break;
                            case 8:
                                mes = "AGOSTO";
                                break;
                            case 9:
                                mes = "SEPTIEMBRE";
                                break;
                            case 10:
                                mes = "OCTUBRE";
                                break;
                            case 11:
                                mes = "NOVIEMBRE";
                                break;
                            case 12:
                                mes = "DICIEMBRE";
                                break;
                        }
                        string lines = "";
                        lines = "<tr>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + item.FechaAprobacionDirector.Value.Year + "</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + mes + "</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">ENTREGA DE AGUA</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + item.FechaAprobacionDirector.Value + "</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">Decreto Alcaldicio</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">Otorga Beneficio Proyecto Social</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">25/11/2013</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">2197</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">No aplica</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + item.Beneficiario.Nombre + "</td>";
                        file.WriteLine(lines);
                        lines = "</tr>";
                        file.WriteLine(lines);
                    }
                }
                //Cerrar tabla
                file.WriteLine("</table></div>");
                System.IO.StreamReader file2 = new System.IO.StreamReader("...\\...\\Script\\script.txt"); // Abrir el txt
                string linea;
                while ((linea = file2.ReadLine()) != null) file.WriteLine(linea);
                file.WriteLine();
                file.WriteLine("</div>");
                file.WriteLine("</div>");
                //Footer
                file.WriteLine("<? include (\"footer.php\"); ?>");
                //Cerrar archivo
                file.Close();
            }
            if (motivo == 11)
            {
                StreamWriter file = new StreamWriter("D:\\Pagina web\\Subsidios\\" + year.ToString() + "\\otros" + year.ToString() + ".php"); // Abrir el txt
                // Cabeceras del html
                file.WriteLine("<? include (\"header.php\"); ?>");
                //Body del html
                file.WriteLine("<div class=\"row\">");
                file.WriteLine("<div class=\"col-sm-12\">");
                file.WriteLine(string.Format("<center><b>Beneficiarios de Otros - {0}</b></center>", year));
                file.WriteLine("<style type=\"text/css\">");
                file.WriteLine(".tg  {border-collapse:collapse;border-spacing:0;border-color:#999;margin:0px auto;}");
                file.WriteLine(".tg td{font-family:Arial, sans-serif;font-size:10px;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:#999;color:#444;background-color:#F7FDFA;}");
                file.WriteLine(".tg th{font-family:Arial, sans-serif;font-size:10px;font-weight:normal;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:#999;color:#fff;background-color:#26ADE4;}");
                file.WriteLine(".tg .tg-yw4l{vertical-align:top}");
                file.WriteLine("th.tg-sort-header::-moz-selection { background:transparent; }th.tg-sort-header::selection      { background:transparent; }th.tg-sort-header { cursor:pointer; }table th.tg-sort-header:after {  content:'';  float:right;  margin-top:7px;  border-width:0 4px 4px;  border-style:solid;  border-color:#404040 transparent;  visibility:hidden;  }table th.tg-sort-header:hover:after {  visibility:visible;  }table th.tg-sort-desc:after,table th.tg-sort-asc:after,table th.tg-sort-asc:hover:after {  visibility:visible;  opacity:0.4;  }table th.tg-sort-desc:after {  border-bottom:none;  border-width:4px 4px 0;  }@media screen and (max-width: 767px) {.tg {width: auto !important;}.tg col {width: auto !important;}.tg-wrap {overflow-x: auto;-webkit-overflow-scrolling: touch;margin: auto 0px;}}</style>");
                //Crear tabla            
                file.WriteLine("<div class=\"tg-wrap\"><table id=\"tg-duF9v\" class=\"tg\">");
                //Cabecera de la tabla
                file.WriteLine("<tr>");
                file.WriteLine("<th class=\"tg-yw4l\">A&ntildeo</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Mes</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Nombre Programa</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Fecha otorgamiento</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Tipo Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Denominaci&oacuten Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Fecha Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Numero Acto</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Raz&oacuten Social</th>");
                file.WriteLine("<th class=\"tg-yw4l\">Nombre</th>");
                file.WriteLine("</tr>");
                if (listado.Count == 0)
                {
                    string lines = "";
                    lines = "<tr><td colspan=\"10\">NO EXISTEN BENEFICIARIOS A LA FECHA </td></tr>";
                    file.WriteLine(lines);
                }
                else
                {
                    foreach (Solicitudes item in listado)
                    {
                        string mes = "";
                        switch (item.FechaAprobacionDirector.Value.Month)
                        {
                            case 1:
                                mes = "ENERO";
                                break;
                            case 2:
                                mes = "FEBRERO";
                                break;
                            case 3:
                                mes = "MARZO";
                                break;
                            case 4:
                                mes = "ABRIL";
                                break;
                            case 5:
                                mes = "MAYO";
                                break;
                            case 6:
                                mes = "JUNIO";
                                break;
                            case 7:
                                mes = "JULIO";
                                break;
                            case 8:
                                mes = "AGOSTO";
                                break;
                            case 9:
                                mes = "SEPTIEMBRE";
                                break;
                            case 10:
                                mes = "OCTUBRE";
                                break;
                            case 11:
                                mes = "NOVIEMBRE";
                                break;
                            case 12:
                                mes = "DICIEMBRE";
                                break;
                        }
                        string lines = "";
                        lines = "<tr>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + item.FechaAprobacionDirector.Value.Year + "</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + mes + "</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">OTROS</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + item.FechaAprobacionDirector.Value + "</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">Decreto Alcaldicio</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">Otorga Beneficio Proyecto Social</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">25/11/2013</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">2197</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">No aplica</td>";
                        file.WriteLine(lines);
                        lines = "<td class=\"tg-yw41\">" + item.Beneficiario.Nombre + "</td>";
                        file.WriteLine(lines);
                        lines = "</tr>";
                        file.WriteLine(lines);
                    }
                }
                //Cerrar tabla
                file.WriteLine("</table></div>");
                System.IO.StreamReader file2 = new System.IO.StreamReader("...\\...\\Script\\script.txt"); // Abrir el txt
                string linea;
                while ((linea = file2.ReadLine()) != null) file.WriteLine(linea);
                file.WriteLine();
                file.WriteLine("</div>");
                file.WriteLine("</div>");
                //Footer
                file.WriteLine("<? include (\"footer.php\"); ?>");
                //Cerrar archivo
                file.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int motivo = Convert.ToInt32(CmbMotivo.SelectedValue);
            int year = Convert.ToInt32(CmbAnno.SelectedValue);
            List<Solicitudes> listado = (new EstadisticasBLL()).ObtenerTransparenciaMotivo(motivo, year);
            StreamWriter file = new StreamWriter("D:\\Pagina web\\Subsidios\\" + year.ToString() + "\\todospropios" + year.ToString() + ".php"); // Abrir el txt
            // Cabeceras del html
            file.WriteLine("<? include (\"header.php\"); ?>");
            //Body del html
            file.WriteLine("<div class=\"row\">");
            file.WriteLine("<div class=\"col-sm-12\">");
            file.WriteLine(string.Format("<center><b>Beneficiarios - {0}</b></center>", year));
            file.WriteLine("<style type=\"text/css\">");
            file.WriteLine(".tg  {border-collapse:collapse;border-spacing:0;border-color:#999;margin:0px auto;}");
            file.WriteLine(".tg td{font-family:Arial, sans-serif;font-size:10px;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:#999;color:#444;background-color:#F7FDFA;}");
            file.WriteLine(".tg th{font-family:Arial, sans-serif;font-size:10px;font-weight:normal;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:#999;color:#fff;background-color:#26ADE4;}");
            file.WriteLine(".tg .tg-yw4l{vertical-align:top}");
            file.WriteLine("th.tg-sort-header::-moz-selection { background:transparent; }th.tg-sort-header::selection      { background:transparent; }th.tg-sort-header { cursor:pointer; }table th.tg-sort-header:after {  content:'';  float:right;  margin-top:7px;  border-width:0 4px 4px;  border-style:solid;  border-color:#404040 transparent;  visibility:hidden;  }table th.tg-sort-header:hover:after {  visibility:visible;  }table th.tg-sort-desc:after,table th.tg-sort-asc:after,table th.tg-sort-asc:hover:after {  visibility:visible;  opacity:0.4;  }table th.tg-sort-desc:after {  border-bottom:none;  border-width:4px 4px 0;  }@media screen and (max-width: 767px) {.tg {width: auto !important;}.tg col {width: auto !important;}.tg-wrap {overflow-x: auto;-webkit-overflow-scrolling: touch;margin: auto 0px;}}</style>");
            //Crear tabla            
            file.WriteLine("<div class=\"tg-wrap\"><table id=\"tg-duF9v\" class=\"tg\">");
            //Cabecera de la tabla
            file.WriteLine("<tr>");
            file.WriteLine("<th class=\"tg-yw4l\">A&ntildeo</th>");
            file.WriteLine("<th class=\"tg-yw4l\">Mes</th>");
            file.WriteLine("<th class=\"tg-yw4l\">Nombre Programa</th>");
            file.WriteLine("<th class=\"tg-yw4l\">Fecha otorgamiento</th>");
            file.WriteLine("<th class=\"tg-yw4l\">Tipo Acto</th>");
            file.WriteLine("<th class=\"tg-yw4l\">Denominaci&oacuten Acto</th>");
            file.WriteLine("<th class=\"tg-yw4l\">Fecha Acto</th>");
            file.WriteLine("<th class=\"tg-yw4l\">Numero Acto</th>");
            file.WriteLine("<th class=\"tg-yw4l\">Raz&oacuten Social</th>");
            file.WriteLine("<th class=\"tg-yw4l\">Nombre</th>");
            file.WriteLine("</tr>");
            foreach (Solicitudes item in listado)
            {
                string mes = "";
                switch (item.FechaAprobacionDirector.Value.Month)
                {
                    case 1:
                        mes = "ENERO";
                        break;
                    case 2:
                        mes = "FEBRERO";
                        break;
                    case 3:
                        mes = "MARZO";
                        break;
                    case 4:
                        mes = "ABRIL";
                        break;
                    case 5:
                        mes = "MAYO";
                        break;
                    case 6:
                        mes = "JUNIO";
                        break;
                    case 7:
                        mes = "JULIO";
                        break;
                    case 8:
                        mes = "AGOSTO";
                        break;
                    case 9:
                        mes = "SEPTIEMBRE";
                        break;
                    case 10:
                        mes = "OCTUBRE";
                        break;
                    case 11:
                        mes = "NOVIEMBRE";
                        break;
                    case 12:
                        mes = "DICIEMBRE";
                        break;
                }

                List<string> motivos = new List<string>();
                if (item.Vivienda == true) motivos.Add("VIVIENDA");
                if (item.Alimentacion == true) motivos.Add("ALIMENTACION");
                if (item.Salud == true) motivos.Add("SALUD");
                if (item.Defunciones == true) motivos.Add("DEFUNCIONES");
                if (item.Microemprendimiento == true) motivos.Add("MICROEMPRENDIMIENTO");
                if (item.PSGubernamental == true) motivos.Add("PROGRAMA SOCIAL GUBERNAMENTAL");
                if (item.Maquinaria == true) motivos.Add("MAQUINARIA");
                if (item.PersonalMunicipal == true) motivos.Add("PERSONAL MUNICIPAL");
                if (item.RebajaAseo == true) motivos.Add("REBAJA DE ASEO");
                if (item.EntregaAgua == true) motivos.Add("ENTREGA DE AGUA");
                if (item.Otros == true) motivos.Add("OTROS");
                foreach (string item2 in motivos)
                {
                    string lines = "";
                    lines = "<tr>";
                    file.WriteLine(lines);
                    lines = "<td class=\"tg-yw41\">" + item.FechaAprobacionDirector.Value.Year + "</td>";
                    file.WriteLine(lines);
                    lines = "<td class=\"tg-yw41\">" + mes + "</td>";
                    file.WriteLine(lines);
                    lines = "<td class=\"tg-yw41\">" + item2.ToString() + "</td>";
                    file.WriteLine(lines);
                    lines = "<td class=\"tg-yw41\">" + item.FechaAprobacionDirector.Value + "</td>";
                    file.WriteLine(lines);
                    lines = "<td class=\"tg-yw41\">Decreto Alcaldicio</td>";
                    file.WriteLine(lines);
                    lines = "<td class=\"tg-yw41\">Otorga Beneficio Proyecto Social</td>";
                    file.WriteLine(lines);
                    lines = "<td class=\"tg-yw41\">25/11/2013</td>";
                    file.WriteLine(lines);
                    lines = "<td class=\"tg-yw41\">2197</td>";
                    file.WriteLine(lines);
                    lines = "<td class=\"tg-yw41\">No aplica</td>";
                    file.WriteLine(lines);
                    lines = "<td class=\"tg-yw41\">" + item.Beneficiario.Nombre + "</td>";
                    file.WriteLine(lines);
                    lines = "</tr>";
                    file.WriteLine(lines);
                }
            }
            //Cerrar tabla
            file.WriteLine("</table></div>");
            System.IO.StreamReader file2 = new System.IO.StreamReader("...\\...\\Script\\script.txt"); // Abrir el txt
            string linea;
            while ((linea = file2.ReadLine()) != null) file.WriteLine(linea);
            file.WriteLine();
            file.WriteLine("</div>");
            file.WriteLine("</div>");
            //Footer
            file.WriteLine("<? include (\"footer.php\"); ?>");
            //Cerrar archivo
            file.Close();
        }
    }
}
