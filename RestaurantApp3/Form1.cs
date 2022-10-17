using RestaurantApp3.Classes;

namespace RestaurantApp3
{
	public partial class Form1 : Form
	{


		Server server = new Server();
		public Form1()
		{
			InitializeComponent();
			comboBox1.DataSource = Enum.GetValues(typeof(drinksList));
		}

		private void receiveBtn_Click(object sender, EventArgs e)
		{
			//CR: It should give me an error if enter invalid quantity
			try
			{

				if (int.TryParse(chickentxt.Text, out int ChickenCount))
				{
					if (int.TryParse(eggtxt.Text, out int EggCount))
					{
						drinksList Drink;
						Enum.TryParse(comboBox1.SelectedValue.ToString(), out Drink);
						server.Receive(ChickenCount, EggCount, Drink);
					}
					else resutlListBox.Items.Add("Please enter a correct value of egg");
				}
				else resutlListBox.Items.Add("Please enter a correct value of chicken");
			}
			catch (Exception ex)
			{
				resutlListBox.Items.Clear();
				resutlListBox.Items.Add(ex.Message);
			}
			finally
			{
				chickentxt.Text = "";
				eggtxt.Text = "";
			}
		}

		private void sendBtn_Click(object sender, EventArgs e)
		{
			try
			{
				server.SendToCook();
			}
			catch (Exception ex)
			{
				resutlListBox.Items.Clear();
				resutlListBox.Items.Add(ex.Message);
			}
		}

		private void serveBtn_Click(object sender, EventArgs e)
		{
			try
			{
				resutlListBox.Items.Clear();
				foreach (var item in server.Serve())
				{
					resutlListBox.Items.Add(item);
				}
			}
			catch (Exception ex)
			{
				resutlListBox.Items.Clear();
				resutlListBox.Items.Add(ex.Message);
			}
		}
	}
}