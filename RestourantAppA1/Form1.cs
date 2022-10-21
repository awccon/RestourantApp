namespace RestourantAppA1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		Server srv = new Server();
		object? newMenu = null;

		private void SubmitOrder_Click(object sender, EventArgs e)
		{
			string menuItem = "Egg";
			int quantity;
			if (ChickenRadio.Checked)
				menuItem = "Chicken";
			if (!Int32.TryParse(quantityOfOrder.Text, out quantity) && quantity == 0)
				throw new Exception("please enter correct quantity");
			newMenu = srv.NewRequest(quantity, menuItem);
		}

		private void CopyPreviousOrder_Click(object sender, EventArgs e)
		{
			newMenu = srv.CopyPreviousRequest();
			try
			{
				srv.InspectEgg(newMenu);
			}
			catch (Exception ex)
			{
				eggQualityResult.Text = ex.Message;
			}
		}

		private void PrepareFood_Click(object sender, EventArgs e)
		{
			try
			{
				resultBox.Items.Add(srv.PrepareFood(newMenu));
				eggQualityResult.Text = srv.InspectEgg(newMenu).ToString();
			}
			catch (Exception ex)
			{
				resultBox.Items.Add(ex.Message);
			}
		}
	}
}