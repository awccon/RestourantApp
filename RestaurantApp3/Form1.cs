using RestaurantApp3.Classes;

namespace RestaurantApp3
{
    public partial class Form1 : Form
    {


        Server server = new Server();
        public Form1()
        {
            InitializeComponent();
            comboBox1.DataSource = Enum.GetValues(typeof(drinksList));
        }

        private void receiveBtn_Click(object sender, EventArgs e)
        {
            //CR: It should give me an error if enter invalid quantity
            try
            {
                int chickenCount = 0;
                int eggCount = 0;
                if (!int.TryParse(chickentxt.Text, out chickenCount))
                {
                    resutlListBox.Items.Add("Please enter a correct value of chicken");
                }
                if (!int.TryParse(eggtxt.Text, out eggCount))
                {
                    resutlListBox.Items.Add("Please enter a correct value of egg");
                }

                drinksList Drink;
                Enum.TryParse(comboBox1.SelectedValue.ToString(), out Drink);
                server.Receive(chickenCount, eggCount, Drink);

            }
            catch (Exception ex)
            {
                resutlListBox.Items.Clear();
                resutlListBox.Items.Add(ex.Message);
            }
            finally
            {
                chickentxt.Text = "";
                eggtxt.Text = "";
            }
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            try
            {
                server.SendToCook();
            }
            catch (Exception ex)
            {
                resutlListBox.Items.Clear();
                resutlListBox.Items.Add(ex.Message);
            }
        }

        private void serveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                resutlListBox.Items.Clear();
                var array = server.Serve();

                foreach (var item in array)
                {
                    resutlListBox.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                resutlListBox.Items.Clear();
                resutlListBox.Items.Add(ex.Message);
            }
        }
    }
}