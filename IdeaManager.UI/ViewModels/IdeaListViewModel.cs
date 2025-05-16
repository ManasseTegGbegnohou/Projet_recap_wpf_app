using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IdeaManager.Core.Entities;
using IdeaManager.Core.Interfaces;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace IdeaManager.UI.ViewModels
{
    public partial class IdeaListViewModel : ObservableObject
    {
        private readonly IIdeaService _ideaService;

        [ObservableProperty]
        private ObservableCollection<Idea> ideas;

        public IdeaListViewModel(IIdeaService ideaService)
        {
            _ideaService = ideaService;
            Ideas = new ObservableCollection<Idea>();
            LoadIdeas();
        }

        private async void LoadIdeas()
        {
            var ideasList = await _ideaService.GetAllAsync();
            Ideas.Clear();
            foreach (var idea in ideasList)
            {
                Ideas.Add(idea);
            }
        }

        [RelayCommand]
        private void Refresh()
        {
            LoadIdeas();
        }
    }
}
