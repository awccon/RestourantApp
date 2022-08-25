using RestourantApp.Classes;
namespace RestourantApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        object newObj;
        Employee employee = new Employee();

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string menuValue = "Chicken";
            if (radioEgg.Checked)
            {
                menuValue = "Egg";
            }

            int orderQuantity;
            var quantityText = textQuantity.Text;
            if (Int32.TryParse(quantityText, out orderQuantity) && orderQuantity != 0)
            {
                
                 if (orderQuantity > 0)
                 {
                    try
                    {
                        newObj = employee.NewRequest(orderQuantity, menuValue);
                    }
                    catch (Exception ex)
                    {
                        txtResult.Text = ex.Message;
                    } 
                    string? inspectResult = employee.Inspect(newObj);
                    lblEggQuality.Text = inspectResult;
                    
                 }
                 else txtResult.Text = "Error: Order quantity is invalid, you entered zero or negative number of quantity. Please enter a correct number";
           }
            else
            {
                MessageBox.Show("Please enter correct quantity!");
            }
            textQuantity.Text = "";
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            try
            {
                newObj = employee.CopyRequest();
            }
            catch (Exception ex)
            {
                txtResult.Text = ex.Message;
            }

        }

        private void prepareButton_Click(object sender, EventArgs e)
        {
            txtResult.Text = employee.PrepareFood(newObj);
            _formReset();
        }

        // This method reset a forms inputs
        private void _formReset()
        {
            lblEggQuality.Text = "0";
            textQuantity.Text = "";
        }
    }
}