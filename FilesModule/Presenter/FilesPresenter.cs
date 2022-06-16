using FilesModule.View;
using FilesModule.Model;
using System.Data.SqlClient;


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
            SqlConnection connection = Files.GetConnection();

            if(string.IsNullOrEmpty(filesView.TxtFilePath))
            {
                MessageBox.Show("No ha seleccionado un archivo", "Warning");
                return;
            }

            filesView.TxtFilePath = filesView.TxtFilePath.Trim(); // Test Functionaltity of this line

            // using === with()
            using(Stream stream = File.OpenRead(filesView.TxtFilePath))
            {
                byte[] buffer = new byte[stream.Length];

                // Read Into the Buffer
                stream.Read(buffer, 0, buffer.Length);

                string extension = new FileInfo(filesView.TxtFilePath).Extension;

                if (connection is not null)
                {
                    var success = Files.InsertFile(connection, buffer, extension);

                    if (success)
                    {
                        MessageBox.Show("Archivo Guardado Correctamente", "Exito");
                    }
                }
            }  
        }
    }
}
