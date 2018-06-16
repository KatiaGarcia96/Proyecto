using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using CenterSpace.NMath.Stats;
namespace SPC
{
	public partial class Supervisor : Gtk.Window
	{
        Gtk.Window Principal;
        private OracleDataAdapter da;
        private OracleCommandBuilder cb;
        private System.Data.DataSet ds;
        public Supervisor(Gtk.Window V) :
				base(Gtk.WindowType.Toplevel)
		{
            Principal = V;
			this.Build();
            Entradas_Table();
            Mod_Table();
            btn_Cnl.Clicked += new EventHandler(this.btnCnl_Click);



		}
        public void btnCnl_Click(object sender, EventArgs e)
        {
            Principal.Show();
            //Cerrar ventana

            this.Hide();
        }

        public void Entradas_Table()
        {

            // ID, Nombre, Apellido, Puesto, Turno
            Gtk.TreeViewColumn ID = new Gtk.TreeViewColumn(); ID.Title = "ID";
            Gtk.TreeViewColumn Nombre = new Gtk.TreeViewColumn(); Nombre.Title = "Material";
            Gtk.TreeViewColumn Apellido = new Gtk.TreeViewColumn(); Apellido.Title = "Maquina";
            Gtk.TreeViewColumn Apellido1 = new Gtk.TreeViewColumn(); Apellido1.Title = "Instrumento de medicion";
            Gtk.TreeViewColumn Apellido2 = new Gtk.TreeViewColumn(); Apellido2.Title = "Usuario";
            Gtk.TreeViewColumn Apellido3 = new Gtk.TreeViewColumn(); Apellido3.Title = "Cpk";
            Gtk.TreeViewColumn Apellido4 = new Gtk.TreeViewColumn(); Apellido4.Title = "Fecha";
            tree_ent.AppendColumn(ID); tree_ent.AppendColumn(Nombre); tree_ent.AppendColumn(Apellido);
            tree_ent.AppendColumn(Apellido1); tree_ent.AppendColumn(Apellido2); tree_ent.AppendColumn(Apellido3);
            tree_ent.AppendColumn(Apellido4);

            Gtk.ListStore ListaUsuario = new Gtk.ListStore(typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string));


            tree_ent.Model = ListaUsuario;

