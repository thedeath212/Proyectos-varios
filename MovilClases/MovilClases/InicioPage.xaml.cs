using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovilClases
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InicioPage : ContentPage
	{
		public InicioPage ()
		{
			InitializeComponent ();
		}

        private void btn_calcular_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Su edad es: ", "{txt_edad.Text}", "OK");
            //DisplayAlert(" ", "Su edad es: "+ txt_edad.Text,"OK");
            return;
        }
    }
}