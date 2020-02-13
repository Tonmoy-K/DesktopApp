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

namespace TONMOYAPP
{
    public partial class After_Logincs : Form
    {
        public After_Logincs()
        {
            InitializeComponent();
            
        }

        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TONMOY\Documents\consumer_details.mdf;Integrated Security=True;Connect Timeout=30");

        private void TIMER_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void DETAILS_Click(object sender, EventArgs e)
        {
            TEXT log = new TEXT();
            log.Show();
        }

        private void SEARCHBUTTON_Click(object sender, EventArgs e)
        {
            if (SEARCH.Text == "")
                MessageBox.Show("Enter valid Query");
            try
            {
                connect.Open();
                string q = "select * from tb1 where NAME='" + SEARCH.Text + "' or ADDRESS='" + SEARCH.Text + "' or CONTACT='" + SEARCH.Text + "' or TASKTYPE='" + SEARCH.Text + "' or GLASSTYPE='" + SEARCH.Text + "' or DIMENSION='" + SEARCH.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(q, connect);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                connect.Close();
                SEARCH.Text = "";
            }
            catch
            {
                MessageBox.Show("Enter valid search queries");
                SEARCH.Text = "";
            }
        }

        private void After_Logincs_Load(object sender, EventArgs e)
        {
            TIMER.Text = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss");
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            TIMER.Text = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss");
        }

        private void Timer1_Tick_1(object sender, EventArgs e)
        {
            TIMER.Text = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss");
        }

        private void Timer1_Tick_2(object sender, EventArgs e)
        {
            TIMER.Text = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss");
        }

        private void disp_data()
        {
            connect.Open();
            string q = "select * from tb1";
            SqlDataAdapter sda = new SqlDataAdapter(q, connect);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            connect.Close();
        }

        private void VIEWDATABASE_Click(object sender, EventArgs e)
        {
            disp_data();
        }

        private void SAVE_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connect = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =| DataDirectory |\consumer_details.mdf; Integrated Security = True; Connect Timeout = 30");
                string query = "insert into tb1(NAME,ADDRESS,CONTACT,TASKTYPE,GLASSTYPE,DIMENSION,L_CHARGE,F_CHARGE,A_CHARGE,AMOUNT) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "')";
                connect.Open();
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.ExecuteNonQuery();
                connect.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                MessageBox.Show("Data inserted successfully");
                disp_data();
            }
            catch
            {
                MessageBox.Show("No new data found to save");
            }
        }

        private void CALC_Click(object sender, EventArgs e)
        {
            try
            {
                int lc = Convert.ToInt32(textBox5.Text);
                int fc = Convert.ToInt32(textBox6.Text);
                int ac = Convert.ToInt32(textBox7.Text);

                int result = lc + fc + ac;

                textBox8.Text = (result.ToString());
            }
            catch
            {
                if (textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
                    MessageBox.Show("Fill repective Charges with proper values");
            }
        }

        private void UPDATE_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                string query2 = "update tb1 set ADDRESS='" + this.textBox2.Text + "',CONTACT='" + this.textBox3.Text + "',TASKTYPE='" + this.comboBox1.Text + "',GLASSTYPE='" + this.comboBox2.Text + "',DIMENSION='" + this.textBox4.Text + "',L_CHARGE='" + this.textBox5.Text + "',F_CHARGE='" + this.textBox6.Text + "',A_CHARGE='" + this.textBox7.Text + "',AMOUNT='" + this.textBox8.Text + "' where NAME='" + this.textBox1.Text + "'";
                SqlCommand sda = new SqlCommand(query2, connect);
                sda.ExecuteNonQuery();
                connect.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                MessageBox.Show("Details Updated");
                disp_data();
            }
            catch
            {
                MessageBox.Show("Nothing to update");

            }
        }

        private void DELETE_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                String q3 = "delete from tb1 where NAME ='" + textBox1.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(q3, connect);
                sda.SelectCommand.ExecuteNonQuery();
                connect.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                MessageBox.Show("Details Deleted");
                disp_data();
            }
            catch
            {
                MessageBox.Show("Nothing to delete");
            }
        }

        private void EXIT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            textBox8.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int value = 50;
                int input = Convert.ToInt32(textBox4.Text);
                if (input < 3 || input == 3)
                    textBox7.Text = value.ToString();
                else if (input > 3 && (input < 6 || input == 6))
                    textBox7.Text = (value + 25).ToString();
                else if (input > 6 && (input < 9 || input == 9))
                    textBox7.Text = (value + 50).ToString();
                else if (input > 9 && (input < 12 || input == 12))
                    textBox7.Text = (value + 75).ToString();
                else if (input > 12 && (input < 36 || input == 36))
                    textBox7.Text = (value + 120).ToString();
                else if (input > 36 && (input < 48 || input == 48))
                    textBox7.Text = (value + 150).ToString();
                else
                    MessageBox.Show("Not a valid Dimension");
            }
            catch
            {
                if (textBox7.Text == "")
                    MessageBox.Show("Enter Valid Dimension see the chart");
            }
        }
    }
}
