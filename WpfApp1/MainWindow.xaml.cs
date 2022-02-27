using System;
using System.Collections.Generic;
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
using System.IO;
using LZ4;
using ProtoBuf;
using UnityEngine;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Microsoft.Win32.FileDialog ofd_1, ofd_2;
        
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ofd_1 = new Microsoft.Win32.OpenFileDialog() { Filter = "TXT Files (*.txt)|*.txt" };
            var result = ofd_1.ShowDialog();
            if (result == false) return;
            label_1.Content = ofd_1.FileName;
        }

        private void button_start_Click(object sender, RoutedEventArgs e)
        {
            if (label_1.Content.ToString() != "" && label_2.Content.ToString() != "" && TextBox_1.Text.Length != 0)
            {
                using (StreamReader sr = new StreamReader(ofd_1.FileName))
                {
                    string s;
                    KKCODLHFJAN.PrefabData prefab = new KKCODLHFJAN.PrefabData();
                    while ((s = sr.ReadLine()) != null)
                    {
                        String[] words = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        prefab.prefabs.Add(new JLJBCNIFNNH.PrefabData()
                        {
                            id = Convert.ToUInt32(words[9]), // id прифаба
                            position = new JLJBCNIFNNH.VectorData(float.Parse(words[0]), float.Parse(words[1]), float.Parse(words[2])), //Позиция (x,y,z)
                            rotation = new JLJBCNIFNNH.VectorData(float.Parse(words[3]), float.Parse(words[4]), float.Parse(words[5])), //Поворот (x,y,z)
                            scale = new JLJBCNIFNNH.VectorData(float.Parse(words[6]), float.Parse(words[7]), float.Parse(words[8])) //Размеры (x,y,z)
                        });
                    }
                    prefab.CBBCJEOCDKC(ofd_2.FileName);

                }
                Label_error.Content = "Файл сохранён!";
            }
            else
            {
                Label_error.Content = "Ошибка в входных данных!";
            }
            
        }

        private void button_2_Click(object sender, RoutedEventArgs e)
        {
            ofd_2 = new Microsoft.Win32.SaveFileDialog() { Filter = "Prefab Files (*.Prefab)|*.Prefab" };
            var result = ofd_2.ShowDialog();
            if (result == false) return;
            label_2.Content = ofd_2.FileName;
        }
    }
}