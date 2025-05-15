using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IdeaManager.Core.Entities;
using IdeaManager.Core.Interfaces;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace IdeaManager.UI.ViewModels
{
    public partial class IdeaFormViewModel : ObservableValidator
    {
        private readonly IIdeaService _ideaService;

        [ObservableProperty]
        [Required(ErrorMessage = "Le titre est obligatoire")]
        private string title;

        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private string errorMessage;

        public IdeaFormViewModel(IIdeaService ideaService)
        {
            _ideaService = ideaService;
        }

        [RelayCommand]
        private async Task SubmitAsync()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Title))
                {
                    ErrorMessage = "Le titre est obligatoire";
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
                ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        #region IDataErrorInfo Implementation
        public string Error => null;

        public string this[string propertyName]
        {
            get
            {
                var validationContext = new ValidationContext(this) { MemberName = propertyName };
                var validationResults = new List<ValidationResult>();
                Validator.TryValidateProperty(GetType().GetProperty(propertyName).GetValue(this), validationContext, validationResults);

                return validationResults.FirstOrDefault()?.ErrorMessage;
            }
        }
        #endregion
    }
}
