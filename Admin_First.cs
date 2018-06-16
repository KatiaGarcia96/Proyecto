using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Xamarin.Forms;
using Xamarin.Forms.Platform.GTK;


namespace SPC
{
    public partial class Admin_First : Gtk.Window
    {

        private OracleDataAdapter da;
        private OracleCommandBuilder cb;
        private System.Data.DataSet ds;

        Gtk.Window Principal;
        public Admin_First(Gtk.Window V) :
                base(Gtk.WindowType.Toplevel)
        {
            Principal = V;
            this.Build();

             combobox1.AppendText("Todos");
             combobox1.AppendText("ID");
             combobox1.AppendText("Nombre");
             combobox1.AppendText("Apellido");
             combobox1.AppendText("Puesto");
             combobox1.AppendText("Turno");


            user_Table("");
            Material_Table("");
            Maquina_Table("");
            Medicion_Table("");
            Entradas_Table("");
            Mod_Table("");

            notebook4.FocusInEvent += this.Change_Tab;

            btn_Add.Clicked += new EventHandler(this.btnAdd_Click);
            btn_Modificar.Clicked += new EventHandler(this.btnModificar_Click);
            btn_Eliminar.Clicked += new EventHandler(this.btnDelete_Click);
            btn_Ref.Clicked += new EventHandler(this.btnRef_Click);
            btn_Buscar.Clicked += new EventHandler(this.btnBuscar_Click);
            //ds.Tables[0];

        }
        public void btnBuscar_Click(object sender, EventArgs e)
        {
            Gtk.ListStore ListaUsuario = new Gtk.ListStore(typeof(string), typeof(string), typeof(string), typeof(string), typeof(string));

            tree_U.Model = ListaUsuario;

            if (notebook4.Page == 0)
            {
                string where = "";
                if (combobox1.Active.Equals(1)) { where = "ID_SYS"; }
                else if(combobox1.Active.Equals(2)){where = "NOMBRE";}
                else if (combobox1.Active.Equals(3)) {where = "APELLIDO"; }
                else if (combobox1.Active.Equals(4)) { where = "PUESTO";}
                else if (combobox1.Active.Equals(4)) { where = "TURNO"; }
                else {}
                Console.Write(combobox1.Active);

                string sql = "SELECT ID_SYS, NOMBRE, APELLIDO, PUESTO, TURNO FROM USUARIO WHERE "+where + " LIKE '%" + entry1.Text+"%'";
                Console.Write(sql);
                user_Table(sql);
                
            }
            else if (notebook4.Page == 1)
            { 
                string where = "";
                if (combobox1.Active.Equals(1)) { where = "ID_SYS"; }
                else if (combobox1.Active.Equals(2)) { where = "NOMBRE"; }
                else if (combobox1.Active.Equals(3)) { where = "APELLIDO"; }
                else if (combobox1.Active.Equals(4)) { where = "PUESTO"; }
                else if (combobox1.Active.Equals(4)) { where = "TURNO"; }
                else { }
                Console.Write(combobox1.Active);

                string sql = "SELECT ID_SYS, NOMBRE, APELLIDO, PUESTO, TURNO FROM USUARIO WHERE " + where + " LIKE '%" + entry1.Text + "%'";
                Console.Write(sql);
                user_Table(sql);
            }
            else if (notebook4.Page == 2)
            { 
                string where = "";
                if (combobox1.Active.Equals(1)) { where = "ID_SYS"; }
                else if (combobox1.Active.Equals(2)) { where = "NOMBRE"; }
                else if (combobox1.Active.Equals(3)) { where = "APELLIDO"; }
                else if (combobox1.Active.Equals(4)) { where = "PUESTO"; }
                else if (combobox1.Active.Equals(4)) { where = "TURNO"; }
                else { }
                Console.Write(combobox1.Active);

                string sql = "SELECT ID_SYS, NOMBRE, APELLIDO, PUESTO, TURNO FROM USUARIO WHERE " + where + " LIKE '%" + entry1.Text + "%'";
                Console.Write(sql);
                user_Table(sql);
            }
            else if (notebook4.Page == 3)
            { 
                string where = "";
                if (combobox1.Active.Equals(1)) { where = "ID_SYS"; }
                else if (combobox1.Active.Equals(2)) { where = "NOMBRE"; }
                else if (combobox1.Active.Equals(3)) { where = "APELLIDO"; }
                else if (combobox1.Active.Equals(4)) { where = "PUESTO"; }
                else if (combobox1.Active.Equals(4)) { where = "TURNO"; }
                else { }
                Console.Write(combobox1.Active);

                string sql = "SELECT ID_SYS, NOMBRE, APELLIDO, PUESTO, TURNO FROM USUARIO WHERE " + where + " LIKE '%" + entry1.Text + "%'";
                Console.Write(sql);
                user_Table(sql);
            }
            else if (notebook4.Page == 4)
            { 
                string where = "";
                if (combobox1.Active.Equals(1)) { where = "ID_SYS"; }
                else if (combobox1.Active.Equals(2)) { where = "NOMBRE"; }
                else if (combobox1.Active.Equals(3)) { where = "APELLIDO"; }
                else if (combobox1.Active.Equals(4)) { where = "PUESTO"; }
                else if (combobox1.Active.Equals(4)) { where = "TURNO"; }
                else { }
                Console.Write(combobox1.Active);

                string sql = "SELECT ID_SYS, NOMBRE, APELLIDO, PUESTO, TURNO FROM USUARIO WHERE " + where + " LIKE '%" + entry1.Text + "%'";
                Console.Write(sql);
                user_Table(sql);
            }
            else if (notebook4.Page == 5)
            { 
                string where = "";
                if (combobox1.Active.Equals(1)) { where = "ID_SYS"; }
                else if (combobox1.Active.Equals(2)) { where = "NOMBRE"; }
                else if (combobox1.Active.Equals(3)) { where = "APELLIDO"; }
                else if (combobox1.Active.Equals(4)) { where = "PUESTO"; }
                else if (combobox1.Active.Equals(4)) { where = "TURNO"; }
                else { }
                Console.Write(combobox1.Active);

                string sql = "SELECT ID_SYS, NOMBRE, APELLIDO, PUESTO, TURNO FROM USUARIO WHERE " + where + " LIKE '%" + entry1.Text + "%'";
                Console.Write(sql);
                user_Table(sql);
            }
            this.ShowAll();
            
        }
        public void Change_Tab (object sender, EventArgs e){
            
            combobox1.RemoveText(0);
            combobox1.RemoveText(0);
            combobox1.RemoveText(0);
            combobox1.RemoveText(0);
            combobox1.RemoveText(0);
            combobox1.RemoveText(0);
            combobox1.RemoveText(0);

            if (notebook4.Page == 0)
            {
                 combobox1.AppendText("Todos");
                 combobox1.AppendText("ID");
                 combobox1.AppendText("Nombre");
                 combobox1.AppendText("Apellido");
                 combobox1.AppendText("Puesto");
                combobox1.AppendText("Turno");
 
            }
            else if (notebook4.Page == 1)
            {
                combobox1.AppendText("Todos");
                combobox1.AppendText("ID");
                combobox1.AppendText("Descripción");
                combobox1.AppendText("Dimensión");
            }
            else if (notebook4.Page == 2)
            { 
                combobox1.AppendText("Todos");
                combobox1.AppendText("ID");
                combobox1.AppendText("Descripción");
                combobox1.AppendText("Estado");
            }
            else if (notebook4.Page == 3)
            { 
                combobox1.AppendText("Todos");
                combobox1.AppendText("ID");
                combobox1.AppendText("Descripción");
                combobox1.AppendText("Estado");
            }
            else if (notebook4.Page == 4)
            {
                combobox1.AppendText("Todos");
                combobox1.AppendText("ID Usuario");
                combobox1.AppendText("ID Material");
                combobox1.AppendText("ID Instrumento de Medición");
                combobox1.AppendText("ID Maquina");
                combobox1.AppendText("CPK");
                combobox1.AppendText("Fecha");
            }
            else if (notebook4.Page == 5)
            { 
                combobox1.AppendText("Todos");
                combobox1.AppendText("ID");
                combobox1.AppendText("Problema");
                combobox1.AppendText("Actividad");
                combobox1.AppendText("Usuario responsable");
                combobox1.AppendText("Estado");
            }
        }
        public void btnModificar_Click(object sender, EventArgs e)
        {
            Gtk.TreeIter selected;
            tree_U.Selection.GetSelected(out selected);
            SPC.Add_User ventana_add = new SPC.Add_User(tree_U.Model.GetValue(selected, 0).ToString(),this);
            ventana_add.Show();
        }

