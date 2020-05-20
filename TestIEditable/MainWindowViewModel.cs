using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;

namespace TestIEditable
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<PersonViewModel> _persons = new ObservableCollection<PersonViewModel>();
        public ObservableCollection<PersonViewModel> Persons { get => _persons; set => Set(() => Persons, ref _persons, value); }
        
        private PersonViewModel  _selectedPerson; 
        public PersonViewModel  SelectedPerson { get => _selectedPerson; set { value.BeginEdit(); Set(() => SelectedPerson, ref _selectedPerson, value); }}
        
        /*
        private RelayCommand _addPersonCmd;
        public RelayCommand AddPersonCmd => _addPersonCmd ?? (_addPersonCmd = new RelayCommand(
            () => addPersonCmd(),
            () => { return 1 == 1; },
            keepTargetAlive: true
            ));

        private void addPersonCmd()
        {
            throw new NotImplementedException();
        }
        */

        private RelayCommand<PersonViewModel> _savePersonCmd;
        public RelayCommand<PersonViewModel> SavePersonCmd => _savePersonCmd ?? (_savePersonCmd = new RelayCommand<PersonViewModel>(
            (pvm) => savePersonCmd(pvm),
            (pvm) => pvm != null,
            keepTargetAlive: true
            ));

        private void savePersonCmd(PersonViewModel personViewModel)
        {
            personViewModel.EndEdit();
        }


        private RelayCommand<PersonViewModel> _cancelPersonCmd;
        public RelayCommand<PersonViewModel> CancelPersonCmd => _cancelPersonCmd ?? (_cancelPersonCmd = new RelayCommand<PersonViewModel>(
            (pvm) => cancelPersonCmd(pvm),
            (pvm) => pvm != null,
            keepTargetAlive: true
            ));

        private void cancelPersonCmd(PersonViewModel personViewModel)
        {
            personViewModel.CancelEdit();
        }

        public MainWindowViewModel()
        {
            Persons.Add(new PersonViewModel("uno", 1));
            Persons.Add(new PersonViewModel("due", 2));
            Persons.Add(new PersonViewModel("tre", 3));
        }
    }
}
