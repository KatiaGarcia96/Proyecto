using System;
using Oracle.ManagedDataAccess.Client;
namespace SPC
{
    public partial class Add_Materiales : Gtk.Window
    {
        public Add_Materiales() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            btn_OK.Clicked += new EventHandler(this.btnOk_Click);
            btn_Cnl.Clicked += new EventHandler(this.btnCnl_Click);
        }
        public void btnCnl_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void btnOk_Click(object sender, EventArgs e)
        {
            try {
                Convert.ToDouble(entry3.Text);
            }catch(Exception){
                new SPC.Error_Ventana("");
            }
            const string connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=spcprojectdb.cxmd6kjxslqw.us-west-1.rds.amazonaws.com)(PORT=1521)) (CONNECT_DATA=(SERVICE_NAME=ORCL))); User Id=kyann;Password=Gakd0132;";
            OracleConnection connection = new OracleConnection(connectionString);
            // OracleCommand cmd;


            connection.Close();
            //Asignar a una variable que sea un commando
            OracleCommand user1 = new OracleCommand("AGREGAR_MATERIALES");
            //Al comando agregarle la conexion con la base de datos
            user1.Connection = connection;
            //Declarar que es un Procedure guardado
            user1.CommandType = System.Data.CommandType.StoredProcedure;

            //Declarar cuales son los parametros y si son entradas o salidas
            user1.Parameters.Add("MATERIAL_U", OracleDbType.Varchar2).Direction = System.Data.ParameterDirection.Input;
            user1.Parameters.Add("DESCRIPCION_U", OracleDbType.Varchar2).Direction = System.Data.ParameterDirection.Input;
            user1.Parameters.Add("DIMENSION_U", OracleDbType.Varchar2).Direction = System.Data.ParameterDirection.Input;

            //Declarar los valores
            user1.Parameters["MATERIAL_U"].Value = entry1.Text.ToString();
            user1.Parameters["DESCRIPCION_U"].Value = entry2.Text;//entry2.Text.ToString();
            user1.Parameters["DIMENSION_U"].Value = entry3.Text;// Convert.ToDouble(entry3.Text);


            connection.Open();
            //Ejecutar
            user1.ExecuteScalar();
            this.Hide();
        }

    }
}