        public void btnRef_Click(object sender, EventArgs e)
        {
            Refresh();

        }
        public void Refresh(){
            Gtk.ListStore ListaUsuario = new Gtk.ListStore(typeof(string), typeof(string), typeof(string), typeof(string), typeof(string));

            tree_U.Model = ListaUsuario; user_Table("");
            tree_Maq.Model = ListaUsuario; Maquina_Table("");
            tree_Med.Model = ListaUsuario; Medicion_Table("");
            tree_mod.Model = ListaUsuario; Mod_Table("");
            tree_ent.Model = ListaUsuario; Entradas_Table("");
            Mat_Tree.Model = ListaUsuario; Material_Table("");
        }
        public void btnAdd_Click(object sender, EventArgs e)
        {
            if(notebook4.Page ==0){
                SPC.Add_User ventana_add = new SPC.Add_User("", this);
                ventana_add.Show();
            }else if (notebook4.Page == 1)
            {
                SPC.Add_Materiales ventana_add = new SPC.Add_Materiales();
                ventana_add.Show();
            }
            else if (notebook4.Page == 2)
            {
                SPC.Add_Maquina ventana_add = new SPC.Add_Maquina("Maquina");
                ventana_add.Show();
            }else if (notebook4.Page == 3)
            {
                SPC.Add_Maquina ventana_add = new SPC.Add_Maquina("Medicion");
                ventana_add.Show();
            }else if (notebook4.Page == 4)
            {
                SPC.Error_Ventana Ventana_Error = new SPC.Error_Ventana("NoDisponible");
            }
            else if (notebook4.Page == 5)
            {
                SPC.Error_Ventana Ventana_Error = new SPC.Error_Ventana("NoDisponible");
            }
        }

