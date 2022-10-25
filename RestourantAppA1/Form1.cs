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
				resultBox.Items.Add("please enter correct quantity");
			newMenu = srv.NewRequest(quantity, menuItem);
			quantityOfOrder.Text = "";
		}

		private void CopyPreviousOrder_Click(object sender, EventArgs e)
		{

			try
			{
				newMenu = srv.CopyPreviousRequest();
				eggQualityResult.Text = srv.InspectEgg(newMenu);
			}
			catch (Exception ex)
			{
				resultBox.Items.Add(ex.Message);
			}
		}

		private void PrepareFood_Click(object sender, EventArgs e)
		{
			try
			{
				resultBox.Items.Add(srv.PrepareFood(newMenu));
				eggQualityResult.Text = srv.InspectEgg(newMenu);
			}
			catch (Exception ex)
			{
				eggQualityResult.Text = ex.Message;
				resultBox.Items.Add(ex.Message);
			}
		}
	}
}