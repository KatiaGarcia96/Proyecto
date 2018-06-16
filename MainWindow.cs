using System;
using System.Threading;
using Gtk;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

public partial class MainWindow : Gtk.Window
{
    const string connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=spcprojectdb.cxmd6kjxslqw.us-west-1.rds.amazonaws.com)(PORT=1521)) (CONNECT_DATA=(SERVICE_NAME=ORCL))); User Id=kyann;Password=Gakd0132;";
    OracleConnection connection = new OracleConnection(connectionString);
	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		Build();

		btn_ok.Clicked += new EventHandler(this.btnOk_Click);
		btn_Salir.Clicked += new EventHandler(this.btnCnl_Click);


	}


	public void btnOk_Click(object sender, EventArgs e)
	{
        //Tomar valores de las cajas de texto
        string id_t=E_usr.Text;
        string pass_t = entry4.Text;

        if (E_usr.Text == "" || entry4.Text == "")
        {
            E_usr.Text = "";
            entry4.Text = "";
            SPC.Test pp = new SPC.Test();
            pp.Show();
            //SPC.Error_Ventana Ventana_Error = new SPC.Error_Ventana("NoCaptura");

        }
        else
        {
            var text = "";
            try
            {
                connection.Close();

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
                text = (string)((OracleString)(user.Parameters[0].Value)).Value;
                Console.Write(text);
                //Cerrar conexion
                connection.Close();

            //Decidir a que ventana ir
            if (text == "Admin")
            {
                SPC.Admin_First Ventana = new SPC.Admin_First(this);
                Ventana.Show();
                E_usr.Text = "";
                entry4.Text = "";
                this.Hide();
            }
            else if (text == "Opr")
            {
                    SPC.Operador_Informacion Ventana = new SPC.Operador_Informacion(this, E_usr.Text);
                Ventana.Show();
                E_usr.Text = "";
                entry4.Text = "";
                this.Hide();
            }
            else if (text == "Ing" || text == "Spr")
            {
                SPC.Supervisor Ventana = new SPC.Supervisor(this);
                Ventana.Show();
                E_usr.Text = "";
                entry4.Text = "";
                this.Hide();
            }
            else
            {
                E_usr.Text = "";
                entry4.Text = "";
                SPC.Error_Ventana Ventana_Error = new SPC.Error_Ventana("LogIn");
            }
            }
            catch (OracleException error)
            {
                SPC.Error_Ventana Ventana_Error = new SPC.Error_Ventana("ErrorCon");
                Console.Write(error);
            }
        }
	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
        connection.Close();
		Application.Quit();
		a.RetVal = true;
	}
	public void btnCnl_Click(object sender, EventArgs e)
	{
		//Agregar la ventana de segurida
        connection.Close();
		Application.Quit();

	}
}
