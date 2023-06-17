﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generation date: 6/17/2023 8:41:25 PM
namespace YogaManagement.Client.OdataClient.YogaManagement.Contracts.Enrollment
{
    /// <summary>
    /// There are no comments for EnrollmentDTOSingle in the schema.
    /// </summary>
    [global::Microsoft.OData.Client.OriginalNameAttribute("EnrollmentDTOSingle")]
    public partial class EnrollmentDTOSingle : global::Microsoft.OData.Client.DataServiceQuerySingle<EnrollmentDTO>
    {
        /// <summary>
        /// Initialize a new EnrollmentDTOSingle object.
        /// </summary>
        public EnrollmentDTOSingle(global::Microsoft.OData.Client.DataServiceContext context, string path)
            : base(context, path) {}

        /// <summary>
        /// Initialize a new EnrollmentDTOSingle object.
        /// </summary>
        public EnrollmentDTOSingle(global::Microsoft.OData.Client.DataServiceContext context, string path, bool isComposable)
            : base(context, path, isComposable) {}

        /// <summary>
        /// Initialize a new EnrollmentDTOSingle object.
        /// </summary>
        public EnrollmentDTOSingle(global::Microsoft.OData.Client.DataServiceQuerySingle<EnrollmentDTO> query)
            : base(query) {}

    }
    /// <summary>
    /// There are no comments for EnrollmentDTO in the schema.
    /// </summary>
    /// <KeyProperties>
    /// MemberId
    /// YogaClassId
    /// </KeyProperties>
    [global::Microsoft.OData.Client.Key("MemberId", "YogaClassId")]
    [global::Microsoft.OData.Client.OriginalNameAttribute("EnrollmentDTO")]
    public partial class EnrollmentDTO : global::Microsoft.OData.Client.BaseEntityType, global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new EnrollmentDTO object.
        /// </summary>
        /// <param name="memberId">Initial value of MemberId.</param>
        /// <param name="yogaClassId">Initial value of YogaClassId.</param>
        /// <param name="enrollDate">Initial value of EnrollDate.</param>
        /// <param name="discount">Initial value of Discount.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        public static EnrollmentDTO CreateEnrollmentDTO(int memberId, int yogaClassId, global::System.DateTimeOffset enrollDate, double discount)
        {
            EnrollmentDTO enrollmentDTO = new EnrollmentDTO();
            enrollmentDTO.MemberId = memberId;
            enrollmentDTO.YogaClassId = yogaClassId;
            enrollmentDTO.EnrollDate = enrollDate;
            enrollmentDTO.Discount = discount;
            return enrollmentDTO;
        }
        /// <summary>
        /// There are no comments for Property MemberId in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("MemberId")]
        [global::System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessage = "MemberId is required.")]
        public virtual int MemberId
        {
            get
            {
                return this._MemberId;
            }
            set
            {
                this.OnMemberIdChanging(value);
                this._MemberId = value;
                this.OnMemberIdChanged();
                this.OnPropertyChanged("MemberId");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private int _MemberId;
        partial void OnMemberIdChanging(int value);
        partial void OnMemberIdChanged();
        /// <summary>
        /// There are no comments for Property YogaClassId in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("YogaClassId")]
        [global::System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessage = "YogaClassId is required.")]
        public virtual int YogaClassId
        {
            get
            {
                return this._YogaClassId;
            }
            set
            {
                this.OnYogaClassIdChanging(value);
                this._YogaClassId = value;
                this.OnYogaClassIdChanged();
                this.OnPropertyChanged("YogaClassId");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private int _YogaClassId;
        partial void OnYogaClassIdChanging(int value);
        partial void OnYogaClassIdChanged();
        /// <summary>
        /// There are no comments for Property EnrollDate in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("EnrollDate")]
        [global::System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessage = "EnrollDate is required.")]
        public virtual global::System.DateTimeOffset EnrollDate
        {
            get
            {
                return this._EnrollDate;
            }
            set
            {
                this.OnEnrollDateChanging(value);
                this._EnrollDate = value;
                this.OnEnrollDateChanged();
                this.OnPropertyChanged("EnrollDate");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private global::System.DateTimeOffset _EnrollDate;
        partial void OnEnrollDateChanging(global::System.DateTimeOffset value);
        partial void OnEnrollDateChanged();
        /// <summary>
        /// There are no comments for Property Discount in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("Discount")]
        [global::System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessage = "Discount is required.")]
        public virtual double Discount
        {
            get
            {
                return this._Discount;
            }
            set
            {
                this.OnDiscountChanging(value);
                this._Discount = value;
                this.OnDiscountChanged();
                this.OnPropertyChanged("Discount");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private double _Discount;
        partial void OnDiscountChanging(double value);
        partial void OnDiscountChanged();
        /// <summary>
        /// There are no comments for Property MemberName in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("MemberName")]
        public virtual string MemberName
        {
            get
            {
                return this._MemberName;
            }
            set
            {
                this.OnMemberNameChanging(value);
                this._MemberName = value;
                this.OnMemberNameChanged();
                this.OnPropertyChanged("MemberName");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private string _MemberName;
        partial void OnMemberNameChanging(string value);
        partial void OnMemberNameChanged();
        /// <summary>
        /// There are no comments for Property YogaClassName in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("YogaClassName")]
        public virtual string YogaClassName
        {
            get
            {
                return this._YogaClassName;
            }
            set
            {
                this.OnYogaClassNameChanging(value);
                this._YogaClassName = value;
                this.OnYogaClassNameChanged();
                this.OnPropertyChanged("YogaClassName");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private string _YogaClassName;
        partial void OnYogaClassNameChanging(string value);
        partial void OnYogaClassNameChanged();
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