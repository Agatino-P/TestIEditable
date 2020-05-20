using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace TestIEditable
{
    public class PersonViewModel: ViewModelBase, IEditableObject
    {
        private string _name; public string Name { get => _name; set { Set(() => Name, ref _name, value); }}
        private int _age; public int Age { get => _age; set { Set(() => Age, ref _age, value); }}

        private PersonViewModel tempPersonViewModel;

        public PersonViewModel(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void BeginEdit()
        {
            tempPersonViewModel = new PersonViewModel(Name, Age);

        }

        public void CancelEdit()
        {
            if (tempPersonViewModel == null)
                return;
            Name = tempPersonViewModel.Name;
            Age = tempPersonViewModel.Age;
        }
         
        public void EndEdit()
        {
            tempPersonViewModel = null;
        }

    }
}
