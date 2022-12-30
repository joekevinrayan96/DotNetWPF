using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFPlayground.Models;

namespace WPFPlayground.ViewModels
{
    public class ShellViewModel: Conductor<object>//Screen
    {

        public ShellViewModel()
        {
            People.Add(new PersonModel { FirstName = "Joe Kevin", LastName = "Rayan" });
            People.Add(new PersonModel { FirstName = "Tim", LastName = "Corey" });
            People.Add(new PersonModel { FirstName = "Sue", LastName = "Storm" });
        }

        //------------------------------------------------------

        private string _firstName = "Tim";

        public string FirstName
        {
            get 
            { 
                return _firstName; 
            }
            set 
            { 
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        //------------------------------------------------------

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set 
            { 
                _lastName = value; 
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        //------------------------------------------------------

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
           
        }

        //------------------------------------------------------

        private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();

        public BindableCollection<PersonModel> People
        {
            get { return _people; }
            set { _people = value; }    
        }


        //------------------------------------------------------

        private PersonModel _selectedPerson;
       
        public PersonModel SelectedPerson 
        {
            get { return _selectedPerson; }
            set 
            { 
                _selectedPerson = value;
                NotifyOfPropertyChange(() => SelectedPerson);
            }
        }

        public bool CanClearText(string firstName, string lastName)
        {
            return !String.IsNullOrWhiteSpace(firstName) || !String.IsNullOrWhiteSpace(lastName);
        }

        public void ClearText(string firstName, string lastName)
        {
            FirstName = "";
            LastName = "";
        }

        public void LoadPageOne()
        {
            //ActivateItem
            ActivateItemAsync(new FirstChildViewModel()); 
        }

        public void LoadPageTwo()
        {
            ActivateItemAsync(new SecondChildViewModel());

        }



    }
}
