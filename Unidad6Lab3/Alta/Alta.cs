using System;
using System.Windows.Forms;
using Entidades;
using Negocio;

namespace Alta
{
    public partial class Alta : Form
    {
        private Alumno _alumno;

        public Alta()
        {
            InitializeComponent();
            button1.Text = "Agregar";
        }

        public Alta(Alumno alumnoAModificar) : this()
        {
            _alumno = alumnoAModificar;
            button1.Text = "Modificar";
        }

        private void Alta_Load(object sender, EventArgs e)
        {
            if (_alumno != null)
            {
                textBox1.Text = _alumno.DNI;
                textBox1.Enabled = false;
                textBox2.Text = _alumno.ApellidoNombre;
                textBox3.Text = _alumno.Email;
                dateTimePicker1.Value = _alumno.FechaNacimiento;
                textBox5.Text = _alumno.NotaPromedio.ToString();
            }
            else
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                dateTimePicker1.Value = DateTime.Now;
                textBox5.Clear();
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno
            {
                DNI = textBox1.Text,
                ApellidoNombre = textBox2.Text,
                Email = textBox3.Text,
                FechaNacimiento = dateTimePicker1.Value,
                NotaPromedio = Convert.ToDecimal(textBox5.Text)
            };

            try
            {
                bool resultado;
                if (button1.Text == "Modificar")
                {
                    await AlumnoNegocio.Update(alumno);
                    resultado = true;
                    MessageBox.Show("Alumno modificado con éxito.");
                }
                else
                {
                    await AlumnoNegocio.Add(alumno);
                    resultado = true;
                    MessageBox.Show("Alumno agregado con éxito.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
