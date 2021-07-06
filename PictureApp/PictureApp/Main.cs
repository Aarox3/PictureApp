using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureApp
{
    public partial class Main : Form
    {
        private String imagePath = $@"{ Environment.CurrentDirectory}\imagePath.txt";

        public Main()
        {

            InitializeComponent();

            ReadFilePath();

            DisplayDeleteButton();
                                               
        }

        public void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                OpenFileDialog dialog = new OpenFileDialog();

                dialog.Filter = "jpg files(*.jpg) |*.jpg| PNG files(*png) |*.png| All Files(*.*) |*.*";


                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                  
                    String filePath = dialog.FileName;

                    PictureBox.ImageLocation = filePath;

                    File.WriteAllText(imagePath, filePath);

                    PictureBox.Refresh();

                    DisplayDeleteButton();

                }
            
            }

            catch (Exception)
            {
                MessageBox.Show("Błąd!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        public void btnDelete_Click(object sender, EventArgs e)
        {

            var confirmDelete = MessageBox.Show("Czy na pewno chcesz usunąć to zdjęcie?", "Ostrzeżenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmDelete == DialogResult.Yes)

            {

                PictureBox.ImageLocation = "";
                               
                File.WriteAllText(imagePath, "");

                PictureBox.Refresh();

                DisplayDeleteButton();

            }
            
        }


        public void DisplayDeleteButton()
        {
            btnDelete.Enabled = PictureBox.ImageLocation != "";

        }

        public void ReadFilePath()
        {
            try
            {
                var fileContent = File.ReadAllText(imagePath);

                PictureBox.ImageLocation = fileContent;

                PictureBox.Refresh();

                DisplayDeleteButton();
            }

            catch(FileNotFoundException e)
            {
                    MessageBox.Show(e.Message, "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
    
       
       


    

