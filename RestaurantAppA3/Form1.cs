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
			server.GetNewOrder(1, 1, Drinks.Tea);

		}

		private void button2_Click(object sender, EventArgs e)
		{
			server.PrepareFood();
		}
	}
}