using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ChupeLupe.Helpers;
using ChupeLupe.Models;
using ChupeLupe.ViewModels.Helpers;
using ChupeLupe.Views;
using Xamarin.Forms;

namespace ChupeLupe.ViewModels
{
    public class PromotionListViewModel : BaseViewModel
    {
        public Command GetPromotionsCommand { get; set; }

        public ObservableCollection<Promotion> PromotionList { get; set; }

    
        private bool _isBusy;

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                SetValue(ref _isBusy, value);
                Device.BeginInvokeOnMainThread(GetPromotionsCommand.ChangeCanExecute);
            }
        }


        public PromotionListViewModel(INavigation navigation,IDependencyServices dependencyServices ) : base(navigation, dependencyServices)
        {
            GetPromotionsCommand = new Command(async (obj) =>
            await ExecuteGetPromotionsCommand(obj), (obj) => !IsBusy);
        }

        async Task ExecuteGetPromotionsCommand(object obj)
        {
            //List<Promotion> PromotionsList;
            try
            {
                if (IsBusy)
                {
                    return;
                }

                IsBusy = true;

                var localPromotionList = new List<Promotion>();
                localPromotionList = await WebApi.GetPromotions();

                if(!localPromotionList.Any())
                {
                    IsBusy = false;
                    return;
                }

                PromotionList = new ObservableCollection<Promotion>(localPromotionList);
                OnPropertyChanged(nameof(PromotionList));

                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                Console.WriteLine(ex.Message);
            }
        }

    }
}


