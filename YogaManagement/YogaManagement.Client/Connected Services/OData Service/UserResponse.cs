﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generation date: 6/10/2023 12:38:33 PM
namespace YogaManagement.Client.OdataClient.YogaManagement.Contracts.Authority.Response
{
    /// <summary>
    /// There are no comments for UserResponseSingle in the schema.
    /// </summary>
    [global::Microsoft.OData.Client.OriginalNameAttribute("UserResponseSingle")]
    public partial class UserResponseSingle : global::Microsoft.OData.Client.DataServiceQuerySingle<UserResponse>
    {
        /// <summary>
        /// Initialize a new UserResponseSingle object.
        /// </summary>
        public UserResponseSingle(global::Microsoft.OData.Client.DataServiceContext context, string path)
            : base(context, path) {}

        /// <summary>
        /// Initialize a new UserResponseSingle object.
        /// </summary>
        public UserResponseSingle(global::Microsoft.OData.Client.DataServiceContext context, string path, bool isComposable)
            : base(context, path, isComposable) {}

        /// <summary>
        /// Initialize a new UserResponseSingle object.
        /// </summary>
        public UserResponseSingle(global::Microsoft.OData.Client.DataServiceQuerySingle<UserResponse> query)
            : base(query) {}

    }
    /// <summary>
    /// There are no comments for UserResponse in the schema.
    /// </summary>
    /// <KeyProperties>
    /// Id
    /// </KeyProperties>
    [global::Microsoft.OData.Client.Key("Id")]
    [global::Microsoft.OData.Client.OriginalNameAttribute("UserResponse")]
    public partial class UserResponse : global::Microsoft.OData.Client.BaseEntityType, global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new UserResponse object.
        /// </summary>
        /// <param name="ID">Initial value of Id.</param>
        /// <param name="firstName">Initial value of FirstName.</param>
        /// <param name="lastName">Initial value of LastName.</param>
        /// <param name="status">Initial value of Status.</param>
        /// <param name="address">Initial value of Address.</param>
        /// <param name="email">Initial value of Email.</param>
        /// <param name="role">Initial value of Role.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        public static UserResponse CreateUserResponse(int ID, 
                    string firstName, 
                    string lastName, 
                    string status, 
                    string address, 
                    string email, 
                    string role)
        {
            UserResponse userResponse = new UserResponse();
            userResponse.Id = ID;
            userResponse.FirstName = firstName;
            userResponse.LastName = lastName;
            userResponse.Status = status;
            userResponse.Address = address;
            userResponse.Email = email;
            userResponse.Role = role;
            return userResponse;
        }
        /// <summary>
        /// There are no comments for Property Id in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("Id")]
        [global::System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessage = "Id is required.")]
        public virtual int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                this.OnIdChanging(value);
                this._Id = value;
                this.OnIdChanged();
                this.OnPropertyChanged("Id");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private int _Id;
        partial void OnIdChanging(int value);
        partial void OnIdChanged();
        /// <summary>
        /// There are no comments for Property FirstName in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("FirstName")]
        [global::System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessage = "FirstName is required.")]
        public virtual string FirstName
        {
            get
            {
                return this._FirstName;
            }
            set
            {
                this.OnFirstNameChanging(value);
                this._FirstName = value;
                this.OnFirstNameChanged();
                this.OnPropertyChanged("FirstName");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private string _FirstName;
        partial void OnFirstNameChanging(string value);
        partial void OnFirstNameChanged();
        /// <summary>
        /// There are no comments for Property LastName in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("LastName")]
        [global::System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessage = "LastName is required.")]
        public virtual string LastName
        {
            get
            {
                return this._LastName;
            }
            set
            {
                this.OnLastNameChanging(value);
                this._LastName = value;
                this.OnLastNameChanged();
                this.OnPropertyChanged("LastName");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private string _LastName;
        partial void OnLastNameChanging(string value);
        partial void OnLastNameChanged();
        /// <summary>
        /// There are no comments for Property Status in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("Status")]
        [global::System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessage = "Status is required.")]
        public virtual string Status
        {
            get
            {
                return this._Status;
            }
            set
            {
                this.OnStatusChanging(value);
                this._Status = value;
                this.OnStatusChanged();
                this.OnPropertyChanged("Status");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private string _Status;
        partial void OnStatusChanging(string value);
        partial void OnStatusChanged();
        /// <summary>
        /// There are no comments for Property Address in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("Address")]
        [global::System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessage = "Address is required.")]
        public virtual string Address
        {
            get
            {
                return this._Address;
            }
            set
            {
                this.OnAddressChanging(value);
                this._Address = value;
                this.OnAddressChanged();
                this.OnPropertyChanged("Address");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private string _Address;
        partial void OnAddressChanging(string value);
        partial void OnAddressChanged();
        /// <summary>
        /// There are no comments for Property Email in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("Email")]
        [global::System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessage = "Email is required.")]
        public virtual string Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                this.OnEmailChanging(value);
                this._Email = value;
                this.OnEmailChanged();
                this.OnPropertyChanged("Email");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private string _Email;
        partial void OnEmailChanging(string value);
        partial void OnEmailChanged();
        /// <summary>
        /// There are no comments for Property Role in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("Role")]
        [global::System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessage = "Role is required.")]
        public virtual string Role
        {
            get
            {
                return this._Role;
            }
            set
            {
                this.OnRoleChanging(value);
                this._Role = value;
                this.OnRoleChanged();
                this.OnPropertyChanged("Role");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private string _Role;
        partial void OnRoleChanging(string value);
        partial void OnRoleChanged();
        /// <summary>
        /// This event is raised when the value of the property is changed
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// The value of the property is changed
        /// </summary>
        /// <param name="property">property name</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
}