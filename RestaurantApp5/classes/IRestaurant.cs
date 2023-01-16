namespace RestaurantApp5.classes
{
	internal interface IRestaurant
	{
		public Action<string> Message { get; }
		public void SubmitNewOrder(int ChickenCount, int EggCount, string Name, listOfDrinks drink);
		public void SendToCook();
	}
}