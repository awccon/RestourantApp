namespace RestaurantAppA3
{
	public partial class Form1 : Form
	{
		Server server = new Server();

		public Form1()
		{
			InitializeComponent();
			comboBox1.DataSource = Enum.GetValues(typeof(listOfDrinks));
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				listOfDrinks drinkItem;
				Enum.TryParse(comboBox1.SelectedItem.ToString(), out drinkItem);
				server.GetNewOrder(int.Parse(textBox1.Text), int.Parse(textBox2.Text), drinkItem);
				listBox1.Items.Clear();
				textBox1.Text = "";
				textBox2.Text = "";
			}
			catch (Exception ex)
			{
				listBox1.Items.Add(ex.Message);
			}

		}

		private void button2_Click(object sender, EventArgs e)
		{
			server.SendToCook();
			listBox1.Items.Clear();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			listBox1.Items.AddRange(server.PrepareFood());
		}
	}
}