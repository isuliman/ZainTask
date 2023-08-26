using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZainTasks.Module
{
    public class ValidationsPhoneNumber
    {
        //[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
        //public sealed class ChangePhoneValidationAttribute : RuleBaseAttribute
        //{
        //    public  ChangePhoneValidationAttribute()
        //    {
        //        CustomMessageTemplate = "Phone cannot be changed for existing customers.";
        //    }

            

        //    //protected override Type RuleType => throw new NotImplementedException();

        //    public override bool IsValidInternal(object value, ITypeInfo targetType, object targetObject)
        //    {
        //        var customer = targetObject as Customer;
        //        if (customer != null && !customer.Session.IsNewObject(this))
        //        {
        //            // Assuming initialPhoneNumber is a property or field in your Customer class
        //            // that holds the initial phone number when the object was loaded
        //            if (customer.Phone != customer.initialPhoneNumber)
        //            {
        //                return false;
        //            }
        //        }
        //        return true;
        //    }
        //}
    }
}
