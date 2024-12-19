using Hobbies.Models;

namespace Hobbies.VM
{
    public class HobbyItemViewModel: ViewModelBase
    {
        private readonly Hobby model;

        public HobbyItemViewModel(Hobby model)
        {
            this.model = model;
        }

        public string NameOfHobby
        {
            get { return model.NameOfHobby; }
            set { model.NameOfHobby = value;
                RaisePropertyChanged();
            }
        }
        public string IconOfHobby
        {
            get { return model.IconOfHobby; }
            set
            {
                model.IconOfHobby = value;
                RaisePropertyChanged();
            }
        }
    }
}
