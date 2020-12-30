using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;
using SQLite;
namespace PrototipoCadeiraDeRodas
{
    [Activity(Label = "DEFINIÇÕES DO USUÁRIO", Theme = "@style/AppThemeNoActionBar", NoHistory = false, MainLauncher = false)]
    public class TelaDefinicoes : Activity
    {
        // DECLARANDO AS VARIÁVEIS GLOBAIS DA ATIVIDADE:
        Button btnAlterarInformacoes_, btnFechar_;
        EditText txtNomeCompleto_, txtEndereco_, txtTelefoneEmergencia_, txtTipoSanguineo_, txtAlergias_;
        bool presencaRegistroBanco;
        DefinicoesUsuario definicoesUsuario_objeto = new DefinicoesUsuario();
        BancoDeDados bancoDeDados_objeto = new BancoDeDados();
        List<DefinicoesUsuario> resultado_pesquisa = new List<DefinicoesUsuario>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.tela_definicoes_usuario);
            btnFechar_ = FindViewById<Button>(Resource.Id.btnFechar);
            btnAlterarInformacoes_ = FindViewById<Button>(Resource.Id.btnAlterarInformacoes);
            txtNomeCompleto_ = FindViewById<EditText>(Resource.Id.txtNomeCompleto);
            txtEndereco_ = FindViewById<EditText>(Resource.Id.txtEndereco);
            txtTelefoneEmergencia_ = FindViewById<EditText>(Resource.Id.txtTelefoneEmergencia);
            txtTipoSanguineo_ = FindViewById<EditText>(Resource.Id.txtTipoSanguineo);
            txtAlergias_ = FindViewById<EditText>(Resource.Id.txtAlergias);
            btnAlterarInformacoes_.Click += BtnAlterarInformacoes__Click;
            btnFechar_.Click += BtnFechar__Click;
            txtNomeCompleto_.Text = definicoesUsuario_objeto.GetNomeCompleto();
            txtEndereco_.Text = definicoesUsuario_objeto.GetEndereco();
            txtTelefoneEmergencia_.Text = definicoesUsuario_objeto.GetNumeroEmergencia();
            txtTipoSanguineo_.Text = definicoesUsuario_objeto.GetTipoSanguineo();
            txtAlergias_.Text = definicoesUsuario_objeto.GetAlergias();
            if (bancoDeDados_objeto.CriarBancoDeDados())
            {
                Toast.MakeText(this, "Banco criado", ToastLength.Short).Show();
            }
            GetDados();
            definicoesUsuario_objeto.InserirNoBancoDeDados(definicoesUsuario_objeto);
            VerificarCondicaoCampos();
            VerificarPresencaRegistroBanco();
            if (presencaRegistroBanco)
            {
                SetDados();
            }
        }

        private void GetDados()
        {
            definicoesUsuario_objeto.nome_completo_banco = txtNomeCompleto_.Text;
            definicoesUsuario_objeto.endereco_banco = txtEndereco_.Text;
            definicoesUsuario_objeto.contato_emergencia_banco = txtTelefoneEmergencia_.Text;
            definicoesUsuario_objeto.tipo_sanguineo_banco = txtTipoSanguineo_.Text;
            definicoesUsuario_objeto.alergias_banco = txtAlergias_.Text;
        }

        private void SetDados()
        {
            txtNomeCompleto_.Text = resultado_pesquisa[0].nome_completo_banco;
            txtEndereco_.Text = resultado_pesquisa[0].endereco_banco;
            txtTelefoneEmergencia_.Text = resultado_pesquisa[0].contato_emergencia_banco;
            txtTipoSanguineo_.Text = resultado_pesquisa[0].tipo_sanguineo_banco;
            txtAlergias_.Text = resultado_pesquisa[0].alergias_banco;
        }

        private bool VerificarPresencaRegistroBanco()
        {
            try
            {
                resultado_pesquisa = definicoesUsuario_objeto.ConsultarBancoDeDados(1);
                if (resultado_pesquisa == null)
                {
                    System.Console.WriteLine("A PESQUISA NÃO APRESENTOU RESULTADOS");
                }
                else
                {
                    if (resultado_pesquisa[0].nome_completo_banco.Equals(null) && resultado_pesquisa[0].endereco_banco.Equals(null) && resultado_pesquisa[0].contato_emergencia_banco.Equals(null) && resultado_pesquisa[0].tipo_sanguineo_banco.Equals(null) && resultado_pesquisa[0].alergias_banco.Equals(null))
                    {
                        presencaRegistroBanco = false;
                    }
                    else
                    {
                        presencaRegistroBanco = true;
                    }
                }
            }
            catch (SQLiteException erro_verificarPresencaRegistroBanco)
            {
                System.Console.WriteLine("Problema ao tentar verificar a presença de registros no banco de dados, ERRO: " + erro_verificarPresencaRegistroBanco);
            }
            return presencaRegistroBanco;
        }

        // CRIANDO O MÉTODO QUE IRÁ BLOQUEAR OS CAMPOS PARA QUE NÃO SEJAM ALTERADOS:
        private void BloquearCampos()
        {
            txtNomeCompleto_.Enabled = false;
            txtEndereco_.Enabled = false;
            txtTelefoneEmergencia_.Enabled = false;
            txtTipoSanguineo_.Enabled = false;
            txtAlergias_.Enabled = false;
        }

        // CRIANDO O MÉTODO QUE IRÁ DESBLOQUEAR OS CAMPOS PARA QUE SEJAM ALTERADOS:
        private void LiberarCampos()
        {
            txtNomeCompleto_.Enabled = true;
            txtEndereco_.Enabled = true;
            txtTelefoneEmergencia_.Enabled = true;
            txtTipoSanguineo_.Enabled = true;
            txtAlergias_.Enabled = true;
        }

        // CRIANDO O MÉTODO QUE IRÁ VERIFICAR SE OS CAMPOS ESTÃO HABILITADOS:
        private bool VerificarCondicaoCampos()
        {
            if (txtNomeCompleto_.Enabled == true && txtEndereco_.Enabled == true && txtTelefoneEmergencia_.Enabled == true && txtTipoSanguineo_.Enabled == true && txtAlergias_.Enabled == true)
            {
                btnAlterarInformacoes_.Text = "SALVAR INFORMAÇÕES";
                return true;
            }
            else
            {
                btnAlterarInformacoes_.Text = "ALTERAR INFORMAÇÕES";
                return false;
            }
        }

        // CRIANDO O MÉTODO DO BOTÃO "btnAlterarInformacoes":
        private void BtnAlterarInformacoes__Click(object sender, EventArgs e)
        {
            VerificarPresencaRegistroBanco();
            GetDados();
            if (VerificarCondicaoCampos())
            {
                BloquearCampos();
            }
            else
            {
                LiberarCampos();
            }
            if (!presencaRegistroBanco)
            {
                // inserir
                if (definicoesUsuario_objeto.InserirNoBancoDeDados(definicoesUsuario_objeto) == 1)
                {
                    System.Console.WriteLine("Inserção concluída");
                }
                else
                {
                    System.Console.WriteLine("Inserção NÃO concluída");
                }

            }
            else
            {
                // alterar
                if (definicoesUsuario_objeto.AlterarDadosNoBanco(definicoesUsuario_objeto) == 1)
                {
                    System.Console.WriteLine("Alteração concluída");
                }
                else
                {
                    System.Console.WriteLine("Alteração NÃO concluída");
                }

            }
        }

        // CRIANDO O MÉTODO DO BOTÃO "btnFechar":
        private void BtnFechar__Click(object sender, EventArgs e)
        {
            StartActivity(typeof(TelaControles));
            Finish();
        }
    }
}