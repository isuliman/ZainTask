using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


[DefaultClassOptions]
public class Customer : BaseObject
{
    public Customer(Session session) : base(session) { }

    private string name;
    [Size(40)]
    
    public string Name
    {
        get => name;
        set => SetPropertyValue(nameof(Name), ref name, value);
    }

    private string phone;
    [Size(10)]
    [RuleRegularExpression("05\\d{8}", CustomMessageTemplate = "Phone format should be 05XXXXXXXX")]
 
    public string Phone
    {
        get => phone;
        set => SetPropertyValue(nameof(Phone), ref phone, value);
    }
    
    
    private CustomerStatus status = CustomerStatus.Active;
    [ImmediatePostData]
    [Appearance("ChangeStatusAction_Execute", Enabled = false)]
    public CustomerStatus Status
    {
        get => status;
        set => SetPropertyValue(nameof(Status), ref status, value);
    }
    private string initialPhoneNumber;
    private string initialCustomerName;

    protected override void OnLoaded()
    {
        base.OnLoaded();
        // Store the initial values when load 
        initialPhoneNumber = phone;
        initialCustomerName = name;
    }

    protected override void OnSaving()
    {
        if(!Session.IsNewObject(this) && Session.IsObjectsSaving)
        {
            if (status == CustomerStatus.Banned && !Session.IsObjectToDelete(this) && (phone != initialPhoneNumber || name != initialCustomerName))
                throw new UserFriendlyException("You can't Edit customer if it's Banned");

            if (!IsLoading && (phone != initialPhoneNumber))
                throw new UserFriendlyException("You cannot change the phone number if the user exists!");
            

        }
        
        base.OnSaving();
        
       
    }
  

}

public enum CustomerStatus
{
    Active,
    Inactive,
    Banned
}
