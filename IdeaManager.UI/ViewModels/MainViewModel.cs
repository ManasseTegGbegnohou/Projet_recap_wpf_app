using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Controls;

namespace IdeaManager.UI.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private UserControl currentView;

        private readonly IdeaListViewModel ideaListViewModel;
        private readonly IdeaFormViewModel ideaFormViewModel;

        public MainViewModel(IdeaListViewModel ideaListViewModel, IdeaFormViewModel ideaFormViewModel)
        {
            this.ideaListViewModel = ideaListViewModel;
            this.ideaFormViewModel = ideaFormViewModel;
            NavigateToIdeaList();
        }

        [RelayCommand]
        private void NavigateToIdeaList()
        {
            CurrentView = new Views.IdeaListView { DataContext = ideaListViewModel };
        }

        [RelayCommand]
        private void NavigateToIdeaForm()
        {
            CurrentView = new Views.IdeaFormView { DataContext = ideaFormViewModel };
        }
    }
} 