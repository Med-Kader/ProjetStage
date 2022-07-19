using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionDeTâches
{
    public partial class MajEmp : Form
    {
        MyBD db = new MyBD();
        public MajEmp()
        {
            InitializeComponent();
        }

        private void MajEmp_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'tagDataDataSet2.employe'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.employeTableAdapter.Fill(this.tagDataDataSet2.employe);

        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = bunifuDataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtComp.Text = bunifuDataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtPwd.Text = bunifuDataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            txtDept.Text = bunifuDataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void btnRhh_Click(object sender, EventArgs e)
        {
            db.openConnection();
            try
            {
                string requete = "select * from employe where idEmp = '" + txtRhh.Text + "'";

                SqlCommand cmd = new SqlCommand(requete, db.GetConnexion);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);
                bunifuDataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            txtDept.Text = "Sélectionner Département";
            txtRhh.Clear();
            txtID.Clear();
            txtPwd.Clear();
            txtComp.Clear();

            string req = "select * from employe";

            SqlCommand cmd = new SqlCommand(req, db.GetConnexion);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            bunifuDataGridView1.DataSource = dt;

        }

        private void btnmaj_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtComp.Text =="" || txtPwd.Text=="" || txtDept.Text == "Sélectionner Département")
                {
                    MessageBox.Show("Completer tout les champs");
                }
                else
                {
                    string query = "update employe set compEmp='"+txtComp+"', deptEmp='"+txtDept+"', mdpEmp='"+txtPwd+"' where idEmp="+txtID+";";
                }
            }
            catch
            {

            }
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
