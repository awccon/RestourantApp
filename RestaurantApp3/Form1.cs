using RestaurantApp3.Classes;

namespace RestaurantApp3
{
	public partial class Form1 : Form
	{
		Server srv = new Server();
		public Form1()
		{
			InitializeComponent();
			comboBox1.DataSource = Enum.GetValues(typeof(drinksList));
		}

		private void receiveBtn_Click(object sender, EventArgs e)
		{
			try
			{
				drinksList drinkStatus;
				int.TryParse(chickentxt.Text, out int ch);
				int.TryParse(eggtxt.Text, out int egg);
				Enum.TryParse(comboBox1.SelectedValue.ToString(), out drinkStatus);
				srv.Receive(ch, egg, drinkStatus);
				chickentxt.Text = "";
				eggtxt.Text = "";
			}
			catch (Exception ex)
			{
				resutlListBox.Items.Clear();
				resutlListBox.Items.Add(ex.Message);
			}
		}

		private void sendBtn_Click(object sender, EventArgs e)
		{
			try
			{
				srv.Obtain();
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
				foreach (var item in srv.Serve())
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