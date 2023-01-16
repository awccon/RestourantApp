using RestaurantApp5.classes;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RestaurantApp5
{
	public partial class Form1 : Form
	{
		private IRestaurant restaurant = null;

		public Form1()
		{
			InitializeComponent();
			restaurant = new Restaurant(Printer);
			comboBox1.DataSource = Enum.GetValues(typeof(listOfDrinks));
		}

		private void receiveBtn_Click(object sender, EventArgs e)
		{
			int chickenCount = 0;
			int eggCount = 0;
			string name = txtClientName.Text.Trim();

			if (name == "")
				Printer("Incorrect name of customer");
			else if (!int.TryParse(txtChickenCount.Text, out chickenCount))
				Printer("Please enter a correct value of chicken");
			else if (!int.TryParse(txtEggCount.Text, out eggCount))
				Printer("Please enter a correct value of egg");
			else
			{
				listOfDrinks drink;
				Enum.TryParse(comboBox1.SelectedValue.ToString(), out drink);
				try
				{
					restaurant.SubmitNewOrder(chickenCount, eggCount, name, drink);
				}
				catch (Exception ex)
				{
					Printer(ex.Message);
				}
			}
			txtChickenCount.Text = txtEggCount.Text = txtClientName.Text = "";
		}

		private void sendBtn_Click(object sender, EventArgs e)
		{
			try
			{
				restaurant.SendTableToCook();
			}
			catch (Exception ex)
			{
				Printer(ex.Message);
			}
		}

		public void Printer(string text)
		{
			listBox1.Invoke(
				() =>
				{
					listBox1.Items.Add(text);
				});
		}
	}
}