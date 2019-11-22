using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTest.Models;

namespace WPFTest.ViewModels
{
    /**
    * \Class PendingViewModel
    * \Brief View model for the handling of pending orders
    * \Details The pending view model loads and handles the information that will be 
    * displayed to the user in the pending order list in the planner role. Will handle 
    * the generation and storage of new pending orders for the pending order view.
    */
    public class PendingViewModel : ObservableObject
    {
        private PendingOrders _selectedPendingOrder;
        public PendingOrders SelectedPendingOrder
        {
            get { return _selectedPendingOrder; }
            set { OnPropertyChanged(ref _selectedPendingOrder, value); }
        }

      
        public ObservableCollection<PendingOrders> PendingOrders { get; private set; }

        /// <summary>
        /// Constructor for PendingViewModel
        /// </summary>
        //public PendingOrdersViewModel()
        //{

        //}

        /// <summary>
        /// Creates a new ObservableCollection entry every time a new pendingOrders 
        /// object is created
        /// </summary>
        /// <param name="pendingOrders"> <b>IEnumerable<PendingOrders></b> - a new pending order object to be added to the collection</param> 
        public void LoadPendingOrders(IEnumerable<PendingOrders> pendingOrders) // allows one to avoid doing a for each loop to add contacts manually
        {
            PendingOrders = new ObservableCollection<PendingOrders>(pendingOrders);
            OnPropertyChanged("PendingOrders");
        }
    }


}
