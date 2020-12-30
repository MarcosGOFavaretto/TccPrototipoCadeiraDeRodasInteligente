using System;
using Android.Support.V7.App;
using Android.App;
using Android.OS;
using Xamarin.Essentials;
using Android.Bluetooth;
namespace PrototipoCadeiraDeRodas
{
    [Activity(Label = "SmartChair", Theme = "@style/SplashScreen", NoHistory = true, MainLauncher = false)]
    public class SplashScreen : AppCompatActivity
    {
        // DECLARANDO AS VARIÁVEIS GLOBAIS DA ATIVIDADE:
        double porcentagemBateria = 0;
        BluetoothAdapter bluetoothAdapter_objeto = null;
        BluetoothSocket bluetoothSocket_objeto = null;
        InformacoesCadeira informacoesCadeira_objeto = new InformacoesCadeira();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            bluetoothAdapter_objeto = BluetoothAdapter.DefaultAdapter;

            VerificacoesSeguranca();
        }

        // CRIANDO O MÉTODO QUE REALIZARÁ AS VERIFICAÇÕES DE SEGURANÇA PARA O FUNCIONAMENTO DA CADEIRA:
        void VerificacoesSeguranca()
        {
            if (!bluetoothAdapter_objeto.IsEnabled)
            {
                AlertaExigirBluetooth();
            }
            else
            {
                if (!bluetoothSocket_objeto.IsConnected)
                {
                    AlertaExigirConexaoBluetooth();
                }
                else
                {
                    if (!informacoesCadeira_objeto.GetCodigoVerificacaoCadeira().Equals("19*m17A@17#MG"))
                    {
                        AlertaDispostivoDesconhecido();
                    }
                    else
                    {
                        porcentagemBateria = Battery.ChargeLevel * 100;
                        if (porcentagemBateria <= 15)
                        {
                            AlertaNivelBateriaInsuficiente();
                        }
                        else
                        {
                            if (porcentagemBateria <= 30)
                            {
                                AlertaNivelBateriaBaixo();
                            }
                            else
                            {
                                if (informacoesCadeira_objeto.GetNivelBateria() * 100 <= 10)
                                {
                                    AlertaNivelBateriaCadeiraInsuficiente();
                                }
                                else
                                {
                                    System.Threading.Thread.Sleep(2000);
                                    StartActivity(typeof(TelaProntidao));
                                }
                            }
                        }
                    }
                }
            }
        }

        // MÉTODO QUE ALERTARÁ QUANDO O BLUETOOTH DO DISPOSITIVO ESTIVER DESATIVADO:
        void AlertaExigirBluetooth()
        {
            Android.App.AlertDialog.Builder alertDialog_objeto = new Android.App.AlertDialog.Builder(this);
            alertDialog_objeto.SetTitle("BLUETOOTH DESABILITADO");
            alertDialog_objeto.SetMessage("Por favor, habilite a conexão Bluetooth do seu aparelho! O aplicativo será encerrado!");
            alertDialog_objeto.SetNeutralButton("Entendi!", delegate
            {
                alertDialog_objeto.Dispose();
                Finish();
            });
            alertDialog_objeto.Show();
        }

        // MÉTODO QUE ALERTARÁ QUANDO O BLUETOOTH DO DISPOSITIVO ESTIVER LIGADO PORÉM DESCONECTADO:
        void AlertaExigirConexaoBluetooth()
        {
            Android.App.AlertDialog.Builder alertDialog_objeto = new Android.App.AlertDialog.Builder(this);
            alertDialog_objeto.SetTitle("BLUETOOTH DESCONECTADO");
            alertDialog_objeto.SetMessage("Por favor, conecte-se à cadeira de rodas antes de executar a aplicação! O aplicativo será encerrado!");
            alertDialog_objeto.SetNeutralButton("Entendi!", delegate
            {
                alertDialog_objeto.Dispose();
                Finish();
            });
            alertDialog_objeto.Show();
        }

        // MÉTODO QUE ALERTARÁ QUANDO O DISPOSITIVO CONECTADO NÃO FOR A CADEIRA DE RODAS:
        void AlertaDispostivoDesconhecido()
        {
            Android.App.AlertDialog.Builder alertDialog_objeto = new Android.App.AlertDialog.Builder(this);
            alertDialog_objeto.SetTitle("DISPOSITIVO NÃO RECONHECIDO");
            alertDialog_objeto.SetMessage("O dispositivo conectato não se trata da cadeira de rodas controlada por essa aplicação! O aplicativo será encerrado!");
            alertDialog_objeto.SetNeutralButton("Entendi!", delegate
            {
                alertDialog_objeto.Dispose();
                Finish();
            });
            alertDialog_objeto.Show();
        }

        // MÉTODO QUE ALERTARÁ QUANDO A BATERIA DO SMARTPHONE FOR INFERIOR A 15.1%:
        void AlertaNivelBateriaInsuficiente()
        {
            Android.App.AlertDialog.Builder alertDialog_objeto = new Android.App.AlertDialog.Builder(this);
            alertDialog_objeto.SetTitle("NÍVEL DE BATERIA INSUFICIENTE");
            alertDialog_objeto.SetMessage("O nível de bateria é insuficiente para manter a segurança de operação da cadeira de rodas, recarregue-o a cima de 15%");
            alertDialog_objeto.SetNeutralButton("Entendi!", delegate
            {
                alertDialog_objeto.Dispose();
                Finish();
            });
            alertDialog_objeto.Show();
        }

        // MÉTODO QUE ALERTARÁ QUANDO A BATERIA DO SMARTPHONE ESTIVER ENTRE 15.1% E 30%:
        void AlertaNivelBateriaBaixo()
        {
            Android.App.AlertDialog.Builder alertDialog_objeto = new Android.App.AlertDialog.Builder(this);
            alertDialog_objeto.SetTitle("NÍVEL DE BATERIA BAIXO!");
            alertDialog_objeto.SetMessage("Sua bateria está inferior a 30%, por favor, recarregue seu SMARTPHONE o mais rápido possível");
            alertDialog_objeto.SetNeutralButton("Irei carregar quando possível", delegate
            {
                alertDialog_objeto.Dispose();
                StartActivity(typeof(TelaProntidao));
            });
            alertDialog_objeto.Show();
        }

        // MÉTODO QUE ALERTARÁ QUANDO A BATERIA DA CADEIRA DE RODAS ESTIVER INFERIOR A 10%:
        void AlertaNivelBateriaCadeiraInsuficiente()
        {
            Android.App.AlertDialog.Builder alertDialog_objeto = new Android.App.AlertDialog.Builder(this);
            alertDialog_objeto.SetTitle("NÍVEL DE BATERIA DA CADEIRA INSUFICIENTE!");
            alertDialog_objeto.SetMessage("O nível de bateria da cadeira de rodas é insuficiente para operação.");
            alertDialog_objeto.SetNeutralButton("Ireir carregar quando possível", delegate
            {
                alertDialog_objeto.Dispose();
                Finish();
            });
            alertDialog_objeto.Show();
        }
    }
}