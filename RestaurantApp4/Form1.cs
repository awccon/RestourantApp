namespace RestaurantApp4
{
	public partial class Form1 : Form
	{
		Server server = new Server();
		public Form1()
		{
			InitializeComponent();
			server.SubmitNewOrder(1, 2, "Akmal", listOfDrinks.Tea);
			server.SubmitNewOrder(1, 2, "Behruz", listOfDrinks.CocaCola);
			server.SubmitNewOrder(1, 2, "Akmal", listOfDrinks.Tea);
			server.SubmitNewOrder(1, 2, "Behruz", listOfDrinks.Pepsi);
			server.SubmitNewOrder(1, 2, "Scott", listOfDrinks.CocaCola);
			server.SubmitNewOrder(1, 2, "Abbos", listOfDrinks.Tea);
			server.SubmitNewOrder(1, 2, "Dilshod", listOfDrinks.Pepsi);
			server.SubmitNewOrder(1, 2, "Akmal", listOfDrinks.Tea);
			server.SubmitNewOrder(1, 2, "Doniyor", listOfDrinks.Tea);
			server.SubmitNewOrder(1, 2, "Glenn", listOfDrinks.Tea);
			server.SubmitNewOrder(1, 2, "Muhammad", listOfDrinks.Tea);

			server.TableTest();
		}
	}
}