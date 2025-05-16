using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IdeaManager.Core.Entities;
using IdeaManager.Core.Interfaces;
using System.Threading.Tasks;

namespace IdeaManager.UI.ViewModels
{
    public partial class IdeaFormViewModel : ObservableObject
    {
        private readonly IIdeaService _ideaService;

        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private string description;

        public IdeaFormViewModel(IIdeaService ideaService)
        {
            _ideaService = ideaService;
        }

        [RelayCommand]
        private async Task SubmitAsync()
        {
            if (string.IsNullOrWhiteSpace(Title))
            {
                return;
            }

            var idea = new Idea
            {
                Title = Title,
                Description = Description
            };

            await _ideaService.SubmitIdeaAsync(idea);
            Title = string.Empty;
            Description = string.Empty;
        }
    }
}
