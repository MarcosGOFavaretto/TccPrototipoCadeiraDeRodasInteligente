using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System.Threading;
using Xamarin.Forms.OpenWhatsApp;
using System.Collections.Generic;
namespace PrototipoCadeiraDeRodas
{
    [Activity(Label = "INFORMAÇÕES", Theme = "@style/ActionBar", NoHistory = true, MainLauncher = false)]
    public class TelaVisualizarInformacoes : Activity
    {
        // DECLARANDO AS VARIÁVEIS GLOBAIS DA ATIVIDADE:
        ImageButton imgBtnTelaControles_, imgBtnTelaVisualizarInformacoes_, imgBtnSair_;
        static TextView txtPorcentagemBateria_, txtAtuador_, txtCintoSeguranca_, txtAnguloAtaque_;
        static InformacoesCadeira informacoesCadeira_objeto = new InformacoesCadeira();
        DefinicoesUsuario definicoesUsuario_objeto = new DefinicoesUsuario();
        List<DefinicoesUsuario> resultado_pesquisa = new List<DefinicoesUsuario>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.tela_visualizar_informacoes);
            imgBtnTelaVisualizarInformacoes_ = FindViewById<ImageButton>(Resource.Id.imgBtnVisualizarInformacoes);
            imgBtnTelaControles_ = FindViewById<ImageButton>(Resource.Id.imgBtnControles);
            imgBtnSair_ = FindViewById<ImageButton>(Resource.Id.imgBtnSair);
            txtPorcentagemBateria_ = FindViewById<TextView>(Resource.Id.txtPorcentagemBateria);
            txtAtuador_ = FindViewById<TextView>(Resource.Id.txtAtuador);
            txtCintoSeguranca_ = FindViewById<TextView>(Resource.Id.txtCintoSeguranca);
            txtAnguloAtaque_ = FindViewById<TextView>(Resource.Id.txtAnguloAtaque);
            imgBtnTelaVisualizarInformacoes_.Click += ImgBtnTelaVisualizarInformacoes__Click;
            imgBtnTelaControles_.Click += ImgBtnTelaControles__Click;
            imgBtnSair_.Click += ImgBtnSair__Click;
            ExibirInformacoes();
        }

        // CRIANDO O MÉTODO QUE IRÁ EXIBIR AS INFORMAÇÕES ATUAIS DA CADEIRA NA TELA DO USUÁRIO:
        private void ExibirInformacoes()
        {
            while (true)
            {
                Thread.Sleep(1000);
                informacoesCadeira_objeto.ReceberInformacoes();
                txtPorcentagemBateria_.Text = informacoesCadeira_objeto.GetNivelBateria().ToString();
                if (informacoesCadeira_objeto.GetFC1() == true && informacoesCadeira_objeto.GetFC2() == false)
                {
                    txtAtuador_.Text = "Recolhido";
                }
                else
                {
                    if (informacoesCadeira_objeto.GetFC1() == false && informacoesCadeira_objeto.GetFC2() == false)
                    {
                        txtAtuador_.Text = "Deslocando";
                    }
                    else
                    {
                        if (informacoesCadeira_objeto.GetFC1() == false && informacoesCadeira_objeto.GetFC2() == true)
                        {
                            txtAtuador_.Text = "Estendido";
                        }
                    }
                }
                if (informacoesCadeira_objeto.GetFC3())
                {
                    txtCintoSeguranca_.Text = "Afivelado";
                }
                else
                {
                    txtCintoSeguranca_.Text = "Não afivelado";
                }
                txtAnguloAtaque_.Text = informacoesCadeira_objeto.GetAnguloAtaque().ToString() + "°";
            }
        }

        // CRIANDO O MÉTODO QUE EXIBIRÁ O MENU DA TOOLBAR:
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            var conteudoMenu = MenuInflater;
            conteudoMenu.Inflate(Resource.Menu.menu, menu);
            return true;
        }

        // CRIANDO O MÉTODO QUE DETERMINA E EXECUTA A OPÇÃO SELECIONADA DA TOOLBAR:
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int opcaoSelecionada = item.ItemId;
            if (opcaoSelecionada == Resource.Id.btnMenuTelaDefinicoes)
            {
                StartActivity(typeof(TelaDefinicoes));
                Finish();
                return true;
            }
            else
            {
                if (opcaoSelecionada == Resource.Id.btnMenuAlerta)
                {
                    Toast.MakeText(this, "Alerta", ToastLength.Short).Show();
                    try
                    {
                        resultado_pesquisa = definicoesUsuario_objeto.ConsultarBancoDeDados(1);
                        //
                        Chat.Open(resultado_pesquisa[0].contato_emergencia_banco, "Emergência: o botão de emergência da cadeira de rodas foi disparado, o seu número foi escolhido como contato de emergência!");
                    }
                    catch (Exception erro_Alerta)
                    {
                        System.Console.WriteLine("Problema ao tentar abrir o WhatsApp, ERRO: " + erro_Alerta);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        // CRIANDO MÉTODO PARA O BOTÃO "imgBtnTelaVisualizarInformacoes" PERTENCENTE À NAVBAR:
        private void ImgBtnTelaVisualizarInformacoes__Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Tela atual", ToastLength.Short).Show();
        }

        // CRIANDO MÉTODO PARA O BOTÃO "imgBtnTelaControles" PERTENCENTE À NAVBAR:
        private void ImgBtnTelaControles__Click(object sender, EventArgs e)
        {
            StartActivity(typeof(TelaControles));
            Finish();
        }

        // CRIANDO MÉTODO PARA O BOTÃO "imgBtnSair" PERTENCENTE À NAVBAR:
        private void ImgBtnSair__Click(object sender, EventArgs e)
        {
            Finish();
        }
    }
}