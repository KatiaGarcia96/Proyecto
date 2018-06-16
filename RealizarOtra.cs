using System;
namespace SPC
{
    public partial class RealizarOtra : Gtk.Window
    {
        Gtk.Window Principal;
        Gtk.Window Anterior;
        public RealizarOtra(Gtk.Window V, Gtk.Window C) :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            Principal = V;
            Anterior = C;
            btn_Si.Clicked += new EventHandler(this.btnSi_Click);
            btn_No.Clicked += new EventHandler(this.btnNo_Click);

        }
        private void btnSi_Click(object sender, EventArgs e)
        {
            this.Hide();
            Anterior.Show();
        }
        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Hide();
            Principal.Show();
        }
    }
}
