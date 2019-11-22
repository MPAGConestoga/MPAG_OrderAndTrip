using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuyerAccessToMarketplace;

namespace BuyerAccessToMarketplace
{
    //TBD
    public class InternalContract
    {
        //InternalID representing Supplier - Product Management
        public int InternalId { get; set; }
        public string ClientName { get; set; }
        public InternalContract() { }

        ///// Don't include into this Doxygen run
        ///// \brief Once the internal contracts are retireved, they are inserted into a list
        ///// 
        ///// \details <b>Get Internal Contract</b>
        ///// 
        ///// \param none
        ///// 
        ///// \return Returns a list of the current internal contracts being generated
        ///// 
        ///// \see
        /////
        public List<InternalContract> GetInternalContracts()
        {
            var internalContract = new ContractMarketDals().GetInternalContracts();
            return internalContract;
        }
    }
}
