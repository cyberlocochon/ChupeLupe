using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ChupeLupe.Views.Controls
{
    public partial class BaseNavigationPage : NavigationPage
    {
        public BaseNavigationPage(Page root) : base(root)
        {
            InitializeComponent();
        }
    }
}
