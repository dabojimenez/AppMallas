using AppMallas.Model;
using AppMallas.VistaModelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace AppMallas.ViewModel
{
    public class MainPageVM: BaseViewModel
    {
        #region VARIABLES
        string _LblCodigoBarras;
        string _Texto;
        string _CantidadTallos;
        ObservableCollection<Malla> _ListaMallas = new ObservableCollection<Malla>();
        Malla _Mallas;
        #endregion
        #region CONSTRUCTOR
        public MainPageVM(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        public string CantidadTallos
        {
            get { return _CantidadTallos; }
            set { SetValue(ref _CantidadTallos, value); }
        }
        public string LblCodigoBarras
        {
            get { return _LblCodigoBarras; }
            set { SetValue(ref _LblCodigoBarras, value); }
        }
        public ObservableCollection<Malla> ListaMallas
        {
            get { return _ListaMallas; }
            set { SetValue(ref _ListaMallas, value); }
        }
        Malla Mallas
        {
            get { return _Mallas; }
            set { SetValue(ref _Mallas, value); }
        }
        #endregion
        #region PROCESOS
        public async Task ProcesoAsyncrono()
        {

        }
        public async Task AlertAsync()
        {
            await DisplayAlert("Administracion de Mallas", "Existen campos vacios", "Ok");
        }
        private async Task EscanearCB()
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
                    LblCodigoBarras = result.Text;
                    //if (!string.IsNullOrEmpty(result.Text))
                    //{
                    //    //_LblCodigoBarras = result.Text;
                    //}

                });
            };
        }
        public void ProcesoSimple()
        {

        }
        public async Task AgregarCodigoBarras()
        {
            if (!string.IsNullOrEmpty(CantidadTallos) && !string.IsNullOrEmpty(LblCodigoBarras))
            {
                if (Convert.ToInt32(CantidadTallos) >= 1 && Convert.ToInt32(CantidadTallos) <= 39)
                {
                    string codigoAGuardar;
                    string subCadenaCB = LblCodigoBarras.Substring(0, 11);
                    int valor25 = Convert.ToInt32(CantidadTallos) * 25;
                    if (valor25 < 99)
                    {
                        codigoAGuardar = subCadenaCB + "0" + valor25;
                        ListaMallas.Add(new Malla { CodigoBarras = codigoAGuardar });
                    }
                    else
                    {
                        codigoAGuardar = subCadenaCB + valor25;
                        ListaMallas.Add(new Malla { CodigoBarras = codigoAGuardar });
                    }
                    return;
                }
                await DisplayAlert("Administracion de Mallas", "Valores a ingresar en un rnago de [1-39]", "Ok");
                return;
            }
            await DisplayAlert("Administracion de Mallas", "Existen campos vacios", "Ok");
        }
        #endregion
        #region COMANDOS
        public ICommand ProcesoAsyncommand => new Command(async () => await ProcesoAsyncrono());
        public ICommand EscanearCBACommand => new Command(async () => await EscanearCB());
        public ICommand AlertaCommand => new Command(async () => await AlertAsync());
        public ICommand AddCBCommand => new Command(async () => await AgregarCodigoBarras());
        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        //public ICommand AgregarCodigoBarrasCommand => new Command(AgregarCodigoBarras);

        #endregion









        //-----------------------OTROS PROCESOS
        public Command AddMallaCommand { get; set; }
        //public List<Malla> Mallas { get; set; }
        public MainPageVM()
        {
            //MallasRepository repository = new MallasRepository();
            //Mallas = repository.GetAll();
            AddMallaCommand = new Command(ObtenerMallas);
            //Mallas = new List<Malla>();
        }

        #region PROCESOS
        public void ObtenerMallas()
        {

        }
        #endregion
        public bool SaveCodigoBarras()
        {
            return false;
        }

        #region COMANDOS

        #endregion

    }
}
