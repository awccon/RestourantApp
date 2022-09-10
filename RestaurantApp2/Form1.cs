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
            textBoxChicken.Text = "0";
            textBoxEgg.Text = "0";
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
        }

        /// <summary>
        /// This function used to iterate all drinks list and assign it to ComboBox
        /// </summary>
        private void comboBoxList()
        {

            //drinksComBox.DataSource = Enum.GetNames(typeof(menuItem));
            var drinksList = Enum.GetNames(typeof(menuItem));
            for (int i = 0; i < drinksList.Length - 2; i++)
            {
                drinksComBox.Items.Add(drinksList[i]);
            }
            
        }

        // This button use for send menu items to the cook
        private void sendBtn_Click(object sender, EventArgs e)
        {
            server.SendCustomerRequest();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < server.orderStore.Length; i++)
            {
                foreach (var order in server.orderStore[i])
                {
                    resultsListBox.Items.Add(order);
                }
            }
        }
    }
}