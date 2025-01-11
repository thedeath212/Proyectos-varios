using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Repaso
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InicioPage : ContentPage
	{
		public InicioPage ()
		{
			InitializeComponent ();

			Dm_btnver.Clicked += (sender, e) =>
			{
				Navigation.PushAsync(new PaginaListaContacto());
			};
		}
	}
}