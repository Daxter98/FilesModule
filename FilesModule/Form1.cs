using FilesModule.Presenter;
using FilesModule.View;

namespace FilesModule
{
    public partial class Form1 : Form, IFiles
    {
        private readonly FilesPresenter _presenter;
        public Form1()
        {
            InitializeComponent();
            _presenter = new FilesPresenter(this);
        }

        public string TxtFilePath { get => TxtBoxFilePath.Text; set => TxtBoxFilePath.Text = value; }

        private void BtnCargar_Click(object sender, EventArgs e)
        {
            _presenter.BrowseFiles();
        }
    }
}