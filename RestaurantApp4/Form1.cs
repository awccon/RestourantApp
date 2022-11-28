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
			try
			{
				showOrder();
			}
			catch (Exception ex)
			{
				listBox1.DataSource = null;
				listBox1.Items.Add(ex.Message);
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			listBox1.DataSource = null;
			listBox1.DataSource = server.PrepareFood(txtClientName.Text);
		}

		public async void showOrder()
		{
			listBox1.Items.Add("Server start serving drinks first......");
			await Task.Delay(3000);
			listBox1.DataSource = server.ServeDrinks();
			await Task.Delay(9000);
			listBox1.DataSource = null;
			listBox1.Items.Add("Cook received foods and preparing it.....");
		}
	}
}