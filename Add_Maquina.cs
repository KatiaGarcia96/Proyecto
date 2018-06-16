using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
namespace SPC
{
    public partial class Add_Maquina : Gtk.Window
    {
        private OracleDataAdapter da;
        private OracleCommandBuilder cb;
        private System.Data.DataSet ds;
        string type;
        public Add_Maquina(String what) :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();

            const string connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=spcprojectdb.cxmd6kjxslqw.us-west-1.rds.amazonaws.com)(PORT=1521)) (CONNECT_DATA=(SERVICE_NAME=ORCL))); User Id=kyann;Password=Gakd0132;";
            OracleConnection connection = new OracleConnection(connectionString);
            OracleCommand cmd;

            connection.Open();


            //select MEDICION_SEQ.NEXTVAL FROM DUAL;

            connection.Close();
            string sql;
            type = what;
            if(what=="Maquina"){
                label3.Text = "Agregar maquina";
                label1.Text = "Numero de Maquina";
                sql = "SELECT MAQUINA_SEQ.NEXTVAL FROM DUAL";

            }else{
                label3.Text = "Agregar instrumento de medición";
                label1.Text = "Numero de instrumento de medición";
                sql = "SELECT MEDICION_SEQ.NEXTVAL FROM DUAL";
            }
            try{ 
                cmd = new OracleCommand(sql, connection);
            cmd.CommandType = System.Data.CommandType.Text;

            da = new OracleDataAdapter(cmd);
            cb = new OracleCommandBuilder(da);
            ds = new System.Data.DataSet();

            da.Fill(ds);
            DataTable de = ds.Tables[0];


            foreach (DataRow row in de.Rows)
            {
                    entry1.Text = row[0].ToString();
            }

        }
            catch (OracleException)
            {
                //SPC.Error_Ventana Ventana_Error = new SPC.Error_Ventana("ErrorCon");
            }
           

            btn_OK.Clicked += new EventHandler(this.btnOk_Click);
            btn_Cnl.Clicked += new EventHandler(this.btnCnl_Click);
        }


        public void btnCnl_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void btnOk_Click(object sender, EventArgs e)
        {
            
            const string connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=spcprojectdb.cxmd6kjxslqw.us-west-1.rds.amazonaws.com)(PORT=1521)) (CONNECT_DATA=(SERVICE_NAME=ORCL))); User Id=kyann;Password=Gakd0132;";
            OracleConnection connection = new OracleConnection(connectionString);
            // OracleCommand cmd;


            //select MEDICION_SEQ.NEXTVAL FROM DUAL;

            connection.Close();
            //Asignar a una variable que sea un commando
            string sql = "";
            if (type=="Maquina"){
                sql = "AGREGAR_MAQUINA";
            }else{
                sql = "AGREGAR_MEDICION";
            }
            OracleCommand user1 = new OracleCommand(sql);
            //Al comando agregarle la conexion con la base de datos
            user1.Connection = connection;
            //Declarar que es un Procedure guardado
            user1.CommandType = System.Data.CommandType.StoredProcedure;

            //Declarar cuales son los parametros y si son entradas o salidas

            user1.Parameters.Add("DESCRIPCION_U", OracleDbType.Varchar2).Direction = System.Data.ParameterDirection.Input;
           

            user1.Parameters["DESCRIPCION_U"].Value = entry2.Text;//entry2.Text.ToString();
           
            connection.Open();
            //Ejecutar
            user1.ExecuteScalar();
            this.Hide();
        }
    }
}
