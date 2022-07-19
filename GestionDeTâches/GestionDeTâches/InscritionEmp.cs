using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace GestionDeTâches
{
    public partial class InscritionEmp : Form
    {
        MyBD db = new MyBD();
        public InscritionEmp()
        {
            
            InitializeComponent();
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void InscritionEmp_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'tagDataDataSet1.departements'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.departementsTableAdapter.Fill(this.tagDataDataSet1.departements);
          

        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtNom.Clear();
            txtPrenom.Clear();
            txtDN.Clear();
            txtPwd.Clear(); 
            txtDept.Text = "Sélectionner Département";
            txtComp.Clear();
            txtProfession.Clear();
            txtID.Focus();
        }

        private void btnInscription_Click(object sender, EventArgs e)
        {
            if(txtID.Text == "" || txtNom.Text == ""|| txtPrenom.Text == "" || txtComp.Text == "" || txtDN.Text =="" || txtPwd.Text == "" || txtDept.SelectedItem==null || txtProfession.Text=="")
            {
                MessageBox.Show("Complèter tout les champs!!!");
            }
            else
            {
                SqlCommand cmd = new SqlCommand();

                db.openConnection();
                String requete = "insert into employe values ('"+txtID.Text+ "', '"+txtNom.Text+"', '"+txtPrenom.Text+ "', '"+ txtComp.Text + "', '"+ txtDN.Text + "', '"+txtPwd.Text+ "', '"+ txtDept.Text + "', '" + txtProfession.Text + "' )";
                cmd = new SqlCommand(requete, db.GetConnexion);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Vous avez bien enregistré");
                db.closeConnection();
            }



            
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