            try
            {
                const string connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=spcprojectdb.cxmd6kjxslqw.us-west-1.rds.amazonaws.com)(PORT=1521)) (CONNECT_DATA=(SERVICE_NAME=ORCL))); User Id=kyann;Password=Gakd0132;";
                OracleConnection connection = new OracleConnection(connectionString);
                OracleCommand cmd;

                connection.Open();

                string sql = "select TO_CHAR(ENTRADA_ID), TO_CHAR(MATERIAL_ID), TO_CHAR(MAQUINA_ID), TO_CHAR(MEDICION_ID), TO_CHAR(USUARIO_ID), DATOS, TO_CHAR(FECHA) from ENTRADAS";
                cmd = new OracleCommand(sql, connection);
                cmd.CommandType = System.Data.CommandType.Text;

                da = new OracleDataAdapter(cmd);
                cb = new OracleCommandBuilder(da);
                ds = new System.Data.DataSet();

                da.Fill(ds);
                DataTable de = ds.Tables[0];


                foreach (DataRow row in de.Rows)
                {
                    ListaUsuario.AppendValues(row[0],row[1],row[2],row[3],row[4],row[5],row[6]);
                }

            }
            catch (OracleException)
            {
                SPC.Error_Ventana Ventana_Error = new SPC.Error_Ventana("ErrorCon");
            }

            Gtk.CellRendererText IDCell = new Gtk.CellRendererText();
            ID.PackStart(IDCell, true);
            Gtk.CellRendererText NombreCell = new Gtk.CellRendererText();
            Nombre.PackStart(NombreCell, true);
            Gtk.CellRendererText ApellidoCell = new Gtk.CellRendererText();
            Apellido.PackStart(ApellidoCell, true);
            Gtk.CellRendererText ApellidoCell1 = new Gtk.CellRendererText();
            Apellido1.PackStart(ApellidoCell1, true);
            Gtk.CellRendererText ApellidoCell2 = new Gtk.CellRendererText();
            Apellido2.PackStart(ApellidoCell2, true);
            Gtk.CellRendererText ApellidoCell3 = new Gtk.CellRendererText();
            Apellido3.PackStart(ApellidoCell3, true);
            Gtk.CellRendererText ApellidoCell4 = new Gtk.CellRendererText();
            Apellido4.PackStart(ApellidoCell4, true);


            ID.AddAttribute(IDCell, "text", 0);
            Nombre.AddAttribute(NombreCell, "text", 1);
            Apellido.AddAttribute(ApellidoCell, "text", 2);
            Apellido1.AddAttribute(ApellidoCell1, "text", 3);
            Apellido2.AddAttribute(ApellidoCell2, "text", 4);
            Apellido3.AddAttribute(ApellidoCell3, "text", 5);
            Apellido4.AddAttribute(ApellidoCell4, "text", 6);



            this.ShowAll();
        }

        public void Mod_Table()
        {


            // ID, Nombre, Apellido, Puesto, Turno
            Gtk.TreeViewColumn ID = new Gtk.TreeViewColumn(); ID.Title = "ID";
            Gtk.TreeViewColumn Nombre = new Gtk.TreeViewColumn(); Nombre.Title = "Problema";
            Gtk.TreeViewColumn Apellido = new Gtk.TreeViewColumn(); Apellido.Title = "Actividad";
            Gtk.TreeViewColumn Apellido2 = new Gtk.TreeViewColumn(); Apellido2.Title = "Usuario";
            Gtk.TreeViewColumn Apellido3 = new Gtk.TreeViewColumn(); Apellido3.Title = "Estado";
            tree_mod.AppendColumn(ID); tree_mod.AppendColumn(Nombre); tree_mod.AppendColumn(Apellido);
            tree_mod.AppendColumn(Apellido2); tree_mod.AppendColumn(Apellido3);


            Gtk.ListStore ListaUsuario = new Gtk.ListStore(typeof(string), typeof(string), typeof(string), typeof(string), typeof(string));


            tree_mod.Model = ListaUsuario;

            try
            {
                const string connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=spcprojectdb.cxmd6kjxslqw.us-west-1.rds.amazonaws.com)(PORT=1521)) (CONNECT_DATA=(SERVICE_NAME=ORCL))); User Id=kyann;Password=Gakd0132;";
                OracleConnection connection = new OracleConnection(connectionString);
                OracleCommand cmd;

                connection.Open();

                //Console.Write(notebook4.SelectPage);
                string sql = "select TO_CHAR(MODIFICACION_ID), DESCRIPCION_PROBLEMA, DESCRIPCION_ACTIVIDAD, TO_CHAR(USUARIO_ID), STATE from MODIFICACION";
                cmd = new OracleCommand(sql, connection);
                cmd.CommandType = System.Data.CommandType.Text;

                da = new OracleDataAdapter(cmd);
                cb = new OracleCommandBuilder(da);
                ds = new System.Data.DataSet();

                da.Fill(ds);
                DataTable de = ds.Tables[0];


                foreach (DataRow row in de.Rows)
                {
                    ListaUsuario.AppendValues(row[0], row[1], row[2], row[3],row[4]);
                }

            }
            catch (OracleException)
            {
                // SPC.Error_Ventana Ventana_Error = new SPC.Error_Ventana("ErrorCon");
            }

            Gtk.CellRendererText IDCell = new Gtk.CellRendererText();
            ID.PackStart(IDCell, true);
            Gtk.CellRendererText NombreCell = new Gtk.CellRendererText();
            Nombre.PackStart(NombreCell, true);
            Gtk.CellRendererText ApellidoCell = new Gtk.CellRendererText();
            Apellido.PackStart(ApellidoCell, true);
            Gtk.CellRendererText ApellidoCell2 = new Gtk.CellRendererText();
            Apellido2.PackStart(ApellidoCell2, true);
            Gtk.CellRendererText ApellidoCell3 = new Gtk.CellRendererText();
            Apellido3.PackStart(ApellidoCell3, true);



            ID.AddAttribute(IDCell, "text", 0);
            Nombre.AddAttribute(NombreCell, "text", 1);
            Apellido.AddAttribute(ApellidoCell, "text", 2);
            Apellido2.AddAttribute(ApellidoCell2, "text", 3);
            Apellido3.AddAttribute(ApellidoCell3, "text", 4);



            this.ShowAll();
        }
	}
}
