using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;

public class CustomerController : ObjectViewController<DetailView, Customer>
{
    public CustomerController()
    {
        SimpleAction changeStatusAction = new SimpleAction(this, "ChangeStatus", PredefinedCategory.Edit);
        changeStatusAction.Caption = "Change Status";
        changeStatusAction.Execute += ChangeStatusAction_Execute;
        changeStatusAction.SelectionDependencyType = SelectionDependencyType.RequireSingleObject;
    }

    private void ChangeStatusAction_Execute(object sender, SimpleActionExecuteEventArgs e)
    {
        Customer customer = View.CurrentObject as Customer;
        if (customer != null)
        {
            ChangeCustomerStatus(customer);
            View.ObjectSpace.CommitChanges();
        }
    }

    private void ChangeCustomerStatus(Customer customer)
    {
        if (customer.Session.IsNewObject(customer))
        {
            customer.Status = CustomerStatus.Active;
        }
        else
        {
            if (customer.Status == CustomerStatus.Active)
            {
                customer.Status = CustomerStatus.Inactive;
            }
            else if (customer.Status == CustomerStatus.Inactive)
            {
                customer.Status = CustomerStatus.Banned;
            }
            else if (customer.Status == CustomerStatus.Banned)
            {
                customer.Status = CustomerStatus.Active;
            }
        }
    }
}
