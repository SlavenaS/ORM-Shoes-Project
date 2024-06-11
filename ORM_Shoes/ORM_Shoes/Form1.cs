using ORM_Shoes.Controller;
using ORM_Shoes.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORM_Shoes
{
    public partial class Form1 : Form
    {
        Shoes_logic shoesController = new Shoes_logic();
        Shoes_type_Logic shoesTypeController = new Shoes_type_Logic();
        public Form1()
        {
            InitializeComponent();

        }
        private void LoadRecord(Shoes shoe)
        {
            textBox1.BackColor = Color.White;
            textBox1.Text = shoe.Id.ToString();
            textBox2.Text = shoe.Brand.ToString();
            textBox3.Text = shoe.Description.ToString();
            textBox4.Text = shoe.Price.ToString();
            textBox5.Text = shoe.Nomer.ToString();
            comboBox1.Text = shoe.Shoes_type.Shoe_Name;
        }
        private void ClearScreen()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.Text = "";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            List<Shoes_type> allShoes = shoesTypeController.GetAll();
            comboBox1.DataSource = allShoes;
            comboBox1.DisplayMember = "Shoe_Name";
            comboBox1.ValueMember = "Id";
            button5_Click(sender, e);

        }

        //add button
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) || textBox2.Text == "")
            {
                DialogResult answer2 = MessageBox.Show("Въведете данни! "
                    , "Добавяне на запис"
                    , MessageBoxButtons.OKCancel
                    , MessageBoxIcon.Information);
                textBox2.BackColor = Color.LightBlue;
                textBox2.Focus();
                return;
            }
            Shoes newShoe = new Shoes();
            // newShoe.Id = int.Parse(textBox1.Text);
            newShoe.Brand = textBox2.Text;
            newShoe.Description = textBox3.Text;
            newShoe.Price = double.Parse(textBox4.Text);
            newShoe.Nomer = int.Parse(textBox5.Text);
            newShoe.Shoes_typeId = (int)comboBox1.SelectedValue;

            shoesController.Create(newShoe);
            DialogResult answer = MessageBox.Show("Записа е добавен успешно!"
                   , "Данни!"
                   , MessageBoxButtons.OKCancel
                   , MessageBoxIcon.Information);
            ClearScreen();
            button5_Click(sender, e);
        }

        //select all button
        private void button5_Click(object sender, EventArgs e)
        {
            List<Shoes> allShoes = shoesController.GetAll();
            listBox1.Items.Clear();
            foreach (var item in allShoes)
            {
                listBox1.Items.Add($"Марка- {item.Brand};" +
                    $" Описание-{item.Description}; " +
                    $"Цена-{item.Price};" +
                    $" Номер-{item.Nomer};" +
                    $"Вид-{item.Shoes_type.Shoe_Name}");
            }
        }
        //find button
        private void button4_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(textBox1.Text) || !textBox1.Text.All(char.IsDigit))
            {
                DialogResult answer = MessageBox.Show("Въведете Id което искате да намерите! "
                    , "Търсене на Id"
                    , MessageBoxButtons.OKCancel
                    , MessageBoxIcon.Information);
                textBox1.BackColor = Color.LightBlue;
                textBox1.Focus();
                return;
            }
            else
            {
                findId = int.Parse(textBox1.Text);
            }
            Shoes findedShoe = shoesController.Get(findId);
            if (findedShoe == null)
            {
                DialogResult answer = MessageBox.Show("Не съществува такъв запис в БД! \n Въведете  Id за търсене!"
                    , "Добавяне на запис"
                    , MessageBoxButtons.OKCancel
                    , MessageBoxIcon.Information);
                textBox1.BackColor = Color.LightBlue;
                textBox1.Focus();
                return;
            }
            LoadRecord(findedShoe);

        }
        //update
        private void button2_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(textBox1.Text) || !textBox1.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете Id за търсене!");
                textBox1.BackColor = Color.Red;
                textBox1.Focus();
                return;
            }
            else
            {
                findId = int.Parse(textBox1.Text);
            }

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                Shoes findedShoe = shoesController.Get(findId);
                if (findedShoe == null)
                {
                    MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Въведете Id за търсене!");
                    textBox1.BackColor = Color.Red;
                    textBox1.Focus();
                    return;
                }
                LoadRecord(findedShoe);
            }
            else
            {
                Shoes updatedShoes = new Shoes();
                updatedShoes.Id = int.Parse(textBox1.Text);
                updatedShoes.Brand = textBox2.Text;
                updatedShoes.Description = textBox3.Text;
                updatedShoes.Price = double.Parse(textBox4.Text);
                updatedShoes.Nomer = int.Parse(textBox5.Text);
                updatedShoes.Shoes_typeId = (int)comboBox1.SelectedValue;

                shoesController.Update(findId, updatedShoes);
            }

            button5_Click(sender, e);
        }
        //delete
        private void button3_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(textBox1.Text) || !textBox1.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете Id за търсене!");
                textBox1.BackColor = Color.Red;
                textBox1.Focus();
                return;
            }
            else
            {
                findId = int.Parse(textBox1.Text);
            }
            Shoes findedShoe = shoesController.Get(findId);
            if (findedShoe == null)
            {
                MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Въведете Id за търсене!");
                textBox1.BackColor = Color.Red;
                textBox1.Focus();
                return;
            }
            LoadRecord(findedShoe);

            DialogResult answer = MessageBox.Show("Наистина ли искате да изтриете запис No " +
            findId + " ?",
             "PROMPT", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                shoesController.Delete(findId);
            }
            button5_Click(sender, e);
        }
    }
}
