using System;
namespace SPC
{
    public partial class Error_Ventana : Gtk.Window
    {
        public Error_Ventana(String Error_Des) :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();


            if (Error_Des == "LogIn")
            {
                label1.Text = "Usuario o contraseña incorrecta";
            }
            else if(Error_Des=="NoCaptura"){
                label1.Text = "Favor de capturar todos los campos";
            }else if (Error_Des == "ErrorCon")
            {
                label1.Text = "Error de Conexion";
            
            }else if (Error_Des == "UserAlready")
            {
                label1.Text = "Ya existe un usuario con el numero de usuario";
            }
            else if (Error_Des == "NoDisponible")
            {
                label1.Text = "Esta acción no esta disponible";  
            }else{
                label1.Text = Error_Des; 
            }

            btn_Ok.Clicked += new EventHandler(this.btnOk_Click);

        }
        public void btnOk_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
