using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionDeTâches
{
    public partial class PageAdmin : Form
    {
        login lo = new login();
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        public static extern IntPtr CreateRoundRectRgn(

           int nLeftRect,
           int nTopRect,
           int RightRect,
           int nBottomRect,
           int nWidthEllipse,
           int nHeightEllipse
           );
        public PageAdmin()
        {
            InitializeComponent();

            panelEmp.Visible = false;
            panelCS.Visible = false;
            panelDts.Visible = false;
            picCS.Visible = false;
            picD.Visible=false;
            picEmp.Visible=false;
            picHome.Visible=true;

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        private void PageAdmin_Load(object sender, EventArgs e)
        {
            
        }

        private void btnEmp_Click(object sender, EventArgs e)
        {
            panelEmp.Visible = true;
            panelCS.Visible = false;
            panelDts.Visible = false;
            picCS.Visible = false;
            picD.Visible = false;
            picEmp.Visible = true;
            picHome.Visible = false;
            labelMenu.Text = "Employé(e)s";

        }

        private void btnRtrCS_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            panelEmp.Visible=false;
            panelDts.Visible=false;
            panelCS.Visible = true;
            picCS.Visible = true;
            picD.Visible = false;
            picEmp.Visible = false;
            picHome.Visible = false;
            labelMenu.Text = "Chef de Service";


        }

        private void btnDts_Click(object sender, EventArgs e)
        {
            
        }

        

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            new login().Show();
            this.Hide();

        }

        private void btnDts_Click_1(object sender, EventArgs e)
        {
            panelEmp.Visible = false;
            panelDts.Visible = true;
            panelCS.Visible = false;
            picCS.Visible = false;
            picD.Visible = true;
            picEmp.Visible = false;
            picHome.Visible = false;
            labelMenu.Text = "Détails";

        }

        private void picCS_Click(object sender, EventArgs e)
        {

        }


        private Form activeFrom = null;
        private void openChilFrom(Form childForm)
        {
            if (activeFrom != null)
                activeFrom.Close();
            activeFrom=childForm;
            activeFrom.TopLevel = false;
            activeFrom.FormBorderStyle = FormBorderStyle.None;
            activeFrom.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(activeFrom);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            activeFrom.Show();
        }

        private void btnIns_Click(object sender, EventArgs e)
        {
            openChilFrom(new InscritionEmp());
        }

        private void btnMaj_Click(object sender, EventArgs e)
        {
            openChilFrom(new MajEmp());
        }
    }
}
