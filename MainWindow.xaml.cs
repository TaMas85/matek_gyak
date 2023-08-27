using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace mat_gyak
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void ujsz(object sender, RoutedEventArgs e)
		{
			Random r = new Random();
			szore.Content = r.Next(2, 10);
			szorm.Content = r.Next(2, 10);
			eqszor.IsEnabled = true;
			mentes.IsEnabled = true;
		}

		private void ujo(object sender, RoutedEventArgs e)
		{
			Random r = new Random();
			int valt = r.Next(2, 10);
			osztm.Content = valt;
			oszte.Content = (r.Next(2, 10)) * valt;
			eqoszt.IsEnabled = true;
			mentes.IsEnabled = true;

		}

		private void eqsz(object sender, RoutedEventArgs e)
		{
			int szam1 = Convert.ToInt32(szore.Content);
			int szam2 = Convert.ToInt32(szorm.Content);

			if ((szam1 * szam2) == Convert.ToInt32(szorered.Text)) 
			{
				joszamszor.Content = Convert.ToInt32(joszamszor.Content) + 1;
			}
			else
			{
				MessageBox.Show("Nem jó a megoldás!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			eqszor.IsEnabled = false;
		}

		private void eqosz(object sender, RoutedEventArgs e)
		{
			int szam3 = Convert.ToInt32(oszte.Content);
			int szam4 = Convert.ToInt32(osztm.Content);

			if ((szam3 / szam4) == Convert.ToInt32(osztered.Text))
			{
				joszamoszt.Content = Convert.ToInt32(joszamoszt.Content) + 1;
			}
			else
			{
				MessageBox.Show("Nem jó a megoldás!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			eqoszt.IsEnabled = false;
		}

		private void ment(object sender, RoutedEventArgs e)
		{

			DateTime most = DateTime.Now;
			string path = @"c:\mat_log";
			string fileName = "log.txt";

			string filePath = System.IO.Path.Combine(path, fileName);

			using (StreamWriter wr = new StreamWriter(filePath, true))
			{
				wr.WriteLine(most + "\n" + nevek.Text + "  Szorzás jó eredmények: " + joszamszor.Content + "  Osztás jó eredmények: " + joszamoszt.Content);
			}
			mentes.IsEnabled = false;
			MessageBox.Show("A mentés megtörtént!", "Üzenet", MessageBoxButton.OK, MessageBoxImage.Information);
		}

		private void info(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("A mentés miatt létre kell hozni ezt a struktúrát: \nC:\\\\mat_log\\log.txt", "Információ", MessageBoxButton.OK, MessageBoxImage.Information);
		}
	}
}
