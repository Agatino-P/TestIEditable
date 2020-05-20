using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace TestIEditable
{
    public class MainWindowViewModel: ViewModelBase
    {
        private ObservableCollection<PersonViewModel> _persons=new ObservableCollection<PersonViewModel>();
        public ObservableCollection<PersonViewModel> Persons { get => _persons; set { Set(() => Persons, ref _persons, value); }}

        public MainWindowViewModel()
        {
            Persons.Add(new PersonViewModel( "uno",1));
            Persons.Add(new PersonViewModel("due",2));
            Persons.Add(new PersonViewModel("tre",3));
        }
    }
}
