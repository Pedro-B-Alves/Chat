using System.Windows.Forms;
using System.Net;

namespace chatServidor
{
    public partial class Form1 : Form
    {
        private delegate void AtualizaStatusCallback(string strMensagem);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAtendimento_Click(object sender, EventArgs e)
        {
            // Analisa o endereço IP do servidor informado no textbox
            IPAddress enderecoIP = IPAddress.Parse(txtServidorIP.Text);

            // Cria uma nova instância do objeto ChatServidor
            chatServidor mainServidor = new chatServidor(enderecoIP);

            // Vincula o tratamento de evento StatusChanged a mainServer_StatusChanged
            chatServidor.StatusChanged += new StatusChangedEventHandler(mainServidor_StatusChanged);

            // Inicia o atendimento das conexões
            mainServidor.IniciaAtendimento();

            // Mostra que nos iniciamos o atendimento para conexões
            txtLog.AppendText("Monitorando as conexões...\r\n");
        }

        public void mainServidor_StatusChanged(object sender, StatusChangedEventArgs e)
        {
            // Chama o método que atualiza o formulário
            this.Invoke(new AtualizaStatusCallback(this.AtualizaStatus), new object[] { e.EventMessage });
        }

        private void AtualizaStatus(string strMensagem)
        {
            // Atualiza o logo com mensagens
            txtLog.AppendText(strMensagem + "\r\n");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}