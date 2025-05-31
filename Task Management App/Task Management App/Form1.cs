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

namespace Task_Management_App
{
    public partial class Form1: Form
    {
        string connectionString = "Data Source=DESKTOP-H2KNIQ4\\SQLEXPRESS;Initial Catalog=TaskManagerDB;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
            LoadTasks();
        }

        private void LoadTasks()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Tasks", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Tasks (Title, Description, DueDate, Priority, Status) VALUES (@Title, @Desc, @Due, @Priority, @Status)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                cmd.Parameters.AddWithValue("@Desc", txtDescription.Text);
                cmd.Parameters.AddWithValue("@Due", dtpDueDate.Value.Date);
                cmd.Parameters.AddWithValue("@Priority", cmbPriority.Text);
                cmd.Parameters.AddWithValue("@Status", cmbStatus.Text);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            LoadTasks();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int taskId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Tasks SET Title=@Title, Description=@Desc, DueDate=@Due, Priority=@Priority, Status=@Status WHERE Id=@Id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                    cmd.Parameters.AddWithValue("@Desc", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@Due", dtpDueDate.Value.Date);
                    cmd.Parameters.AddWithValue("@Priority", cmbPriority.Text);
                    cmd.Parameters.AddWithValue("@Status", cmbStatus.Text);
                    cmd.Parameters.AddWithValue("@Id", taskId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                LoadTasks();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int taskId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Tasks WHERE Id=@Id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Id", taskId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                LoadTasks();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                txtTitle.Text = row.Cells["Title"].Value.ToString();
                txtDescription.Text = row.Cells["Description"].Value.ToString();
                dtpDueDate.Value = Convert.ToDateTime(row.Cells["DueDate"].Value);
                cmbPriority.Text = row.Cells["Priority"].Value.ToString();
                cmbStatus.Text = row.Cells["Status"].Value.ToString();
            }
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbPriority.Items.AddRange(new string[] { "Low", "Medium", "High" });
            cmbStatus.Items.AddRange(new string[] { "Pending", "In Progress", "Done" });
        }

        private void btnadd_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Tasks (Title, Description, DueDate, Priority, Status) VALUES (@Title, @Desc, @Due, @Priority, @Status)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                cmd.Parameters.AddWithValue("@Desc", txtDescription.Text);
                cmd.Parameters.AddWithValue("@Due", dtpDueDate.Value.Date);
                cmd.Parameters.AddWithValue("@Priority", cmbPriority.Text);
                cmd.Parameters.AddWithValue("@Status", cmbStatus.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            LoadTasks(); // refresh DataGridView
        }

        private void btnupdate_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int taskId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Tasks SET Title=@Title, Description=@Desc, DueDate=@Due, Priority=@Priority, Status=@Status WHERE Id=@Id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                    cmd.Parameters.AddWithValue("@Desc", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@Due", dtpDueDate.Value.Date);
                    cmd.Parameters.AddWithValue("@Priority", cmbPriority.Text);
                    cmd.Parameters.AddWithValue("@Status", cmbStatus.Text);
                    cmd.Parameters.AddWithValue("@Id", taskId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                LoadTasks();
            }
        }

        private void btndelete_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int taskId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Tasks WHERE Id=@Id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Id", taskId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                LoadTasks();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                txtTitle.Text = row.Cells["Title"].Value.ToString();
                txtDescription.Text = row.Cells["Description"].Value.ToString();
                dtpDueDate.Value = Convert.ToDateTime(row.Cells["DueDate"].Value);
                cmbPriority.Text = row.Cells["Priority"].Value.ToString();
                cmbStatus.Text = row.Cells["Status"].Value.ToString();
            }
        }
    }
}
