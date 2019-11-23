using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTest
{
    /**
    * \Class OrderViewModel
    * \Brief View model for the handling of the main window view
    * \Details The app view model loads and handles the information that will be 
    * displayed to the user on the landing page for the planner role. Instantiates
    * a child instance of the order view model which will be displayed in the window beneath
    * the upper bar of the app.
    */
    public class AppViewModel : ObservableObject
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { OnPropertyChanged(ref _currentView, value);  }
        }

        private ViewModels.OrderViewModel _orderVM;
        public ViewModels.OrderViewModel OrderVM
        {
            get { return _orderVM; }
            set { OnPropertyChanged(ref _orderVM, value); }
        }

        public AppViewModel()
        {
            OrderVM = new ViewModels.OrderViewModel();
            CurrentView = OrderVM;
        }
    }
}
