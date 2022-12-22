using RestaurantApp5.classes;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RestaurantApp5
{
	public partial class Form1 : Form
	{
		Server server = null;

		public Form1()
		{
			InitializeComponent();
			server = new Server(Printer);
			comboBox1.DataSource = Enum.GetValues(typeof(listOfDrinks));
		}

		private void receiveBtn_Click(object sender, EventArgs e)
		{
			int chickenCount = 0;
			int eggCount = 0;
			string name = txtClientName.Text.Trim();

			if (name == "")
				listBox1.Items.Add("Incorrect name of customer");
			else if (!int.TryParse(txtChickenCount.Text, out chickenCount))
				listBox1.Items.Add("Please enter a correct value of chicken");
			else if (!int.TryParse(txtEggCount.Text, out eggCount))
				listBox1.Items.Add("Please enter a correct value of egg");
			else
			{
				listOfDrinks drink;
				Enum.TryParse(comboBox1.SelectedValue.ToString(), out drink);

				server.SubmitNewOrder(chickenCount, eggCount, name, drink);
			}
			txtChickenCount.Text = txtEggCount.Text = txtClientName.Text = "";
		}

		private void sendBtn_Click(object sender, EventArgs e)
		{
			try
			{
				server.SendToCook();
			}
			catch (Exception ex)
			{
				listBox1.Items.Add(ex.Message);
			}
		}

		public void Printer(string text)
		{
			listBox1.Items.Add(text);
		}
	}
}