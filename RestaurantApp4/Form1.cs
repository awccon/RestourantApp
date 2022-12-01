using RestaurantApp4.classes;
using System.Windows.Forms;

namespace RestaurantApp4
{
	public partial class Form1 : Form
	{
		Server server = null;

		public Form1()
		{
			InitializeComponent();
			server = new Server(Printer);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			server.SubmitNewOrder(int.Parse(txtChickenCount.Text), int.Parse(txtEggCount.Text), txtClientName.Text, listOfDrinks.Tea);
			txtChickenCount.Text = txtEggCount.Text = txtClientName.Text = "";
		}

		private void button2_Click(object sender, EventArgs e)
		{
			server.SendToCook();
		}

		public void Printer(string text)
		{
			listBox1.Items.Insert(0, text);
		}
	}
}