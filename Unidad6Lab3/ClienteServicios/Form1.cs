using Negocio;
using Entidades;
using Alta;

namespace ClienteServicios
{
    public partial class Form1 : Form
    {
        private Task<IEnumerable<Alumno>>? l;
        public Form1()
        {
            InitializeComponent();
        }

        public IEnumerable<Alumno> CargarTabla()
        {
            l = AlumnoNegocio.GetAll();
            return l.Result;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Task<IEnumerable<Alumno>> task = new Task<IEnumerable<Alumno>>(CargarTabla);
            task.Start();
            dataGridView1.DataSource = await task;
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            int filaSeleccionada = dataGridView1.SelectedRows[0].Index;
            await AlumnoNegocio.Delete(l.Result.ToList()[filaSeleccionada]);
            button1_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Alta.Alta().ShowDialog();
            button1_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int filaSeleccionada = dataGridView1.SelectedRows[0].Index;
            new Alta.Alta(l.Result.ToList()[filaSeleccionada]).ShowDialog();
            button1_Click(sender, e);
        }
    }
}
