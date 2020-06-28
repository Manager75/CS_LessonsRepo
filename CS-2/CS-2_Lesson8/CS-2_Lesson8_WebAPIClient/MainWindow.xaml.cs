using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CS_2_Lesson8_WebAPIClient
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		static HttpClient client = new HttpClient();

		public MainWindow()
		{
			InitializeComponent();
			client.BaseAddress = new Uri("https://localhost:44307/");
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}

        static async Task<IEnumerable<Workers>> GetProductsAsync(string path)
        {
            IEnumerable<Workers> workers = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    workers = await response.Content.ReadAsAsync<IEnumerable<Workers>>();
                }
            }
            catch (Exception)
            {
            }
            return workers;
        }
        static async Task<Workers> GetProductAsync(string path)
        {
            Workers workers = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    workers = await response.Content.ReadAsAsync<Workers>();
                }
            }
            catch (Exception)
            {
            }
            return workers;
        }

		private void listWorkers_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{

		}

		private void cbEmployee_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
		{

		}

		private void cbDepartment_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{

		}

		private void AddWorker_Click(object sender, RoutedEventArgs e)
		{

		}

		private void DelWorker_Click(object sender, RoutedEventArgs e)
		{

		}

		private void EditWorker_Click(object sender, RoutedEventArgs e)
		{

		}

		private async void LoadWorkers_Click(object sender, RoutedEventArgs e)
		{
			IEnumerable<Workers> products = await GetProductsAsync(client.BaseAddress + "getlist");
			listWorkers.ItemsSource = products;
		}
	}
}
