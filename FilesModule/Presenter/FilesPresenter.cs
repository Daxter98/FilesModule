using FilesModule.View;
using FilesModule.Model;

namespace FilesModule.Presenter
{
    internal class FilesPresenter
    {
        private readonly IFiles filesView; 

        public FilesPresenter(IFiles filesView)
        {
            this.filesView = filesView;
        }

        public void BrowseFiles()
        {
            OpenFileDialog ofd = new();
            ofd.ShowDialog();
            filesView.TxtFilePath = ofd.FileName;
        }

        public void SaveFile()
        {
            Files files = new();

            if(String.IsNullOrEmpty(filesView.TxtFilePath))
            {
                MessageBox.Show("No ha seleccionado un archivo", "Warning");
                return;
            }

            files.TestConnection();
        }
    }
}
