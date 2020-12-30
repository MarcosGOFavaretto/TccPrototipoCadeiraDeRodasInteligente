using System;
using Android.App;
using Android.OS;
using System.IO;
using Android.Bluetooth;
using System.Threading.Tasks;
namespace PrototipoCadeiraDeRodas.Resources
{
    [Activity(Label = "UtilizadesBluetooth")]
    public class UtilidadesBluetooth : Activity
    {
        // DECLARANDO AS VARIÁVEIS GLOBAIS DA ATIVIDADE:
        BluetoothSocket bluetoothSocket_objeto = null;
        Stream streamEntrada = null;
        Stream streamSaida = null;
        string[] dadosEntradaArray = new string[6];
        string dadosEntrada;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        // CRIANDO MÉTODO QUE IRÁ ENVIAR AS INFORMAÇÕES PARA A CADEIRA DE RODAS:
        public void EnviarInformacoes(Java.Lang.String informacaoParaEnviar)
        {
            try
            {
                streamSaida = bluetoothSocket_objeto.OutputStream;
            }
            catch (System.Exception erro_IsntanciarStreamSaida)
            {
                System.Console.WriteLine("Problema ao tentar instanciar a variável 'streamSaida', ERRO: " + erro_IsntanciarStreamSaida);
            }
            byte[] saidaDeDados = informacaoParaEnviar.GetBytes();

            try
            {
                streamSaida.Write(saidaDeDados, 0, saidaDeDados.Length);
            }
            catch (System.Exception erro_EnviarInformacoes)
            {
                System.Console.WriteLine("Problema ao tentar enviar as informações, ERRO: " + erro_EnviarInformacoes);
            }
        }

        // CRIANDO MÉTODO QUE IRÁ RECEBER AS INFORMAÇÕES PARA A CADEIRA DE RODAS:
        public string[] ReceberInformacoes()
        {
            //try
            //{
            //    streamEntrada = bluetoothSocket_objeto.InputStream;

            //}
            //catch (System.IO.IOException erro_IsntanciarStreamEntrada)
            //{
            //    System.Console.WriteLine("Problema ao tentar instaciar a variável 'streamEntrada', ERRO: " + erro_IsntanciarStreamEntrada);
            //}
            //Task.Factory.StartNew(() =>
            //{
            //    byte[] entradaDeDados = new byte[1024];
            //    int bytes;
            //    while (true)
            //    {
            //        try
            //        {
            //            bytes = streamEntrada.Read(entradaDeDados, 0, entradaDeDados.Length);
            //            if (bytes > 0)
            //            {
            //                RunOnUiThread(() =>
            //                {
            //                    this.dadosEntrada = System.Text.Encoding.ASCII.GetString(entradaDeDados);
            //                    for (int i = 0; i == 5; i++)
            //                    {
            //                        dadosEntradaArray[i] = dadosEntrada;
            //                    }
            //                });
            //            }
            //        }
            //        catch (Java.IO.IOException erro_ReceberInformacoes)
            //        {
            //            System.Console.WriteLine("Problema ao tentar receber as informações, ERRO: " + erro_ReceberInformacoes);
            //        }
            //    }
            //});
            return dadosEntradaArray;
        }
    }
}