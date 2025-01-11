using System;
using Xamarin.Forms;
using Gps.Datos;
using System.IO;
using Plugin.Geolocator;

namespace Gps
{
    public partial class MainPage : ContentPage
    {
        LocationDatabase locationDatabase;

        public MainPage()
        {
            InitializeComponent();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Examen.db3");
            locationDatabase = new LocationDatabase(dbPath);
            CargarUbicaciones();
        }
        private async void CargarUbicaciones()
        {
            var ubicaciones = await locationDatabase.GetLocationsAsync();
            ubicacionesListView.ItemsSource = ubicaciones;
        }

        private async void gps_Clicked(object sender, EventArgs e)
        {
            if (!CrossGeolocator.IsSupported)
            {
                await DisplayAlert("ERROR", "Geolocation not supported", "OK");
                return;
            }

            if (!CrossGeolocator.Current.IsGeolocationEnabled || !CrossGeolocator.Current.IsGeolocationAvailable)
            {
                await DisplayAlert("ERROR", "Location services are disabled", "OK");
                return;
            }

            CrossGeolocator.Current.PositionChanged += Current_PositionChanged;
            await CrossGeolocator.Current.StartListeningAsync(TimeSpan.FromSeconds(2), 0.5);
        }

        private async void GuardarUbicacion_Clicked(object sender, EventArgs e)
        {
            try
            {
                var position = await CrossGeolocator.Current.GetPositionAsync();
                var ubicacion = new Ubicacion
                {
                    Latitude = position.Latitude,
                    Longitude = position.Longitude,
                    Altitude = position.Altitude
                };
                await locationDatabase.SaveLocationAsync(ubicacion);

                await DisplayAlert("Guardado", "La ubicación ha sido guardada correctamente", "OK");

                // Recargar las ubicaciones después de guardar una nueva
                CargarUbicaciones();
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", $"Error al guardar la ubicación: {ex.Message}", "OK");
            }
        }

        private async void Current_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            try
            {
                var position = e.Position;
                Device.BeginInvokeOnMainThread(() =>
                {
                    Latitud.Text = position.Latitude.ToString();
                    Longitud.Text = position.Longitude.ToString();
                    Altura.Text = position.Altitude.ToString();
                });
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", $"Error getting location: {ex.Message}", "OK");
            }
        }
    }
}
