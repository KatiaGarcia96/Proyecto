using System;
using Gtk;
using CenterSpace.NMath.Stats;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace SPC
{
	public partial class Operador_Datos : Gtk.Window
	{
        String mat_;
        String maq_;
        String med_;
        String Us_;
		Gtk.Window Principal;
        Gtk.Window Anterior;
        int NDatos = 30;
        public Operador_Datos(Gtk.Window V, Gtk.Window C, String Mat, String maq, String med, String Us) :
				base(Gtk.WindowType.Toplevel)
		{

            mat_=Mat;
            maq_=maq;
            med_=med;
            Us_=Us;

			Principal = V;
            Anterior = C;
			this.Build();
            lb_Falta.Text = "Faltan " + NDatos + " datos";
			btn_ok.Clicked += new EventHandler(this.btnOk_Click);
			btn_Cnl.Clicked += new EventHandler(this.btnCnl_Click);
            entry1.KeyPressEvent += En_KeyPress;

		}
		private void btnOk_Click(object sender, EventArgs e)
		{
            //Guardar Datos

            var v = 0.65;

            double[] dblArray =new double[30];

            dblArray[NDatos-1] = Convert.ToDouble(entry1.Text);

            NDatos=NDatos - 1;

            lb_Falta.Text = "Faltan " + NDatos + " datos";

            if (NDatos == 0)
            {
                CenterSpace.NMath.Core.DoubleVector data = new CenterSpace.NMath.Core.DoubleVector(dblArray);

                int size = 30;
                double LSL = v - 0.05;
                double USL = v + 0.05;
                double target = v;
                var pc = new ProcessCapability(data, size, LSL, USL, target);
                var CPK = -1 * (pc.Cpk);
                Console.Write(CPK);



                const string connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=spcprojectdb.cxmd6kjxslqw.us-west-1.rds.amazonaws.com)(PORT=1521)) (CONNECT_DATA=(SERVICE_NAME=ORCL))); User Id=kyann;Password=Gakd0132;";
                OracleConnection connection = new OracleConnection(connectionString);
                // OracleCommand cmd;


                connection.Close();
                //Asignar a una variable que sea un commando
                OracleCommand user1 = new OracleCommand("AGREGAR_ENTRADA");
                //Al comando agregarle la conexion con la base de datos
                user1.Connection = connection;
                //Declarar que es un Procedure guardado
                user1.CommandType = System.Data.CommandType.StoredProcedure;

                //Declarar cuales son los parametros y si son entradas o salidas
                user1.Parameters.Add("ID_USER_", OracleDbType.Varchar2).Direction = System.Data.ParameterDirection.Input;
                user1.Parameters.Add("ID_MATERIAL_", OracleDbType.Varchar2).Direction = System.Data.ParameterDirection.Input;
                user1.Parameters.Add("ID_MAQUINA_", OracleDbType.Varchar2).Direction = System.Data.ParameterDirection.Input;
                user1.Parameters.Add("ID_MEDICION_", OracleDbType.Varchar2).Direction = System.Data.ParameterDirection.Input;
                user1.Parameters.Add("DATOS_", OracleDbType.Varchar2).Direction = System.Data.ParameterDirection.Input;

                //Declarar los valores
                user1.Parameters["ID_USER_"].Value =Us_;
                user1.Parameters["ID_MATERIAL_"].Value = mat_;
                user1.Parameters["ID_MAQUINA_"].Value = maq_;
                user1.Parameters["ID_MEDICION_"].Value = med_;
                user1.Parameters["DATOS_"].Value = CPK.ToString("##.##");



                connection.Open();
                //Ejecutar
                user1.ExecuteScalar();

                connection.Close();

                SPC.RealizarOtra R = new SPC.RealizarOtra(Principal, Anterior);
                this.Hide();
            }


		}
		private void btnCnl_Click(object sender, EventArgs e)
		{
            Anterior.Show();
			//Cerrar ventana
			this.Hide();
		}
        private void En_KeyPress(object sender, KeyPressEventArgs e)
        {
            //entry1.Text = "as";
            //Console.Write(e.ToString());
            //if ((int)e.KeyCode == (int)Keys.Enter)
            //{
            //    entry1.Text = "AS";
            //}

        }
	}
}
