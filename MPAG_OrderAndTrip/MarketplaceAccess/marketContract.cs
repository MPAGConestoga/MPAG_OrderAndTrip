using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyerAccessToMarketplace
{
    /* 
    * \class Market Contract
    * 
    * \brief Purpose of this is to model the
    * database extraction 
    * 
    * \see
    * 
    * \author Amy Dayasundara
    */ 
    public class marketContract
    {
        public string clientName { get; set; }
        public int jobType { get; set; }
        public int quantity { get; set; }
        public string origin { get; set; }
        public string destination { get; set; }
        public int vanType { get; set; }

        public marketContract() { }

        //Save?
         
        //GetById..?

        ///
        /// \brief Once the internal contracts are retireved, they are inserted into a list
        /// 
        /// \details <b>Get Internal Contract</b>
        /// 
        /// \param none
        /// 
        /// \return Returns a list of the current internal contracts being generated
        /// 
        /// \see
        ///

        public List<marketContract> GetMarketContracts()
        {
            var contracts = new ContractMarketDals().GetMarketContracts();
            return contracts;
        }
        //Tables

        //Delete

    }
}

