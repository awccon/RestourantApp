namespace RestaurantAppA3
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		Server server = new Server();

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				server.GetNewOrder(1, 1, Drinks.Tea);
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