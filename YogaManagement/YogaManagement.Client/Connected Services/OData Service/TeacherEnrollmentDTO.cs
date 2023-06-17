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
namespace YogaManagement.Client.OdataClient.YogaManagement.Contracts.TeacherEnrollment
{
    /// <summary>
    /// There are no comments for TeacherEnrollmentDTOSingle in the schema.
    /// </summary>
    [global::Microsoft.OData.Client.OriginalNameAttribute("TeacherEnrollmentDTOSingle")]
    public partial class TeacherEnrollmentDTOSingle : global::Microsoft.OData.Client.DataServiceQuerySingle<TeacherEnrollmentDTO>
    {
        /// <summary>
        /// Initialize a new TeacherEnrollmentDTOSingle object.
        /// </summary>
        public TeacherEnrollmentDTOSingle(global::Microsoft.OData.Client.DataServiceContext context, string path)
            : base(context, path) {}

        /// <summary>
        /// Initialize a new TeacherEnrollmentDTOSingle object.
        /// </summary>
        public TeacherEnrollmentDTOSingle(global::Microsoft.OData.Client.DataServiceContext context, string path, bool isComposable)
            : base(context, path, isComposable) {}

        /// <summary>
        /// Initialize a new TeacherEnrollmentDTOSingle object.
        /// </summary>
        public TeacherEnrollmentDTOSingle(global::Microsoft.OData.Client.DataServiceQuerySingle<TeacherEnrollmentDTO> query)
            : base(query) {}

    }
    /// <summary>
    /// There are no comments for TeacherEnrollmentDTO in the schema.
    /// </summary>
    /// <KeyProperties>
    /// Id
    /// </KeyProperties>
    [global::Microsoft.OData.Client.Key("Id")]
    [global::Microsoft.OData.Client.OriginalNameAttribute("TeacherEnrollmentDTO")]
    public partial class TeacherEnrollmentDTO : global::Microsoft.OData.Client.BaseEntityType, global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new TeacherEnrollmentDTO object.
        /// </summary>
        /// <param name="ID">Initial value of Id.</param>
        /// <param name="isActive">Initial value of IsActive.</param>
        /// <param name="startDate">Initial value of StartDate.</param>
        /// <param name="endDate">Initial value of EndDate.</param>
        /// <param name="teacherProfileId">Initial value of TeacherProfileId.</param>
        /// <param name="yogaClassId">Initial value of YogaClassId.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        public static TeacherEnrollmentDTO CreateTeacherEnrollmentDTO(int ID, 
                    bool isActive, 
                    global::System.DateTimeOffset startDate, 
                    global::System.DateTimeOffset endDate, 
                    int teacherProfileId, 
                    int yogaClassId)
        {
            TeacherEnrollmentDTO teacherEnrollmentDTO = new TeacherEnrollmentDTO();
            teacherEnrollmentDTO.Id = ID;
            teacherEnrollmentDTO.IsActive = isActive;
            teacherEnrollmentDTO.StartDate = startDate;
            teacherEnrollmentDTO.EndDate = endDate;
            teacherEnrollmentDTO.TeacherProfileId = teacherProfileId;
            teacherEnrollmentDTO.YogaClassId = yogaClassId;
            return teacherEnrollmentDTO;
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
        /// There are no comments for Property IsActive in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("IsActive")]
        [global::System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessage = "IsActive is required.")]
        public virtual bool IsActive
        {
            get
            {
                return this._IsActive;
            }
            set
            {
                this.OnIsActiveChanging(value);
                this._IsActive = value;
                this.OnIsActiveChanged();
                this.OnPropertyChanged("IsActive");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private bool _IsActive;
        partial void OnIsActiveChanging(bool value);
        partial void OnIsActiveChanged();
        /// <summary>
        /// There are no comments for Property StartDate in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("StartDate")]
        [global::System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessage = "StartDate is required.")]
        public virtual global::System.DateTimeOffset StartDate
        {
            get
            {
                return this._StartDate;
            }
            set
            {
                this.OnStartDateChanging(value);
                this._StartDate = value;
                this.OnStartDateChanged();
                this.OnPropertyChanged("StartDate");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private global::System.DateTimeOffset _StartDate;
        partial void OnStartDateChanging(global::System.DateTimeOffset value);
        partial void OnStartDateChanged();
        /// <summary>
        /// There are no comments for Property EndDate in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("EndDate")]
        [global::System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessage = "EndDate is required.")]
        public virtual global::System.DateTimeOffset EndDate
        {
            get
            {
                return this._EndDate;
            }
            set
            {
                this.OnEndDateChanging(value);
                this._EndDate = value;
                this.OnEndDateChanged();
                this.OnPropertyChanged("EndDate");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private global::System.DateTimeOffset _EndDate;
        partial void OnEndDateChanging(global::System.DateTimeOffset value);
        partial void OnEndDateChanged();
        /// <summary>
        /// There are no comments for Property TeacherProfileId in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("TeacherProfileId")]
        [global::System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessage = "TeacherProfileId is required.")]
        public virtual int TeacherProfileId
        {
            get
            {
                return this._TeacherProfileId;
            }
            set
            {
                this.OnTeacherProfileIdChanging(value);
                this._TeacherProfileId = value;
                this.OnTeacherProfileIdChanged();
                this.OnPropertyChanged("TeacherProfileId");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private int _TeacherProfileId;
        partial void OnTeacherProfileIdChanging(int value);
        partial void OnTeacherProfileIdChanged();
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
        /// There are no comments for Property TeacherName in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("TeacherName")]
        public virtual string TeacherName
        {
            get
            {
                return this._TeacherName;
            }
            set
            {
                this.OnTeacherNameChanging(value);
                this._TeacherName = value;
                this.OnTeacherNameChanged();
                this.OnPropertyChanged("TeacherName");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private string _TeacherName;
        partial void OnTeacherNameChanging(string value);
        partial void OnTeacherNameChanged();
        /// <summary>
        /// There are no comments for Property ClassName in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("ClassName")]
        public virtual string ClassName
        {
            get
            {
                return this._ClassName;
            }
            set
            {
                this.OnClassNameChanging(value);
                this._ClassName = value;
                this.OnClassNameChanged();
                this.OnPropertyChanged("ClassName");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private string _ClassName;
        partial void OnClassNameChanging(string value);
        partial void OnClassNameChanged();
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
