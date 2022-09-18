using RestaurantApp2.Classes;
namespace RestaurantApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Server server = new Server();

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxList();
            ResetForm();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            int chickenQuantity, eggQuantity;
            if (Int32.TryParse(textBoxChicken.Text, out chickenQuantity) && Int32.TryParse(textBoxEgg.Text, out eggQuantity))
            {
                try
                {
                    server.SubmitRequest(chickenQuantity, eggQuantity, drinksComBox.Text);
                }
                catch (Exception ex)
                {
                    resultsListBox.Items.Clear();
                    resultsListBox.Items.Add(ex.Message);
                }
            }
            ResetForm();
        }

        
        // This button use for send menu items to the cook
        private void sendBtn_Click(object sender, EventArgs e)
        {
            eggQualityLb.Text = server.SendCustomerRequest();
        }

        private void serveBtn_Click(object sender, EventArgs e)
        {
            //This should happen in the Server's serve method. We don't want to deal with this here. We just call the server.Serve method
            //for (int i = 0; i < server.orderStore.Length; i++)
            //{
            //    resultsListBox.Items.Add(server.ServeCustomer(i));
            //}

            //for (int i = 0; i < server.orderStore.Length; i++)
            //{
            //    Array.Clear(server.orderStore[i], 0, server.orderStore[i].Length);
            //}
            foreach (var item in server.ServeCustomer())
            {
                resultsListBox.Items.Add(item);
            }
            //resultsListBox.Items.Add("Please enjoy your food!");
        }

        /// <summary>
        /// This function used to iterate all drinks list and assign it to ComboBox
        /// </summary>
        private void comboBoxList()
        {
            drinksComBox.Text = menuItem.NoDrink.ToString();
            var drinksList = Enum.GetNames(typeof(menuItem));
            for (int i = 0; i < drinksList.Length - 2; i++)
            {
                drinksComBox.Items.Add(drinksList[i]);
            }

        }

        private void ResetForm()
        {
            textBoxChicken.Text = "0";
            textBoxEgg.Text = "0";
            resultsListBox.Items.Clear();
        }

    }
}