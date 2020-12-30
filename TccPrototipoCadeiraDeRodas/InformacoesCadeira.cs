using System;
using PrototipoCadeiraDeRodas.Resources;

namespace PrototipoCadeiraDeRodas
{
    class InformacoesCadeira
    {
        // DECLARANDO AS VARIÁVEIS GLOBAIS DA CLASSE:
        private float anguloAtaque = 47;
        private bool FC1 = true;
        private bool FC2 = false;
        private bool FC3 = true;
        private float nivelBateria = 1;
        private String codigoVerificacaoCadeira = "19*m17A@17#MG";
        private string[] dadosEntradaArray = new string[6];
        private UtilidadesBluetooth utilidadesBluetooth_objeto = new UtilidadesBluetooth();

        // MÉTODOS GET():
        public bool GetFC1()
        {
            return this.FC1;
        }
        public bool GetFC2()
        {
            return this.FC2;
        }
        public bool GetFC3()
        {
            return this.FC3;
        }
        public double GetNivelBateria()
        {
            return this.nivelBateria;
        }
        public double GetAnguloAtaque()
        {
            return this.anguloAtaque;
        }
        public String GetCodigoVerificacaoCadeira()
        {
            return this.codigoVerificacaoCadeira;
        }

        // MÉTODO PARA OPERAÇÃO COM A COMUNICAÇÃO BLUETOOTH:
        public void ReceberInformacoes()
        {
            //while (true)
            //{
            //    dadosEntradaArray = utilidadesBluetooth_objeto.ReceberInformacoes();
            //    this.anguloAtaque = float.Parse(dadosEntradaArray[0]);
            //    if (dadosEntradaArray[1].Equals("true"))
            //    {
            //        this.FC1 = true;
            //    }
            //    else
            //    {
            //        this.FC1 = false;
            //    }
            //    if (dadosEntradaArray[2].Equals("true"))
            //    {
            //        this.FC2 = true;
            //    }
            //    else
            //    {
            //        this.FC2 = false;
            //    }
            //    if (dadosEntradaArray[3].Equals("true"))
            //    {
            //        this.FC3 = true;
            //    }
            //    else
            //    {
            //        this.FC3 = false;
            //    }
            //    this.nivelBateria = float.Parse(dadosEntradaArray[4]);
            //    this.codigoVerificacaoCadeira = dadosEntradaArray[5];
            //}
        }
    }
}