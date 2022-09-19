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
            try
            {
                server.SubmitRequest(textBoxChicken.Text,textBoxEgg.Text, drinksComBox.Text);
                ResetForm();
            }
            catch (Exception ex)
            {
                ResetForm();
                resultsListBox.Items.Clear();
                resultsListBox.Items.Add(ex.Message);
            }
        }
        private void sendBtn_Click(object sender, EventArgs e)
        {
            try
            {
                eggQualityLb.Text = server.SendCustomerRequest();
            }
            catch (Exception ex)
            {
                resultsListBox.Items.Add(ex.Message);
            }
        }
        private void serveBtn_Click(object sender, EventArgs e)
        {
            ResetForm();
            //This should happen in the Server's serve method. We don't want to deal with this here. We just call the server.Serve method
            try
            {
                foreach (var item in server.ServeCustomer())
                {
                    resultsListBox.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                resultsListBox.Items.Add(ex.Message);
            }
        }
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