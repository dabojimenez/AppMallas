//using AppMallas.View;
using AppMallas.Model;
using AppMallas.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace AppMallas
{
    public partial class MainPage : ContentPage
    {
        //globales 
        public static List<Malla> lstMallas = new List<Malla>();
        ObservableCollection<Malla> mallas = new ObservableCollection<Malla>();
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageVM(Navigation);
        }
        /*
        private void btnScan_Clicked(object sender, EventArgs e)
        {
            //EscanearCB();
        }
        /*
        private async void EscanearCB()
        {
            var scan = new ZXingScannerPage();
            scan.Title = "Escanear Codigo de Barras";
            await AppMallas.App.Current.MainPage.Navigation.PushModalAsync(scan);

            scan.OnScanResult += (result) =>
            {
                scan.IsScanning = false;
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await AppMallas.App.Current.MainPage.Navigation.PopModalAsync();
                    //idCodigoBarras = result.Text;
                    lblCodigoEscaneado.Text = result.Text;
                    if (!string.IsNullOrEmpty(result.Text))
                    {
                        
                    }

                });
            };
        }
        
        private void btnAgregar_Clicked(object sender, EventArgs e)
        {
            /*
            if (!string.IsNullOrEmpty(etrCantidadTallos.Text) && !string.IsNullOrEmpty(lblCodigoEscaneado.Text))
            {
                string codigoAGuardar;
                string subCadenaCB = lblCodigoEscaneado.Text.Substring(0, 11);
                int valor25 = Convert.ToInt32(etrCantidadTallos.Text)*25;
                if (valor25<99)
                {
                    codigoAGuardar = subCadenaCB + "0" + valor25;
                    mallas.Add(new Malla { CodigoBarras = codigoAGuardar });
                    //lstMallas.Add(new Malla { CodigoBarras = codigoAGuardar});
                }
                else
                {
                    codigoAGuardar = subCadenaCB + valor25;
                    mallas.Add(new Malla { CodigoBarras = codigoAGuardar });
                    //lstMallas.Add(new Malla { CodigoBarras = codigoAGuardar });
                }
                
                //lstCodigoBarras.ItemsSource = lstMallas;
                //lstCodigoBarras.ItemsSource = mallas;
                //lstCodigoBarras.EndRefresh();
               // st.Children.Add(lstCodigoBarras);
                
                return;
            }
            DisplayAlert("Administracion de Mallas", "Existen campos vacios", "Ok");
            
        }
        */
        
    }
}
