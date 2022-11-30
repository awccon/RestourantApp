using System.Windows.Forms;

namespace RestaurantApp4
{
	public partial class Form1 : Form
	{
		Server server = new Server();

		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			server.SubmitNewOrder(int.Parse(txtChickenCount.Text), int.Parse(txtEggCount.Text), txtClientName.Text, listOfDrinks.Tea);
			txtChickenCount.Text = txtEggCount.Text = txtClientName.Text = "";
		}

		private void button2_Click(object sender, EventArgs e)
		{

		}

		private void button3_Click(object sender, EventArgs e)
		{
			listBox1.DataSource = null;
			listBox1.DataSource = server.PrepareFood(txtClientName.Text);
		}
	}
}