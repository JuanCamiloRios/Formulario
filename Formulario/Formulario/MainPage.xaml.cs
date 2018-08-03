using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Formulario
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}
        private async Task<bool> validarformulario()
        {
            if (String.IsNullOrWhiteSpace(UserName.Text))
            {
                await this.DisplayAlert("Advertencia", "El caompo del nombre es obligatorio", "Ok");
                return false;
            }
            else if (!UserName.Text.ToCharArray().All(Char.IsLetter))
            {
                await this.DisplayAlert("Advertencia", "Tu informacion contiene nùmeros", "Ok");
                return false;
            }
            else
            {
                string caractEspecial = @"^[^ ][a-zA-Z]+[^ ]$";
                bool resultado = Regex.IsMatch(UserName.Text,caractEspecial,RegexOptions.IgnoreCase);


            }
            return true;
        }
        async void ClienteBTF_Clicked(object sender, EventArgs e)
        {
            if (await validarformulario())
            {
                await DisplayAlert("Existo", "todos los campos cumplieron las validaciones","ok");
            }
        }
    }
}
