using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Xamarin.Forms;
using Xamarin.Forms.Platform.GTK;

namespace SPC
{
    public partial class Add_User : Gtk.Window
    {
        private OracleDataAdapter da;
        private OracleCommandBuilder cb;
        private System.Data.DataSet ds;
        String v;
        Admin_First P;
        public Add_User(String Id, Admin_First Ventana) :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            P = Ventana;
            combobox3.AppendText("Spr");
            combobox3.AppendText("Ing");
            combobox3.AppendText("Opr");
            combobox3.AppendText("Admin");
           


            combobox4.AppendText("Matutino");
            combobox4.AppendText("Vespertino");

            v = Id;
            btn_Ok.Clicked += new EventHandler(this.btnOk_Click);
            btn_Con.Clicked += new EventHandler(this.btnCon_Click);
            btn_Cnl.Clicked += new EventHandler(this.btnCnl_Click);

            if(v!=""){
                try
                {
                    const string connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=spcprojectdb.cxmd6kjxslqw.us-west-1.rds.amazonaws.com)(PORT=1521)) (CONNECT_DATA=(SERVICE_NAME=ORCL))); User Id=kyann;Password=Gakd0132;";
                    OracleConnection connection = new OracleConnection(connectionString);
                    OracleCommand cmd;

                    connection.Open();

                    string sql = "select ID_SYS, NOMBRE, APELLIDO, PUESTO, TURNO, PASSWORD_ from USUARIO WHERE ID_SYS='" + v.ToString()+"'";
                    Console.WriteLine(sql);
                    cmd = new OracleCommand(sql, connection);
                    cmd.CommandType = System.Data.CommandType.Text;

                    da = new OracleDataAdapter(cmd);
                    cb = new OracleCommandBuilder(da);
                    ds = new System.Data.DataSet();

                    da.Fill(ds);
                    DataTable de = ds.Tables[0];

                    String id_u1="";
                    String id_u2= "";
                    String id_u3= "";
                    String id_u4= "";
                    String id_u5= "";
                    String id_u6= "";
                    foreach (DataRow row in de.Rows)
                    {
                        id_u1 = (string)row[0];
                        id_u2 = (string)row[1];
                        id_u3 = (string)row[2];
                        id_u4 = (string)row[3];
                        id_u5 = (string)row[4];
                        id_u6 = (string)row[5];


                        //ListaUsuario.AppendValues(row[0], row[1], row[2]);
                    }
                    e_id.Text = id_u1;
                    e_nombre.Text = id_u2;
                    e_apellido.Text = id_u3;
                    //combobox3.;
                    if (id_u4 == "Spr") { combobox3.Active = 2; }
                    else if(id_u4 == "Ing"){combobox3.Active = 1;}
                    else if(id_u4 == "Opr") {combobox3.Active = 0;}
                    else if(id_u4 == "Admin"){combobox3.Active = 3;}

                    if (id_u5 == "Matutino") { combobox3.Active = 1; }
                    else if (id_u5 == "Vespertino") { combobox3.Active = 2; }

