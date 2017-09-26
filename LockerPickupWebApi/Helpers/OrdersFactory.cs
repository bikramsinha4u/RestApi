using LockerPickupDAL.Models;
using LockerPickupDTO;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LockerPickupWebApi.Helpers
{
    public static class OrdersFactory
    {
        

        //public object CreateDataShapedObject(Expense expense, List<string> lstOfFields)
        //{

        //    return CreateDataShapedObject(CreateExpense(expense), lstOfFields);
        //}


        public static  object CreateDataShapedObject(OrdersDTO ordersData, List<string> lstOfFields)
        {

            if (!lstOfFields.Any())
            {
                return ordersData;
            }
            else
            {

                // create a new ExpandoObject & dynamically create the properties for this object

                ExpandoObject objectToReturn = new ExpandoObject();
                foreach (var field in lstOfFields)
                {
                    // need to include public and instance, b/c specifying a binding flag overwrites the
                    // already-existing binding flags.

                    var fieldValue = ordersData.GetType()
                        .GetProperty(field, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                        .GetValue(ordersData, null);

                    // add the field to the ExpandoObject
                    ((IDictionary<String, Object>)objectToReturn).Add(field, fieldValue);
                }

                return objectToReturn;
            }
        }

    }
}
