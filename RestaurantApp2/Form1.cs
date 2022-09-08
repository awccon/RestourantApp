using RestaurantApp2.Classes;
namespace RestaurantApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Employee employee = new Employee();

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxList();
        }



        private void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                employee.NewRequest(textBoxChicken.Text, textBoxEgg.Text, drinksComBox.Text);
            }
            catch (Exception ex)
            {
                resultsListBox.Items.Clear();
                resultsListBox.Items.Add(ex.Message);
            }
        }

        /// <summary>
        /// This function used to iterate all drinks list and assign it to ComboBox
        /// </summary>
        private void comboBoxList()
        {
            drinksComBox.Text = drinksItem.NoDrink.ToString();
            var drinksList = Enum.GetValues(typeof(drinksItem));
            foreach (var drinks in drinksList)
            {
                drinksComBox.Items.Add(drinks);
            }
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            employee.SendCustomerRequest();
        }
    }
}