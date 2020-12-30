using PrototipoCadeiraDeRodas.Resources;
using System;
namespace PrototipoCadeiraDeRodas
{
    class InformacoesAplicativo
    {
        // DECLARANDO AS VARIÁVEIS GLOBAIS DA CLASSE:
        private bool atuador;
        private String codigoVerificacaoAndroid = "19@66A21&17#*$";
        private String direcao;
        private int velocidade;
        private UtilidadesBluetooth utilidadesBluetooth_objeto = new UtilidadesBluetooth();

        // MÉTODOS GET():
        public bool GetAtuador()
        {
            return this.atuador;
        }
        public String GetCodigoVerificacaoAndroid()
        {
            return this.codigoVerificacaoAndroid;
        }
        public String GetDirecao()
        {
            return this.direcao;
        }
        public int GetVelocidade()
        {
            return this.velocidade;
        }

        // MÉTODOS SET():
        public void SetAtuador(bool posicaoAtuadorSelecionada)
        {
            this.atuador = posicaoAtuadorSelecionada;
            TransmitirInformacoes();
        }
        public void SetDirecao(String direcaoSelecionada)
        {
            this.direcao = direcaoSelecionada;
            TransmitirInformacoes();
        }
        public void SetVelocidade(int velocidadeSelecionada)
        {
            this.velocidade = velocidadeSelecionada;
            TransmitirInformacoes();
        }

        // MÉTODO PARA OPERAÇÃO COM A COMUNICAÇÃO BLUETOOTH:
        public void TransmitirInformacoes()
        {
            Java.Lang.String jAtuador = new Java.Lang.String(this.atuador.ToString());
            utilidadesBluetooth_objeto.EnviarInformacoes(jAtuador);
            Java.Lang.String jCodigoVerificacaoAndroid = new Java.Lang.String(this.codigoVerificacaoAndroid.ToString());
            utilidadesBluetooth_objeto.EnviarInformacoes(jCodigoVerificacaoAndroid);
            Java.Lang.String jDirecao = new Java.Lang.String(this.direcao.ToString());
            utilidadesBluetooth_objeto.EnviarInformacoes(jDirecao);
            Java.Lang.String jVelocidade = new Java.Lang.String(this.velocidade.ToString());
            utilidadesBluetooth_objeto.EnviarInformacoes(jVelocidade);
        }
    }
}