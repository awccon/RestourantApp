using RestourantApp.Classes;
namespace RestourantApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

         // This is to get a value of menu item or checkbox
        object newObj;

        Employee employee = new Employee(); // This class was declare to use a main methods

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void submitButton_Click(object sender, EventArgs e) // This is a New Request button
        {
            string menuValue = "Chicken";
            if (radioEgg.Checked)
            {
                menuValue = "Egg";
            }

            int orderQuantity = 0;
            var quantityText = textQuantity.Text;
            if (Int32.TryParse(quantityText, out orderQuantity) && orderQuantity != 0)
            {
                if (orderQuantity > 0)
                {
                    newObj = employee.NewRequest(orderQuantity, menuValue);
                    string? inspectResult = employee.Inspect(newObj);
                    lblEggQuality.Text = inspectResult;
                }
                else txtResult.Text = "Error: Order quantity is invalid, you entered zero or negative number of quantity. Please enter a correct number";
                submitButton.Enabled = false;
            }
            else
            { 
                MessageBox.Show("Please enter correct quantity!");
            }
            textQuantity.Text = "";
            txtResult.Text = $"You choise {orderQuantity} {menuValue}";
        }

        private void copyButton_Click(object sender, EventArgs e) // This is a copy previous button
        {
            try
            {
                newObj = employee.CopyRequest();

                if (newObj != null && (newObj is ChickenOrder chicken))
                {
                    lblEggQuality.Text = "No inspection requared";
                    txtResult.Text = "Precious order copied";
                    txtResult.Text += Environment.NewLine + $"Previous order is {chicken.GetQuantity()} Chicken";
                }
                else
                {
                    var egg = newObj as EggOrder;
                    lblEggQuality.Text = egg.GetQuality().ToString();
                    txtResult.Text = "Precious order copied";
                    txtResult.Text += Environment.NewLine + $"Previous order is {egg.GetQuantity()} Egg";
                }
            }
            catch (Exception ex)
            {
                txtResult.Text = ex.Message;
            }
            
        }

        private void prepareButton_Click(object sender, EventArgs e)
        {
            txtResult.Text = employee.PrepareFood(newObj); // This is a final button to prepare a food
            _formReset();
        }


        private void _formReset()  // This method used to reset a forms
        {
            lblEggQuality.Text = "0";
            textQuantity.Text = "";
            submitButton.Enabled=true;
        }
    }
}