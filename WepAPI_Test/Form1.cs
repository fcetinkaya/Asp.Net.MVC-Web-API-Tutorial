using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WepAPI_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:59782/");
            HttpResponseMessage response = await client.GetAsync("api/city/"+IdBox.Text);
            string result = await response.Content.ReadAsStringAsync();
            richTextBox1.Text = result;
        }
    }
}