        public void btnDelete_Click(object sender, EventArgs e)
        {



            try
            {
                
                Gtk.TreeIter selected;

                var Data="";

                const string connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=spcprojectdb.cxmd6kjxslqw.us-west-1.rds.amazonaws.com)(PORT=1521)) (CONNECT_DATA=(SERVICE_NAME=ORCL))); User Id=kyann;Password=Gakd0132;";
                var connection = new OracleConnection(connectionString);

                //Asignar a una variable que sea un commando
                var commando="";
                if (notebook4.Page == 0)
                {
                    commando = "ELIMINAR_USUARIO";
                    tree_U.Selection.GetSelected(out selected);
                    Data = tree_U.Model.GetValue(selected, 0).ToString();

                }
                else if (notebook4.Page == 1)
                {
                    commando ="ELIMINAR_MATERIAL";
                    Mat_Tree.Selection.GetSelected(out selected);
                    Data = Mat_Tree.Model.GetValue(selected, 0).ToString();
                }
                else if (notebook4.Page == 2)
                {
                    commando ="ELIMINAR_MAQUINA";
                    tree_Maq.Selection.GetSelected(out selected);
                    Data = tree_Maq.Model.GetValue(selected, 0).ToString();
                }
                else if (notebook4.Page == 3)
                {
                    commando ="ELIMINAR_MEDICION";
                    tree_Med.Selection.GetSelected(out selected);
                    Data = tree_Med.Model.GetValue(selected, 0).ToString();
                }
                else if (notebook4.Page == 4)
                {
                    commando ="ELIMINAR_ENTRADA";
                    tree_ent.Selection.GetSelected(out selected);
                    Data = tree_ent.Model.GetValue(selected, 0).ToString();
                }
                else if (notebook4.Page == 5)
                {
                    SPC.Error_Ventana Ventana_Error = new SPC.Error_Ventana("NoDisponible");
                }


