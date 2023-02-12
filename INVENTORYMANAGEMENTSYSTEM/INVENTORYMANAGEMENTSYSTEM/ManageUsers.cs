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

namespace INVENTORYMANAGEMENTSYSTEM
{
    public partial class ManageUsers : Form
    {
        public ManageUsers()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\RAVAN\Documents\Inventorydb.mdf;Integrated Security=True;Connect Timeout=30");

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void populate()
        {
            try
            {
                Con.Open();

                string Myquery = "select * from UserTbl";
                SqlDataAdapter da = new SqlDataAdapter(Myquery, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                UserGV.DataSource = ds.Tables[0];

                

                Con.Close();

            }

            catch
            {
                

            }

        }


        private void button1_Click(object sender, EventArgs e)
        {

      

            try
            {
                Con.Open();

                SqlCommand cmd = new SqlCommand("insert into UserTbl values('" + unameTb.Text + "', '" + FnameTb.Text + "', '" + PasswordTb.Text + "', '" + PhoneTb.Text + "')", Con);

                cmd.ExecuteNonQuery();
                MessageBox.Show("User Successfully Added");

               Con.Close();

                populate();
            }
            catch 
            {

               
            }
        }

    

        private void ManageUsers_Load_1(object sender, EventArgs e)
        {
            populate();
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            if (PhoneTb.Text=="")
            {
                MessageBox.Show("Enter The Users Phone Number");
            }
            else
            {
                Con.Open();
                string myquery = "delete from UserTbl where UPhone='" + PhoneTb.Text + "';";
                SqlCommand cmd = new SqlCommand(myquery, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Successfully Deleted");
                Con.Close();
                populate();
            }
        }

        private void UserGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            unameTb.Text = UserGV.SelectedRows[0].Cells[0].Value.ToString();
            FnameTb.Text = UserGV.SelectedRows[0].Cells[1].Value.ToString();
            PasswordTb.Text = UserGV.SelectedRows[0].Cells[2].Value.ToString();
            PhoneTb.Text = UserGV.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();

                SqlCommand cmd = new SqlCommand("update UserTbl set Uname='"+unameTb.Text+"',Ufullname='"+FnameTb.Text+"',Upassword='"+PasswordTb.Text+"'where UPhone='"+PhoneTb.Text+"'", Con);

                cmd.ExecuteNonQuery();
                MessageBox.Show("User Successfully Updated");

                Con.Close();

                populate();
            }
            catch
            {


            }
        }
    }
}
