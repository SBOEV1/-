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

namespace DEMOSBOEV
{
    public partial class Agents : Form
    {
        SqlConnection sqlConnection;
        public Agents()
        {
            InitializeComponent();
        }

        private async void Agents_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=192.168.0.136;Initial Catalog=SBOEVNIKITA;User ID=sboev;Password=Tt1t2t3t4t5t6T";
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
            

        }
        //добавить
        private async void button1_Click(object sender, EventArgs e)
        {
            if (label12.Visible)
                label12.Visible = false;

            if (!string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text) &&
                !string.IsNullOrEmpty(textBox12.Text) && !string.IsNullOrWhiteSpace(textBox12.Text) &&
                !string.IsNullOrEmpty(textBox10.Text) && !string.IsNullOrWhiteSpace(textBox10.Text) &&
                !string.IsNullOrEmpty(textBox11.Text) && !string.IsNullOrWhiteSpace(textBox11.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [Физ_лица] (id_физ_лица, Название_ИП, Серия_паспорта, Номер_паспорта, Адрес_проживания) VALUES (@id_физ_лица, @Название_ИП, @Серия_паспорта, @Номер_паспорта, @Адрес_проживания)", sqlConnection);
                command.Parameters.AddWithValue("id_физ_лица", textBox6.Text);
                command.Parameters.AddWithValue("Название_ИП", textBox12.Text);
                command.Parameters.AddWithValue("Серия_паспорта", textBox10.Text);
                command.Parameters.AddWithValue("Номер_паспорта", textBox11.Text);
                command.Parameters.AddWithValue("Адрес_проживания", textBox2.Text);

                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label12.Visible = true;
                label12.Text = "Все поля должны быть заполнены!";
            }


        }

        //редактировать
        private async void button7_Click(object sender, EventArgs e)
        {
            if (label8.Visible)
                label8.Visible = false;

            if (!string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text) &&
                !string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox8.Text) &&
                !string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox9.Text) &&
                !string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) &&
                !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text))
            {
                SqlCommand command = new SqlCommand("UPDATE [Физ_лица] SET [Название_ИП]=@Название_ИП, [Серия_паспорта]=@Серия_паспорта, [Номер_паспорта]=@Номер_паспорта, [Адрес_проживания]=@Адрес_проживания WHERE [id_физ_лица]=@id_физ_лица", sqlConnection);
                command.Parameters.AddWithValue("id_физ_лица", textBox7.Text);
                command.Parameters.AddWithValue("Название_ИП", textBox8.Text);
                command.Parameters.AddWithValue("Серия_паспорта", textBox9.Text);
                command.Parameters.AddWithValue("Номер_паспорта", textBox4.Text);
                command.Parameters.AddWithValue("Адрес_проживания", textBox3.Text);

                await command.ExecuteNonQueryAsync();
            }

            else
            {
                label8.Visible = true;
                label8.Text = "Все поля должны быть заполнены!";
            }
        }
        // удалить
        private async void button3_Click_1(object sender, EventArgs e)
        {
            if (label17.Visible)
                label17.Visible = false;

            if (!string.IsNullOrEmpty(textBox14.Text) && !string.IsNullOrWhiteSpace(textBox14.Text))
            {
                SqlCommand command = new SqlCommand("DELETE FROM [Физ_лица] WHERE [id_физ_лица]=@id_физ_лица", sqlConnection);

                command.Parameters.AddWithValue("id_физ_лица", textBox14.Text);

                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label17.Visible = true;
                label17.Text = "id должен быть заполнен";
            }
        }
        // вывести
        private async void button4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox15.Text) && !string.IsNullOrWhiteSpace(textBox15.Text))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM [Физ_лица] WHERE [id_физ_лица]=@id_физ_лица", sqlConnection);

                command.Parameters.AddWithValue("id_физ_лица", textBox15.Text);
                SqlDataReader sqlReader = null;

                try
                {
                    sqlReader = await command.ExecuteReaderAsync();
                    while (await sqlReader.ReadAsync())
                    {
                        listBox2.Items.Add(Convert.ToString(sqlReader["id_физ_лица"]) + "     " + Convert.ToString(sqlReader["Название_ИП"]) + "   " + Convert.ToString(sqlReader["Серия_паспорта"]) + "     " + Convert.ToString(sqlReader["Номер_паспорта"]) + " " + Convert.ToString(sqlReader["Адрес_проживания"]));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (sqlReader != null)
                        sqlReader.Close();
                }

            }
            else
            {
                label20.Visible = true;
                label20.Text = "id должен быть заполнен";
            }
        }
        //очистить форму
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {
            
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            Agents f = new Agents();
            f.Show();
        }
    }
}
