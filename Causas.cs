using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
namespace SPC
{
    public partial class Causas : Gtk.Window
    {
        private OracleDataAdapter da;
        private OracleCommandBuilder cb;
        private System.Data.DataSet ds;
        string type;
        public Causas(string what, Gtk.Window V) :
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
            if (what == "Causa")
            {
                
                label1.Text = "Capturar causa:";

            }
            else
            {
                label1.Text = "Capturar la acción:";
            }

            btn_Ok.Clicked += new EventHandler(this.btnOk_Click);
            btn_Cancelar.Clicked += new EventHandler(this.btnCnl_Click);
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
            if (type == "Maquina")
            {
                sql = "AGREGAR_MAQUINA";
            }
            else
            {
                sql = "AGREGAR_MEDICION";
            }
            OracleCommand user1 = new OracleCommand(sql);
            //Al comando agregarle la conexion con la base de datos
            user1.Connection = connection;
            //Declarar que es un Procedure guardado
            user1.CommandType = System.Data.CommandType.StoredProcedure;

            //Declarar cuales son los parametros y si son entradas o salidas

            user1.Parameters.Add("DESCRIPCION_U", OracleDbType.Varchar2).Direction = System.Data.ParameterDirection.Input;


            //user1.Parameters["DESCRIPCION_U"].Value = entry2.Text;//entry2.Text.ToString();

            connection.Open();
            //Ejecutar
            user1.ExecuteScalar();
            this.Hide();

        }
    }
}
