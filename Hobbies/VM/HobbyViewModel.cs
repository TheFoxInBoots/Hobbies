using System.Collections.ObjectModel;
using Hobbies.Command;
using Hobbies.Models;

namespace Hobbies.VM
{
    public class HobbyViewModel : ViewModelBase
    {
		private ObservableCollection<HobbyItemViewModel> hobbies = new();

		public ObservableCollection<HobbyItemViewModel> Hobbies
		{
			get { return hobbies; }
			set 
            { 
                hobbies = value;
                RaisePropertyChanged();
            }
		}

        private HobbyItemViewModel selectedHobby;

        public HobbyItemViewModel SelectedHobby
        {
            get { return selectedHobby; }
            set 
            { 
                selectedHobby = value;
                RaisePropertyChanged();
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public DelegateCommand AddCommand { get; }
        public DelegateCommand DeleteCommand { get; }
        public DelegateCommand LoadCommand { get; }

        public HobbyViewModel()
        {
            hobbies.Add(new HobbyItemViewModel(new Hobby() { NameOfHobby="Drawing", IconOfHobby= "✏️" }));
            hobbies.Add(new HobbyItemViewModel(new Hobby() { NameOfHobby = "Programming", IconOfHobby = "💻" }));
            hobbies.Add(new HobbyItemViewModel(new Hobby() { NameOfHobby = "Gaming", IconOfHobby = "🎮" }));

            AddCommand = new DelegateCommand(AddHobby);
            DeleteCommand = new DelegateCommand(DeleteHobby, CanDelete);
            LoadCommand = new DelegateCommand(async _ => await LoadAsync());
        }

        public async Task LoadAsync()
        {
            if (Hobbies.Any())
            {
                return;
            }
        }

        private void AddHobby(object? parameter)
        {
            Hobby hobby = new Hobby() { NameOfHobby = "NewHobby" };
            var hobbyVM = new HobbyItemViewModel(hobby);
            Hobbies.Add(hobbyVM);
            SelectedHobby = hobbyVM; 
        }
        public void DeleteHobby(object? parameter)
        {
            if (SelectedHobby is not null)
            {
                Hobbies.Remove(SelectedHobby);
                SelectedHobby = null;
            }
        }
        private bool CanDelete(object? parameter) => SelectedHobby is not null;
    }
}
