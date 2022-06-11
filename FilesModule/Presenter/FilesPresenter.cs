using FilesModule.View;

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
    }
}
