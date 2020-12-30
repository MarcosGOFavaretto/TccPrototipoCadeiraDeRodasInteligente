using System;
using System.Collections.Generic;
using SQLite;
namespace PrototipoCadeiraDeRodas
{
    class DefinicoesUsuario
    {
        // DECLARANDO AS VARIÁVEIS GLOBAIS DA CLASSE:
        private String nomeCompleto;
        private String endereco;
        private String numeroEmergencia;
        private String tipoSanguineo;
        private String alergias;
        // Campos do Banco de Dados:

        [MaxLength(3), AutoIncrement, PrimaryKey]
        public int id_usuario_banco { get; set; }
        [MaxLength(50), NotNull]
        public String nome_completo_banco { get; set; }
        [MaxLength(200), NotNull]
        public String endereco_banco { get; set; }
        [MaxLength(17), NotNull]
        public String contato_emergencia_banco { get; set; }
        [MaxLength(4), NotNull]
        public String tipo_sanguineo_banco { get; set; }
        [MaxLength(200), NotNull]
        public String alergias_banco { get; set; }
        string localBancoDeDados = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        int resultado;
        int resultadoAtualizar;
        public int InserirNoBancoDeDados(DefinicoesUsuario informacoesUsuario_objeto)
        {
            try
            {
                using (var conexao_objeto = new SQLiteConnection(System.IO.Path.Combine(localBancoDeDados, "bancodedados.db")))
                {
                    resultado = conexao_objeto.Insert(informacoesUsuario_objeto);
                }
            }
            catch (SQLiteException erro_Inserir)
            {
                Console.WriteLine("ERRO: " + erro_Inserir);
            }
            return resultado;
        }

        public List<DefinicoesUsuario> ConsultarBancoDeDados(int id_usuario_query)
        {
            try
            {
                using (var conexao_objeto = new SQLiteConnection(System.IO.Path.Combine(localBancoDeDados, "bancodedados.db")))
                {
                    List<DefinicoesUsuario> resultado_query = conexao_objeto.Query<DefinicoesUsuario>("select * from definicoesusuario where id_usuario_banco =" + id_usuario_query);
                    return resultado_query;
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                System.Console.WriteLine("ERRO: " + ex);
                return null;
            }
        }

        // CRIANDO O MÉTODO QUE IRÁ ATUALIZAR OS DADOS DO BANCO PARA QUE POSSAM SER EXIBIDOS PARA O USUÁRIO:
        public int AlterarDadosNoBanco(DefinicoesUsuario dadosParaAtualizar)
        {
            try
            {
                using (var conexao_objeto = new SQLiteConnection(System.IO.Path.Combine(localBancoDeDados, "bancodedados.db")))
                {
                    resultadoAtualizar = conexao_objeto.Execute("UPDATE definicoesusuario SET nome_completo_banco = ?, endereco_banco = ?, contato_emergencia_banco = ?, tipo_sanguineo_banco = ?, alergias_banco = ? Where id_usuario_banco =?", dadosParaAtualizar.nome_completo_banco, dadosParaAtualizar.endereco_banco, dadosParaAtualizar.contato_emergencia_banco, dadosParaAtualizar.tipo_sanguineo_banco, dadosParaAtualizar.alergias_banco, 1);
                }
            }
            catch (SQLiteException erro_AlterarBancoDeDados)
            {
                System.Console.WriteLine("Problema ao tentar alterar as informações no banco de dados, ERRO: " + erro_AlterarBancoDeDados);
            }
            return resultadoAtualizar;
        }

        // MÉTODOS GET():
        public String GetNomeCompleto()
        {
            return this.nomeCompleto;
        }
        public String GetEndereco()
        {
            return this.endereco;
        }
        public String GetNumeroEmergencia()
        {
            return this.numeroEmergencia;
        }
        public String GetTipoSanguineo()
        {
            return this.tipoSanguineo;
        }
        public String GetAlergias()
        {
            return this.alergias;
        }

        // MÉTODOS SET():
        public void SetNomeCompleto(String nomeCompleto)
        {
            this.nomeCompleto = nomeCompleto;
        }
        public void SetNumeroEmergencia(String numeroEmergencia)
        {
            this.numeroEmergencia = numeroEmergencia;
        }
        public void SetEndereco(String endereco)
        {
            this.endereco = endereco;
        }
        public void SetTipoSanguineo(String tipoSanguineo)
        {
            this.tipoSanguineo = tipoSanguineo;
        }
        public void SetAlergias(String alergias)
        {
            this.alergias = alergias;
        }
    }
}