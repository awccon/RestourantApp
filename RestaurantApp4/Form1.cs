namespace RestaurantApp4
{
	public partial class Form1 : Form
	{
		Server server = new Server();
		public Form1()
		{
			InitializeComponent();
			server.SubmitNewOrder(new Chicken(), "Akmal", listOfDrinks.Tea);
			server.SubmitNewOrder(new Chicken(), "Behruz", listOfDrinks.CocaCola);
			server.SubmitNewOrder(new Egg(), "Akmal", listOfDrinks.Tea);
			server.SubmitNewOrder(new Chicken(), "Akmal", listOfDrinks.Pepsi);
			server.SubmitNewOrder(new Egg(), "Scott", listOfDrinks.CocaCola);
			server.SubmitNewOrder(new Chicken(), "Abbos", listOfDrinks.Tea);
			server.SubmitNewOrder(new Egg(), "Dilshod", listOfDrinks.Pepsi);
			server.SubmitNewOrder(new Chicken(), "Akmal", listOfDrinks.Tea);

		}
	}
}