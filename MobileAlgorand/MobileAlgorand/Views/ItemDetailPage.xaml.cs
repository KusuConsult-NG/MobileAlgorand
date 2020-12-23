using System.ComponentModel;
using Xamarin.Forms;
using MobileAlgorand.ViewModels;

namespace MobileAlgorand.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}