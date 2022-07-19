using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionDeTâches
{
    public partial class login : Form
    {
        MyBD db = new MyBD();
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        public static extern IntPtr CreateRoundRectRgn(

           int nLeftRect,
           int nTopRect,
           int RightRect,
           int nBottomRect,
           int nWidthEllipse,
           int nHeightEllipse
           );
        public login()
        {
            InitializeComponent();
            picInvisible.Visible = false;

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void picUser_Click(object sender, EventArgs e)
        {
           
        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void picVisible_Click(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '\0';
            
            picVisible.Visible = false;

            picInvisible.Visible = true;



        }

        private void picInvisible_Click(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
            picInvisible.Visible = false;
            picVisible.Visible = true;

        }

   

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void btnCon_Click(object sender, EventArgs e)
        {
            
            SqlCommand cmd = new SqlCommand();

            db.openConnection();

            string log = "select * from admin where userAdmin='" + txtUsername.Text + "' and passAdmin='" + txtPassword.Text + "'";
            cmd = new SqlCommand(log, db.GetConnexion);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true)
            {
                new PageAdmin().Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Identifiant ou mot de passe est incorrecte, reéssayer svp", "Connexion echoué", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dr.Close();
            }
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
