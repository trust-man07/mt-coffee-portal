﻿
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Collections.Generic;

namespace MtCoffee.Web.Models.GiftCard
{
    public class GcTransactionType
    {
//---------------------------------------------------------------------------------------------------
// V A L U E S _ L I S T 
//---------------------------------------------------------------------------------------------------



        ///<summary>
        /// "005"
        ///</summary>
        public static readonly GcTransactionType ActivateCard = new GcTransactionType(){ Name = "ActivateCard", Value = "005"};


        ///<summary>
        /// "024"
        ///</summary>
        public static readonly GcTransactionType ActivatePoints = new GcTransactionType(){ Name = "ActivatePoints", Value = "024"};


        ///<summary>
        /// "020"
        ///</summary>
        public static readonly GcTransactionType AddPoints = new GcTransactionType(){ Name = "AddPoints", Value = "020"};


        ///<summary>
        /// "003"
        ///</summary>
        public static readonly GcTransactionType AddValue = new GcTransactionType(){ Name = "AddValue", Value = "003"};


        ///<summary>
        /// "001"
        ///</summary>
        public static readonly GcTransactionType BalanceInquiry = new GcTransactionType(){ Name = "BalanceInquiry", Value = "001"};


        ///<summary>
        /// "014"
        ///</summary>
        public static readonly GcTransactionType BalanceTransfer = new GcTransactionType(){ Name = "BalanceTransfer", Value = "014"};


        ///<summary>
        /// "118"
        ///</summary>
        public static readonly GcTransactionType CustomerService = new GcTransactionType(){ Name = "CustomerService", Value = "118"};


        ///<summary>
        /// "007"
        ///</summary>
        public static readonly GcTransactionType DeactivateWithNoRefund = new GcTransactionType(){ Name = "DeactivateWithNoRefund", Value = "007"};


        ///<summary>
        /// "006"
        ///</summary>
        public static readonly GcTransactionType DeactivateWithRefund = new GcTransactionType(){ Name = "DeactivateWithRefund", Value = "006"};


        ///<summary>
        /// "022"
        ///</summary>
        public static readonly GcTransactionType ExpireDateAdjust = new GcTransactionType(){ Name = "ExpireDateAdjust", Value = "022"};


        ///<summary>
        /// "200"
        ///</summary>
        public static readonly GcTransactionType History = new GcTransactionType(){ Name = "History", Value = "200"};


        ///<summary>
        /// "026"
        ///</summary>
        public static readonly GcTransactionType PointBalanceTransfer = new GcTransactionType(){ Name = "PointBalanceTransfer", Value = "026"};


        ///<summary>
        /// "210"
        ///</summary>
        public static readonly GcTransactionType PointHistory = new GcTransactionType(){ Name = "PointHistory", Value = "210"};


        ///<summary>
        /// "025"
        ///</summary>
        public static readonly GcTransactionType PointRefund = new GcTransactionType(){ Name = "PointRefund", Value = "025"};


        ///<summary>
        /// "023"
        ///</summary>
        public static readonly GcTransactionType PointsBalanceInquiry = new GcTransactionType(){ Name = "PointsBalanceInquiry", Value = "023"};


        ///<summary>
        /// "002"
        ///</summary>
        public static readonly GcTransactionType Redeem = new GcTransactionType(){ Name = "Redeem", Value = "002"};


        ///<summary>
        /// "021"
        ///</summary>
        public static readonly GcTransactionType RedeemPoints = new GcTransactionType(){ Name = "RedeemPoints", Value = "021"};


        ///<summary>
        /// "008"
        ///</summary>
        public static readonly GcTransactionType ReissueCard = new GcTransactionType(){ Name = "ReissueCard", Value = "008"};


        ///<summary>
        /// "011"
        ///</summary>
        public static readonly GcTransactionType SignOff = new GcTransactionType(){ Name = "SignOff", Value = "011"};


        ///<summary>
        /// "010"
        ///</summary>
        public static readonly GcTransactionType SignOn = new GcTransactionType(){ Name = "SignOn", Value = "010"};


        ///<summary>
        /// "009"
        ///</summary>
        public static readonly GcTransactionType StoreCredit = new GcTransactionType(){ Name = "StoreCredit", Value = "009"};


        ///<summary>
        /// "012"
        ///</summary>
        public static readonly GcTransactionType TipAdjust = new GcTransactionType(){ Name = "TipAdjust", Value = "012"};


        ///<summary>
        /// "027"
        ///</summary>
        public static readonly GcTransactionType VoidPoints = new GcTransactionType(){ Name = "VoidPoints", Value = "027"};


        ///<summary>
        /// "004"
        ///</summary>
        public static readonly GcTransactionType VoidTransaction = new GcTransactionType(){ Name = "VoidTransaction", Value = "004"};


		private static List<GcTransactionType> _list { get; set; } = null;
		public static List<GcTransactionType> ToList()
		{
			if (_list == null)
			{
				_list = typeof(GcTransactionType).GetFields().Where(x => x.IsStatic && x.IsPublic && x.FieldType == typeof(GcTransactionType))
					.Select(x => x.GetValue(null)).OfType<GcTransactionType>().ToList();
			}

			return _list;
		}

		public static List<GcTransactionType> Values()
		{
			return ToList();
		}

        /// <summary>
        /// Returns the enum value based on the matching Name of the enum. Case-insensitive search.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static GcTransactionType ValueOf(string key)
		{
            return ToList().FirstOrDefault(x => string.Compare(x.Name, key, true) == 0);
        }


//---------------------------------------------------------------------------------------------------
// I N S T A N C E _ D E F I N I T I O N 
//---------------------------------------------------------------------------------------------------		
        public string Name { get; set; }
        public string  Value { get; set; }
        public override string ToString() { return this.Name; }

		/// <summary>
        /// Implcitly converts to string.
        /// </summary>
        /// <param name="d"></param>
        public static implicit operator string(GcTransactionType d)
        {
            return d.ToString();
        }

        /// <summary>
        /// Compares based on the == method. Handles nulls gracefully.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(GcTransactionType a, GcTransactionType b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Compares based on the .Equals method. Handles nulls gracefully.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(GcTransactionType a, GcTransactionType b)
        {
            return a?.ToString() == b?.ToString();
        }

        /// <summary>
        /// Compares based on the .ToString() method
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public override bool Equals(object o)
        {
            return this.ToString() == o?.ToString();
        }

        /// <summary>
        /// Compares based on the .Name property
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}
    