                    e_contrasena.Text = id_u6;



                }
                catch (OracleException Error)
                {
                    SPC.Error_Ventana Ventana_Error = new SPC.Error_Ventana("ErrorCon");
                    Console.Write(Error);
                }
            }

        }
        public void btnCnl_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void btnCon_Click(object sender, EventArgs e)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[10];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            e_contrasena.Text = finalString;
        }
        public void btnOk_Click(object sender, EventArgs e)
        {
            if (v != "")
            {
               
            
            }
            else
            {
                try
                {
                    const string connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=spcprojectdb.cxmd6kjxslqw.us-west-1.rds.amazonaws.com)(PORT=1521)) (CONNECT_DATA=(SERVICE_NAME=ORCL))); User Id=kyann;Password=Gakd0132;";
                    OracleConnection connection = new OracleConnection(connectionString);
                   // OracleCommand cmd;
                    var found = "";
                   
                        connection.Close();

                        //Asignar a una variable que sea un commando
                        OracleCommand user = new OracleCommand("CHECK_USER");

                        //user.BindByName = true;

                        //Al comando agregarle la conexion con la base de datos
                        user.Connection = connection;
                        //Declarar que es un Procedure guardado
                        user.CommandType = System.Data.CommandType.StoredProcedure;

                        //Declarar cuales son los parametros y si son entradas o salidas
                        OracleParameter rv = new OracleParameter("v_Return", OracleDbType.Varchar2, System.Data.ParameterDirection.ReturnValue);
                        //
                        OracleParameter r = new OracleParameter("r", OracleDbType.Varchar2, 200, "KATI0000", System.Data.ParameterDirection.Input);
                        //
                        OracleParameter id = new OracleParameter("ID_U", OracleDbType.Varchar2, 100, e_id.Text.ToString().ToUpper(), System.Data.ParameterDirection.Input);
                        //

                        OracleParameter[] ora_par = { r, id, rv };
                        user.Parameters.AddRange(ora_par);

                        //Abrir coneccion
                        connection.Open();

                        //Ejecutar
                        user.ExecuteNonQuery();

                        //Poner el valor de regreso de la funcion en una variable
                        found = (string)((Oracle.ManagedDataAccess.Types.OracleString)(user.Parameters[0].Value)).Value;

                        //Cerrar conexion
                        connection.Close();
                    Console.Write(found);

                    if (found != "11111")
                    {
                        SPC.Error_Ventana Ventana_Error = new SPC.Error_Ventana("UserAlready");
                    }
                    else
                    {


                        //const string connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=spcprojectdb.cxmd6kjxslqw.us-west-1.rds.amazonaws.com)(PORT=1521)) (CONNECT_DATA=(SERVICE_NAME=ORCL))); User Id=kyann;Password=Gakd0132;";
                        //var connection = new OracleConnection(connectionString);

                        //Asignar a una variable que sea un commando
                        OracleCommand user1 = new OracleCommand("AGREGAR_USUARIO");
                        //Al comando agregarle la conexion con la base de datos
                        user1.Connection = connection;
                        //Declarar que es un Procedure guardado
                        user1.CommandType = System.Data.CommandType.StoredProcedure;

                        //Declarar cuales son los parametros y si son entradas o salidas
                        user1.Parameters.Add("ID_U", OracleDbType.Varchar2).Direction = System.Data.ParameterDirection.Input;
                        user1.Parameters.Add("NOMBRE_U", OracleDbType.Varchar2).Direction = System.Data.ParameterDirection.Input;
                        user1.Parameters.Add("APELLIDO_U", OracleDbType.Varchar2).Direction = System.Data.ParameterDirection.Input;
                        user1.Parameters.Add("PUESTO_U", OracleDbType.Varchar2).Direction = System.Data.ParameterDirection.Input;
                        user1.Parameters.Add("TURNO_U", OracleDbType.Varchar2).Direction = System.Data.ParameterDirection.Input;
                        user1.Parameters.Add("PASSWORD_U", OracleDbType.Varchar2).Direction = System.Data.ParameterDirection.Input;

                        //Declarar los valores
                        user1.Parameters["ID_U"].Value = e_id.Text.ToString();
                        user1.Parameters["NOMBRE_U"].Value = e_nombre.Text.ToString();
                        user1.Parameters["APELLIDO_U"].Value = e_apellido.Text.ToString();
                        user1.Parameters["PUESTO_U"].Value = combobox3.ActiveText.ToString(); //e_puesto.Text.ToString();
                        user1.Parameters["TURNO_U"].Value = combobox4.ActiveText.ToString(); //e_turno.Text.ToString();
                        user1.Parameters["PASSWORD_U"].Value = e_contrasena.Text.ToString();

                        connection.Open();
                        //Ejecutar
                        user1.ExecuteScalar();
                        P.Refresh();
                        this.Hide();

                    }
                }
                catch (OracleException)
                {
                    SPC.Error_Ventana Ventana_Error = new SPC.Error_Ventana("ErrorCon");
                    //Console.Write(error);
                }
            }

            }
    }
}
