using System;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace SPC
{
	public partial class Operador_Informacion : Gtk.Window
	{
        String Us_;
        const string connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=spcprojectdb.cxmd6kjxslqw.us-west-1.rds.amazonaws.com)(PORT=1521)) (CONNECT_DATA=(SERVICE_NAME=ORCL))); User Id=kyann;Password=Gakd0132;";
        OracleConnection connection = new OracleConnection(connectionString);
		Gtk.Window Principal;
		public Operador_Informacion(Gtk.Window V, String Us) :
				base(Gtk.WindowType.Toplevel)
		{
			Principal = V;
            Us_ = Us;
			this.Build();
			btn_Ok.Clicked += new EventHandler(this.btnOk_Click);
			btn_Cnl.Clicked += new EventHandler(this.btnCnl_Click);

		}

		public void btnOk_Click(object sender, EventArgs e)
		{
			//Declaracion de las variables
			var Material = E_Mat.Text;
			var Maquina = E_Mach.Text;
			var Equipo = E_Tool.Text;
			//Buscar info en la base de datos


            /*
            //Asignar a una variable que sea un commando
            OracleCommand user = new OracleCommand("USER_PASSW");

            //user.BindByName = true;

            //Al comando agregarle la conexion con la base de datos
            user.Connection = connection;
            //Declarar que es un Procedure guardado
            user.CommandType = System.Data.CommandType.StoredProcedure;

            //Declarar cuales son los parametros y si son entradas o salidas
            OracleParameter rv = new OracleParameter("v_Return", OracleDbType.Varchar2, System.Data.ParameterDirection.ReturnValue);
            //
            OracleParameter r = new OracleParameter("r", OracleDbType.Varchar2, 200, "KATI0", System.Data.ParameterDirection.Input);
            //
            OracleParameter id = new OracleParameter("ID_U", OracleDbType.Varchar2, 200, id_t, System.Data.ParameterDirection.Input);
            //
            OracleParameter pas = new OracleParameter("PASSWORD_U", OracleDbType.Varchar2, 200, pass_t, System.Data.ParameterDirection.Input);

            OracleParameter[] ora_par = { r, id, pas, rv };
            user.Parameters.AddRange(ora_par);

            //Abrir coneccion
            connection.Open();

            //Ejecutar
            user.ExecuteNonQuery();

            //Poner el valor de regreso de la funcion en una variable
            var text = (string)((OracleString)(user.Parameters[0].Value)).Value;

            */

			//Checar todos los campos llenos, si no mandar mensaje
			if (Material != "" && Maquina != "" && Equipo != "")
			{
                SPC.Operador_Datos Ventana = new SPC.Operador_Datos(Principal, this,Material,Maquina,Equipo, Us_);
				Ventana.Show();
				//Esconder la pantalla;
				this.Hide();
            }else{
                SPC.Error_Ventana Ventana_Error = new SPC.Error_Ventana("NoCaptura");
            }
		}
		public void btnCnl_Click(object sender, EventArgs e)
		{
			Principal.Show();
			//Cerrar ventana
			this.Hide();
		}
	}
}