                OracleCommand user = new OracleCommand(commando);
                //Al comando agregarle la conexion con la base de datos
                user.Connection = connection;
                //Declarar que es un Procedure guardado
                user.CommandType = System.Data.CommandType.StoredProcedure;

                //Declarar cuales son los parametros y si son entradas o salidas
                user.Parameters.Add("ID_U", OracleDbType.Varchar2).Direction = System.Data.ParameterDirection.Input;

                //Declarar los valores
                user.Parameters["ID_U"].Value = Data;


                var r =notebook4.Page;
                Console.Write(r);                   

                connection.Open();
                //Ejecutar
                user.ExecuteScalar();
            }catch(OracleException){
                SPC.Error_Ventana Ventana_Error = new SPC.Error_Ventana("ErrorCon");

            }
            Refresh();
        }


        public void user_Table(string sql_c){
            tree_U.RemoveColumn(tree_U.GetColumn(0));
            tree_U.RemoveColumn(tree_U.GetColumn(0));
            tree_U.RemoveColumn(tree_U.GetColumn(0));
            tree_U.RemoveColumn(tree_U.GetColumn(0));
            tree_U.RemoveColumn(tree_U.GetColumn(0));

            // ID, Nombre, Apellido, Puesto, Turno
            Gtk.TreeViewColumn ID = new Gtk.TreeViewColumn(); ID.Title = "ID";
            Gtk.TreeViewColumn Nombre = new Gtk.TreeViewColumn(); Nombre.Title = "Nombre";
            Gtk.TreeViewColumn Apellido = new Gtk.TreeViewColumn(); Apellido.Title = "Apellido";
            Gtk.TreeViewColumn Puesto = new Gtk.TreeViewColumn(); Puesto.Title = "Puesto";
            Gtk.TreeViewColumn Turno = new Gtk.TreeViewColumn(); Turno.Title = "Turno";
            tree_U.AppendColumn(ID); tree_U.AppendColumn(Nombre); tree_U.AppendColumn(Apellido); tree_U.AppendColumn(Puesto); tree_U.AppendColumn(Turno);


            Gtk.ListStore ListaUsuario = new Gtk.ListStore(typeof(string), typeof(string), typeof(string), typeof(string), typeof(string));


            tree_U.Model = ListaUsuario;

            try
            {
                const string connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=spcprojectdb.cxmd6kjxslqw.us-west-1.rds.amazonaws.com)(PORT=1521)) (CONNECT_DATA=(SERVICE_NAME=ORCL))); User Id=kyann;Password=Gakd0132;";
                OracleConnection connection = new OracleConnection(connectionString);
                OracleCommand cmd;

                connection.Open();
                btn_Regresar.Clicked += new EventHandler(this.btnCancelar_Click);

                //Console.Write(notebook4.SelectPage);
                string sql = "";
                if (sql_c == "")
                {
                    sql = "select ID_SYS, NOMBRE, APELLIDO, PUESTO, TURNO from usuario";
                }else{
                    sql = sql_c;
                }
                    cmd = new OracleCommand(sql, connection);
                cmd.CommandType = System.Data.CommandType.Text;

                da = new OracleDataAdapter(cmd);
                cb = new OracleCommandBuilder(da);
                ds = new System.Data.DataSet();

                da.Fill(ds);
                DataTable de = ds.Tables[0];


                foreach (DataRow row in de.Rows)
                {
                    ListaUsuario.AppendValues(row[0], row[1], row[2], row[3], row[4]);
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
            Gtk.CellRendererText PuestoCell = new Gtk.CellRendererText();
            Puesto.PackStart(PuestoCell, true);
            Gtk.CellRendererText TurnoCell = new Gtk.CellRendererText();
            Turno.PackStart(TurnoCell, true);

            ID.AddAttribute(IDCell, "text", 0);
            Nombre.AddAttribute(NombreCell, "text", 1);
            Apellido.AddAttribute(ApellidoCell, "text", 2);
            Puesto.AddAttribute(PuestoCell, "text", 3);
            Turno.AddAttribute(TurnoCell, "text", 4);



            this.ShowAll();

        }

        //----------------------------------------------------------
        //----------------------------------------------------------
        //----------------------------------------------------------

        public void Material_Table(string sql_c)
        {
            Mat_Tree.RemoveColumn(Mat_Tree.GetColumn(0));
            Mat_Tree.RemoveColumn(Mat_Tree.GetColumn(0));
            Mat_Tree.RemoveColumn(Mat_Tree.GetColumn(0));

            // ID, Nombre, Apellido, Puesto, Turno
            Gtk.TreeViewColumn ID = new Gtk.TreeViewColumn(); ID.Title = "Material";
            Gtk.TreeViewColumn Nombre = new Gtk.TreeViewColumn(); Nombre.Title = "Descripcion";
            Gtk.TreeViewColumn Apellido = new Gtk.TreeViewColumn(); Apellido.Title = "Dimension";
            Mat_Tree.AppendColumn(ID); Mat_Tree.AppendColumn(Nombre); Mat_Tree.AppendColumn(Apellido); 

            Gtk.ListStore ListaUsuario = new Gtk.ListStore(typeof(string), typeof(string), typeof(string)); ///modificacion ultimo de float a string


            Mat_Tree.Model = ListaUsuario;

            try
            {
                const string connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=spcprojectdb.cxmd6kjxslqw.us-west-1.rds.amazonaws.com)(PORT=1521)) (CONNECT_DATA=(SERVICE_NAME=ORCL))); User Id=kyann;Password=Gakd0132;";
                OracleConnection connection = new OracleConnection(connectionString);
                OracleCommand cmd;

                connection.Open();

                //Console.Write(notebook4.SelectPage);
                string sql = "select MATERIAL, DESCRIPCION_MATERIAL, TO_CHAR(DIMENSION) from MATERIALES";
                cmd = new OracleCommand(sql, connection);
                cmd.CommandType = System.Data.CommandType.Text;

                da = new OracleDataAdapter(cmd);
                cb = new OracleCommandBuilder(da);
                ds = new System.Data.DataSet();

                da.Fill(ds);
                DataTable de = ds.Tables[0];


                foreach (DataRow row in de.Rows)
                {
                    ListaUsuario.AppendValues(row[0], row[1], row[2]);
                }

            }
            catch (OracleException)
            {
                //SPC.Error_Ventana Ventana_Error = new SPC.Error_Ventana("ErrorCon");
            }

            Gtk.CellRendererText IDCell = new Gtk.CellRendererText();
            ID.PackStart(IDCell, true);
            Gtk.CellRendererText NombreCell = new Gtk.CellRendererText();
            Nombre.PackStart(NombreCell, true);
            Gtk.CellRendererText ApellidoCell = new Gtk.CellRendererText();
            Apellido.PackStart(ApellidoCell, true);


            ID.AddAttribute(IDCell, "text", 0);
            Nombre.AddAttribute(NombreCell, "text", 1);
            Apellido.AddAttribute(ApellidoCell, "text", 2);



            this.ShowAll();
        }

        //------------------------------------------------------------
