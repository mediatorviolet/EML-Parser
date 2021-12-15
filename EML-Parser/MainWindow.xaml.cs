using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MimeKit;

namespace EML_Parser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string source = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName + @"\sources";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetEmlFromSources(object sender, RoutedEventArgs e)
        {
            var message = MimeMessage.Load(source + @"\sources\TEST.eml");

            Debug.WriteLine(message.To);
        }

        private void FileList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var message = MimeMessage.Load(FileList.SelectedItem.ToString());

            MessageSubject.Content = message.Subject;
            MessageFrom.Content = message.From;
            MessageTo.Content = message.To;
            MessageBody.Content = message.TextBody;
            MessageDate.Content = message.Date;
            MessageAttachment.Content= message.Attachments;
        }

        private void FileList_Loaded(object sender, RoutedEventArgs e)
        {
            string[] filePaths = Directory.GetFiles(source, "*.eml");

            foreach (string filePath in filePaths)
            {
                FileList.Items.Add(filePath);
            }
        }
    }
}
