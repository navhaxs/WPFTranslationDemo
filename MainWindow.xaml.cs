using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFLocalizeExtension.Engine;
using WPFLocalizeExtension.Extensions;

namespace WpfApplication1
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (LocalizeDictionary.Instance.Culture.EnglishName != "French")
            {
                this.SwitchCulture("fr");
            }
            else
            {
                this.SwitchCulture("en");
            }

        }


        /// <summary>
        /// Switches the localization culture.
        /// </summary>
        /// <param name="culture">ISO code of the new culture.</param>
        private void SwitchCulture(string culture)
        {
            CultureInfo ci = CultureInfo.InvariantCulture;
            try
            {
                ci = new CultureInfo(culture);
            }
            catch (CultureNotFoundException)
            {
                try
                {
                    // Try language without region
                    ci = new CultureInfo(culture.Substring(0, 2));
                }
                catch (Exception)
                {
                    ci = CultureInfo.InvariantCulture;
                }
            }
            finally
            {
                LocalizeDictionary.Instance.Culture = ci;
                togglelang.Content = ci.EnglishName;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // TODO: Not working?
            string message = GetUIString("MessageConfirmDelete1") + " \"" + Pic1.Text + "\" " + GetUIString("MessageConfirmDelete2") + " \"" + GetUIString("AlbumLabel") + "\"?";
            MessageBox.Show(message);
        }

        public string GetUIString(string key)
        {
            string uiString;
            LocTextExtension locExtension = new LocTextExtension(key);
            locExtension.ResolveLocalizedValue(out uiString);
            return uiString;
        }
    }
}
