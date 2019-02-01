using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using ChupeLupe.ViewModels;
using ChupeLupe.Services;
using ChupeLupe.Helpers;

namespace ChupeLupe.Views
{

    public class GradientColorStack : StackLayout
    {
        public Color StartColor { get; set; }
        public Color EndColor { get; set; }
    }

    public partial class PromotionsList : ContentPage
    {

        PromotionListViewModel _vm;
        public PromotionsList()
        {
            InitializeComponent();
            _vm = new PromotionListViewModel(Navigation, new DeIDependencyServicesWrapper());
            BindingContext = _vm;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _vm.GetPromotionsCommand.Execute(null);

        }
    }
    }
