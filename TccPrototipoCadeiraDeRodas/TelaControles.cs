using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using System.Threading;
namespace PrototipoCadeiraDeRodas
{
    [Activity(Label = "CONTROLES", Theme = "@style/ActionBar", NoHistory = true, MainLauncher = false)]
    public class TelaControles : Activity
    {
        // DECLARANDO AS VARIÁVEIS GLOBAIS DA ATIVIDADE:
        ImageButton imgBtnSubirAuxiliador_, imgBtnDescerAuxiliador_, imgBtnVelocidade1_, imgBtnVelocidade2_, imgBtnVelocidade3_, imgBtnCima_, imgBtnEsquerda_, imgBtnDireita_, imgBtnBaixo_, imgBtnTelaVisualizarInformacoes_, imgBtnTelaControles_, imgBtnSair_;
        Button btnPararCadeira;
        InformacoesAplicativo informacoesAplicativo_objeto = new InformacoesAplicativo();
        InformacoesCadeira informacoesCadeira_objeto = new InformacoesCadeira();
        bool pararCadeira;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.tela_controle);
            imgBtnSubirAuxiliador_ = FindViewById<ImageButton>(Resource.Id.imgBtnSubirAuxiliador);
            imgBtnDescerAuxiliador_ = FindViewById<ImageButton>(Resource.Id.imgBtnDescerAuxiliador);
            imgBtnVelocidade1_ = FindViewById<ImageButton>(Resource.Id.imgBtnVelocidade1);
            imgBtnVelocidade2_ = FindViewById<ImageButton>(Resource.Id.imgBtnVelocidade2);
            imgBtnVelocidade3_ = FindViewById<ImageButton>(Resource.Id.imgBtnVelocidade3);
            imgBtnCima_ = FindViewById<ImageButton>(Resource.Id.imgBtnCima);
            imgBtnEsquerda_ = FindViewById<ImageButton>(Resource.Id.imgBtnEsquerda);
            imgBtnDireita_ = FindViewById<ImageButton>(Resource.Id.imgBtnDireita);
            imgBtnBaixo_ = FindViewById<ImageButton>(Resource.Id.imgBtnBaixo);
            imgBtnTelaVisualizarInformacoes_ = FindViewById<ImageButton>(Resource.Id.imgBtnVisualizarInformacoes);
            imgBtnTelaControles_ = FindViewById<ImageButton>(Resource.Id.imgBtnControles);
            imgBtnSair_ = FindViewById<ImageButton>(Resource.Id.imgBtnSair);
            btnPararCadeira = FindViewById<Button>(Resource.Id.btnPararCadeira);
            imgBtnSubirAuxiliador_.Click += ImgBtnSubirAuxiliador__Click;
            imgBtnDescerAuxiliador_.Click += ImgBtnDescerAuxiliador__Click;
            imgBtnVelocidade1_.Click += ImgBtnVelocidade1__Click;
            imgBtnVelocidade2_.Click += ImgBtnVelocidade2__Click;
            imgBtnVelocidade3_.Click += ImgBtnVelocidade3__Click;
            imgBtnCima_.Click += ImgBtnCima__Click;
            imgBtnEsquerda_.Click += ImgBtnEsquerda__Click;
            imgBtnDireita_.Click += ImgBtnDireita__Click;
            imgBtnBaixo_.Click += ImgBtnBaixo__Click;
            imgBtnTelaVisualizarInformacoes_.Click += ImgBtnTelaVisualizarInformacoes__Click;
            imgBtnTelaControles_.Click += ImgBtnTelaControles__Click;
            imgBtnSair_.Click += ImgBtnSair__Click;
            btnPararCadeira.Click += BtnPararCadeira_Click;
        }

        // CRIANDO O CÓDIGO DO BOTÃO "btnPararCadeira":
        private void BtnPararCadeira_Click(object sender, EventArgs e)
        {
            EscolherDirecao("p");
        }

        // CRIANDO O CÓDIGO DO BOTÃO "imgBtnBaixo":
        private void ImgBtnBaixo__Click(object sender, EventArgs e)
        {
            EscolherDirecao("t");

        }

        // CRIANDO O CÓDIGO DO BOTÃO "imgBtnDireita":
        private void ImgBtnDireita__Click(object sender, EventArgs e)
        {
            EscolherDirecao("d");
        }

        // CRIANDO O CÓDIGO DO BOTÃO "imgBtnEsquerda":
        private void ImgBtnEsquerda__Click(object sender, EventArgs e)
        {
            EscolherDirecao("e");
        }

        //CRIANDO O CÓDIGO DO BOTÃO "imgBtncima":
        private void ImgBtnCima__Click(object sender, EventArgs e)
        {
            EscolherDirecao("f");
        }

        // CRIANDO O MÉTODO QUE IRÁ ENVIAR A DIREÇÃO ESCOLHIDA PELO USUÁRIO PARA A CLASSE "InformacoesAplicativo":
        private void EscolherDirecao(String direcaoEscolhida)
        {
            informacoesAplicativo_objeto.SetDirecao(direcaoEscolhida);
            System.Console.WriteLine("Direção atual: " + informacoesAplicativo_objeto.GetDirecao());
        }

        // CRIANDO O CÓDIGO DO BOTÃO "imgBtnVelocidade3":
        private void ImgBtnVelocidade3__Click(object sender, EventArgs e)
        {
            if (!informacoesAplicativo_objeto.GetVelocidade().Equals(3))
            {
                informacoesAplicativo_objeto.SetVelocidade(3);
            }
            else
            {
                Toast.MakeText(this, "A velocidade 3 já está selecionada", ToastLength.Short).Show();
            }
            System.Console.WriteLine("Velocidade atual: " + informacoesAplicativo_objeto.GetVelocidade().ToString());
        }

        // CRIANDO O CÓDIGO DO BOTÃO "imgBtnVelocidade2":
        private void ImgBtnVelocidade2__Click(object sender, EventArgs e)
        {
            if (!informacoesAplicativo_objeto.GetVelocidade().Equals(2))
            {
                informacoesAplicativo_objeto.SetVelocidade(2);
            }
            else
            {
                Toast.MakeText(this, "A velocidade 2 já está selecionada", ToastLength.Short).Show();
            }
            System.Console.WriteLine("Velocidade atual: " + informacoesAplicativo_objeto.GetVelocidade().ToString());
        }

        // CRIANDO O CÓDIGO DO BOTÃO "imgBtnVelocidade1":
        private void ImgBtnVelocidade1__Click(object sender, EventArgs e)
        {
            if (!informacoesAplicativo_objeto.GetVelocidade().Equals(1))
            {
                informacoesAplicativo_objeto.SetVelocidade(1);
            }
            else
            {
                Toast.MakeText(this, "A velocidade 1 já está selecionada", ToastLength.Short).Show();
            }
            System.Console.WriteLine("Velocidade atual: " + informacoesAplicativo_objeto.GetVelocidade().ToString());
        }

        // CRIANDO O CÓDIGO DO BOTÃO "imgBtnDescerAuxiliador":
        private void ImgBtnDescerAuxiliador__Click(object sender, EventArgs e)
        {
            if (informacoesCadeira_objeto.GetFC1().Equals(true) && informacoesCadeira_objeto.GetFC2().Equals(false))
            {
                informacoesAplicativo_objeto.SetAtuador(true);
                System.Console.WriteLine("Descendo...");

            }
            else
            {
                if (informacoesCadeira_objeto.GetFC1().Equals(false) && informacoesCadeira_objeto.GetFC2().Equals(false))
                {

                    Toast.MakeText(this, "O auxiliador não terminou seu curso, aguarde, por favor!", ToastLength.Short).Show();
                }
            }
            System.Console.WriteLine("Estado do atuador: " + informacoesAplicativo_objeto.GetAtuador());
        }

        // CRIANDO O CÓDIGO DO BOTÃO "imgBtnSubirAuxiliador":
        private void ImgBtnSubirAuxiliador__Click(object sender, EventArgs e)
        {
            if (informacoesCadeira_objeto.GetFC1().Equals(false) && informacoesCadeira_objeto.GetFC2().Equals(true))
            {
                informacoesAplicativo_objeto.SetAtuador(false);
                System.Console.WriteLine("Subindo...");
            }
            else
            {
                if (informacoesCadeira_objeto.GetFC1().Equals(false) && informacoesCadeira_objeto.GetFC2().Equals(false))
                {

                    Toast.MakeText(this, "O auxiliador não terminou seu curso, aguarde, por favor!", ToastLength.Short).Show();
                }
            }
            System.Console.WriteLine("Estado do atuador: " + informacoesAplicativo_objeto.GetAtuador());
        }


        // CRIANDO O CÓDIGO DO BOTÃO "btnTravarAcao":
        private void BtnTravarAcao__Click(object sender, EventArgs e)
        {
            bool estadoBtnTravarAcao = true;
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
            StartActivity(typeof(TelaVisualizarInformacoes));
            Finish();
        }

        // CRIANDO MÉTODO PARA O BOTÃO "imgBtnTelaControles" PERTENCENTE À NAVBAR:
        private void ImgBtnTelaControles__Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Tela atual", ToastLength.Short).Show();
        }

        // CRIANDO MÉTODO PARA O BOTÃO "imgBtnSair" PERTENCENTE À NAVBAR:
        private void ImgBtnSair__Click(object sender, EventArgs e)
        {
            Finish();
        }
    }
}