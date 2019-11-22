﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAG_OrderAndTrip
{
     /**
     * \brief   The Invoice class represents the invoice created for a customer once the order has been completed. 
     * \details The Address class holds all the relevant information about an invoice:Date issued, amount_due, invoice status
     * customer information, and order information
     */
    class Invoice
    {
        /// <summary>
        /// The default constructor for the Invoice class
        /// </summary>
        public Invoice()
        {

        }

        /// <summary>
        /// This method is used to generate an invoice based on the order informaiton
        /// </summary>
        /// <param name="reviewedOrder"> <b>Order</b> - Order to be invoiced</param>
        /// \return string - to be transformed into a PDF
        public string GenerateInvoice(Order reviewedOrder)
        {
            // Stubbed Out ----------------------- IMPLEMENT -----------------------//
            return "SHOULD RETURN A STRING TO BE TRANSFORM INTO A PDF";
        }
    }
}
