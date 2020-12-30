using System;
using Android.Support.V7.App;
using Android.App;
using Android.OS;
using Android.Widget;
namespace PrototipoCadeiraDeRodas
{
    [Activity(Label = "PASSOS DE SEGURANÇA", Theme = "@style/AppThemeDarkActionBar", NoHistory = true, MainLauncher = true)]
    public class TelaProntidao : AppCompatActivity
    {
        // DECLARANDO AS VARIÁVEIS GLOBAIS DA ATIVIDADE:
        Button btnPreparado_;
        DefinicoesUsuario definicoesUsuarios_objeto = new DefinicoesUsuario();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.tela_prontidao);
            btnPreparado_ = FindViewById<Button>(Resource.Id.btnPreparado);
            btnPreparado_.Click += BtnPreparado__Click;
            AlertaInserirTelefoneEmergencia();
        }

        // MÉTODO QUE ALERTARÁ UMA MENSAGEM EXIGINDO O TELEFONE DE EMERGÊNCIA DO USUÁRIO:
        private void AlertaInserirTelefoneEmergencia()
        {
            //if (definicoesUsuarios_objeto.GetNumeroEmergencia().Equals(""))
            //{
                Android.Support.V7.App.AlertDialog.Builder alertDialog_objeto = new Android.Support.V7.App.AlertDialog.Builder(this);
                EditText txtNumeroEmergencia = new EditText(this);
                txtNumeroEmergencia.SetRawInputType(Android.Text.InputTypes.ClassNumber);
                alertDialog_objeto.SetTitle("CONTATO DE EMERGÊNCIA");
                alertDialog_objeto.SetMessage("Para a sua segurança, insira um número de contato para casos de emergência!");
                alertDialog_objeto.SetView(txtNumeroEmergencia);
                alertDialog_objeto.SetNeutralButton("Entendi!", delegate
                {
                    definicoesUsuarios_objeto.SetNumeroEmergencia(txtNumeroEmergencia.Text);
                    Dispose();
                });
                alertDialog_objeto.Show();
            //}
            //else
            //{
                Toast.MakeText(this, "Número de emergência já informado!", ToastLength.Short).Show();
            //}
        }

        // CRIANDO MÉTODO PARA O BOTÃO "btnPreparado":
        private void BtnPreparado__Click(object sender, EventArgs e)
        {
            InformacoesCadeira informacoesCadeira_objeto = new InformacoesCadeira();
            if (informacoesCadeira_objeto.GetFC3())
            {
                Toast.MakeText(this, "Muito bem, acessando plataforma...", ToastLength.Short).Show();
                StartActivity(typeof(TelaControles));
            }
            else
            {
                Toast.MakeText(this, "Cinto não afivelado", ToastLength.Short).Show();
            }
        }
    }
}