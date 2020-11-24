using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace WpfApp7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

 
    public partial class MainWindow : Window
    {
        ObservableCollection<Contact> Phonebook = new ObservableCollection<Contact>();
        public MainWindow()
        {
            InitializeComponent();

            Listbox1.ItemsSource = Phonebook;

            Listbox1.DisplayMemberPath = nameof(Contact.FullInfo);
        }
    
        private void buuton1_Click(object sender, RoutedEventArgs e)
        {
            if(text1.Text!=""&& text2.Text != "" && text3.Text != "" && text4.Text != "" && check_number())
            Phonebook.Add(new Contact() { Name = text1.Text, SurName = text2.Text, PhoneNumber = long.Parse(text3.Text), OperatorType = text4.Text });
            text1.Text = "";
            text2.Text = "";
            text3.Text = "";
            text4.Text = "";
        }

        private bool check_number()
        {
            for (int i = 0; i < text3.Text.Length; i++)
            {
                if(text3.Text[i] >= 48 && text3.Text[i] <=  57)
                {
                   
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private void buuton2_Click(object sender, RoutedEventArgs e)
        {
            if (Listbox1.SelectedItem != null)
            {
                Phonebook.Remove(Listbox1.SelectedItem as Contact);
            }
        }

        private void buuton3_Click(object sender, RoutedEventArgs e)
        {
            if (text1.Text != "" && text2.Text != "" && text3.Text != "" && text4.Text != "" && check_number())
            {
                Phonebook[Listbox1.SelectedIndex].Name = text1.Text;
                Phonebook[Listbox1.SelectedIndex].SurName = text2.Text;
                Phonebook[Listbox1.SelectedIndex].PhoneNumber = long.Parse(text3.Text);
                Phonebook[Listbox1.SelectedIndex].OperatorType = text4.Text;
                text1.Text = "";
                text2.Text = "";
                text3.Text = "";
                text4.Text = "";
            }
        }

        private void buuton4_Click_1(object sender, RoutedEventArgs e)
        {
            if (Listbox1.SelectedIndex != -1)
            {
                text1.Text = Phonebook[Listbox1.SelectedIndex].Name;
                text2.Text = Phonebook[Listbox1.SelectedIndex].SurName;
                text3.Text = Phonebook[Listbox1.SelectedIndex].PhoneNumber.ToString();
                text4.Text = Phonebook[Listbox1.SelectedIndex].OperatorType;
            }

        }
    }


    class Contact : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(FullInfo));
                }
            }
        }

        private string _surname;
        public string SurName
        {
            get { return _surname; }
            set
            {
                if (_surname != value)
                {
                    _surname = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(FullInfo));
                }
            }
        }


        private long _phone_number;
        public long PhoneNumber
        {
            get { return _phone_number; }
            set
            {
                if (_phone_number != value)
                {
                    _phone_number = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(FullInfo));
                }
            }
        }

        private string _operator_type;
        public string OperatorType
        {
            get { return   _operator_type; }
            set
            {
                if (_operator_type != value)
                {
                    _operator_type = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(FullInfo));
                }
            }
        }
        
        public string FullInfo => $"Name: {Name}\nSurname: {SurName}\nPhone number: {PhoneNumber}\nOperator Type: {OperatorType}\n";
        public override string ToString()
        {
            return Name + " : " + SurName + " : " + PhoneNumber + " : " + OperatorType;
        }

       
        public event PropertyChangedEventHandler PropertyChanged;    
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
