using System;
using SQLite;
namespace PrototipoCadeiraDeRodas
{
    class BancoDeDados
    {
        // DECLARANDO AS VARIÁVEIS GLOBAIS DA CLASSE:
        string localBancoDeDados = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        // CRIANDO O MÉTODO QUE IRÁ CONSTRUIR O BANCO DE DADOS CASO ELE AINDA NÃO TENHA SIDO CRIADO:
        public bool CriarBancoDeDados()
        {
            try
            {
                using (var conexao_objeto = new SQLiteConnection(System.IO.Path.Combine(localBancoDeDados, "bancodedados.db")))
                {
                    conexao_objeto.CreateTable<DefinicoesUsuario>();
                    return true;
                }
            }
            catch (SQLiteException erro_CriarBancoDeDados)
            {
                Console.WriteLine("Problema ao tentar criar o banco de dados,  ERRO: " + erro_CriarBancoDeDados);
                return false;
            }
        }
    }
}