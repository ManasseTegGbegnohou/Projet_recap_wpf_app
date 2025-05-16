using IdeaManager.UI.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace IdeaManager.UI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUIServices(this IServiceCollection services)
        {
            // Register ViewModels
            services.AddSingleton<MainViewModel>();
            services.AddTransient<IdeaListViewModel>();
            services.AddTransient<IdeaFormViewModel>();

            // Register MainWindow
            services.AddSingleton<MainWindow>();

            return services;
        }
    }
}