//-----------------------------------------------
        //---------------------------------------------------------------------

        public void Maquina_Table(string sql_c)
        {
            tree_Maq.RemoveColumn(tree_Maq.GetColumn(0));
            tree_Maq.RemoveColumn(tree_Maq.GetColumn(0));
            tree_Maq.RemoveColumn(tree_Maq.GetColumn(0));

            // ID, Nombre, Apellido, Puesto, Turno
            Gtk.TreeViewColumn ID = new Gtk.TreeViewColumn(); ID.Title = "Maquina";
            Gtk.TreeViewColumn Nombre = new Gtk.TreeViewColumn(); Nombre.Title = "Descripcion";
            Gtk.TreeViewColumn Apellido = new Gtk.TreeViewColumn(); Apellido.Title = "Estado";
            tree_Maq.AppendColumn(ID); tree_Maq.AppendColumn(Nombre); tree_Maq.AppendColumn(Apellido);

            Gtk.ListStore ListaUsuario = new Gtk.ListStore(typeof(string), typeof(string), typeof(string));


            tree_Maq.Model = ListaUsuario;

            try
            {
                const string connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=spcprojectdb.cxmd6kjxslqw.us-west-1.rds.amazonaws.com)(PORT=1521)) (CONNECT_DATA=(SERVICE_NAME=ORCL))); User Id=kyann;Password=Gakd0132;";
                OracleConnection connection = new OracleConnection(connectionString);
                OracleCommand cmd;

                connection.Open();

                //Console.Write(notebook4.SelectPage);
                string sql = "select TO_CHAR(MAQUINA_ID), DESCRIPCION_MAQUINA, TO_CHAR(STATUS_MAQUINA) from MAQUINA";
                cmd = new OracleCommand(sql, connection);
                cmd.CommandType = System.Data.CommandType.Text;

                da = new OracleDataAdapter(cmd);
                cb = new OracleCommandBuilder(da);
                ds = new System.Data.DataSet();

                da.Fill(ds);
                DataTable de = ds.Tables[0];


                foreach (DataRow row in de.Rows)
                {
                    ListaUsuario.AppendValues(row[0], row[1], row[2]);
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


            ID.AddAttribute(IDCell, "text", 0);
            Nombre.AddAttribute(NombreCell, "text", 1);
            Apellido.AddAttribute(ApellidoCell, "text", 2);



            this.ShowAll();
        }

        //------------------------------------------------------------
              //-----------------------------------------------
        //---------------------------------------------------------------------


        public void Medicion_Table(string sql_c)
        {
            tree_Med.RemoveColumn(tree_Med.GetColumn(0));
            tree_Med.RemoveColumn(tree_Med.GetColumn(0));
            tree_Med.RemoveColumn(tree_Med.GetColumn(0));

            // ID, Nombre, Apellido, Puesto, Turno
            Gtk.TreeViewColumn ID = new Gtk.TreeViewColumn(); ID.Title = "Intrumento de Medicion";
            Gtk.TreeViewColumn Nombre = new Gtk.TreeViewColumn(); Nombre.Title = "Descripcion";
            Gtk.TreeViewColumn Apellido = new Gtk.TreeViewColumn(); Apellido.Title = "Estado";
            tree_Med.AppendColumn(ID); tree_Med.AppendColumn(Nombre); tree_Med.AppendColumn(Apellido);

            Gtk.ListStore ListaUsuario = new Gtk.ListStore(typeof(string), typeof(string), typeof(string));


            tree_Med.Model = ListaUsuario;

            try
            {
                const string connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=spcprojectdb.cxmd6kjxslqw.us-west-1.rds.amazonaws.com)(PORT=1521)) (CONNECT_DATA=(SERVICE_NAME=ORCL))); User Id=kyann;Password=Gakd0132;";
                OracleConnection connection = new OracleConnection(connectionString);
                OracleCommand cmd;

                connection.Open();
               
                //Console.Write(notebook4.SelectPage);
                string sql = "select TO_CHAR(MEDICION_ID), DESCRIPCION_MEDICION, TO_CHAR(STATUS_MEDICION) from MEDICION";
                cmd = new OracleCommand(sql, connection);
                cmd.CommandType = System.Data.CommandType.Text;

                da = new OracleDataAdapter(cmd);
                cb = new OracleCommandBuilder(da);
                ds = new System.Data.DataSet();

                da.Fill(ds);
                DataTable de = ds.Tables[0];


                foreach (DataRow row in de.Rows)
                {
                    ListaUsuario.AppendValues(row[0], row[1], row[2]);
                }

            }
            catch (OracleException)
            {
             //   SPC.Error_Ventana Ventana_Error = new SPC.Error_Ventana("ErrorCon");
            }

            Gtk.CellRendererText IDCell = new Gtk.CellRendererText();
            ID.PackStart(IDCell, true);
            Gtk.CellRendererText NombreCell = new Gtk.CellRendererText();
            Nombre.PackStart(NombreCell, true);
            Gtk.CellRendererText ApellidoCell = new Gtk.CellRendererText();
            Apellido.PackStart(ApellidoCell, true);


            ID.AddAttribute(IDCell, "text", 0);
            Nombre.AddAttribute(NombreCell, "text", 1);
            Apellido.AddAttribute(ApellidoCell, "text", 2);



            this.ShowAll();
        }

        public void Entradas_Table(string sql_c)
        {
            tree_ent.RemoveColumn(tree_ent.GetColumn(0));
            tree_ent.RemoveColumn(tree_ent.GetColumn(0));
            tree_ent.RemoveColumn(tree_ent.GetColumn(0));
            tree_ent.RemoveColumn(tree_ent.GetColumn(0));
            tree_ent.RemoveColumn(tree_ent.GetColumn(0));
            tree_ent.RemoveColumn(tree_ent.GetColumn(0));
            tree_ent.RemoveColumn(tree_ent.GetColumn(0));

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
                    ListaUsuario.AppendValues(row[0], row[1], row[2], row[3], row[4], row[5], row[6]);
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

        public void Mod_Table(string sql_c)
        {
            tree_mod.RemoveColumn(tree_mod.GetColumn(0));
            tree_mod.RemoveColumn(tree_mod.GetColumn(0));
            tree_mod.RemoveColumn(tree_mod.GetColumn(0));
            tree_mod.RemoveColumn(tree_mod.GetColumn(0));
            tree_mod.RemoveColumn(tree_mod.GetColumn(0));

            // ID, Nombre, Apellido, Puesto, Turno
            Gtk.TreeViewColumn ID = new Gtk.TreeViewColumn(); ID.Title = "ID";
            Gtk.TreeViewColumn Nombre = new Gtk.TreeViewColumn(); Nombre.Title = "Problema";
            Gtk.TreeViewColumn Apellido = new Gtk.TreeViewColumn(); Apellido.Title = "Actividad";
            Gtk.TreeViewColumn Apellido2 = new Gtk.TreeViewColumn(); Apellido2.Title = "Usuario";
            Gtk.TreeViewColumn Apellido3 = new Gtk.TreeViewColumn(); Apellido3.Title = "Estado";
            tree_mod.AppendColumn(ID); tree_mod.AppendColumn(Nombre); tree_mod.AppendColumn(Apellido);
            tree_mod.AppendColumn(Apellido2); tree_mod.AppendColumn(Apellido3);


            Gtk.ListStore ListaUsuario = new Gtk.ListStore(typeof(string), typeof(string), typeof(string),typeof(string),typeof(string));


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
                    ListaUsuario.AppendValues(row[0], row[1], row[2], row[3], row[4]);
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
        public void btnCancelar_Click(object sender, EventArgs e)
        {
            Principal.Show();
            //Cerrar ventana
            this.Hide();
        }
    }
}
