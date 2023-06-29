﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generation date: 6/29/2023 10:33:07 AM
namespace YogaManagement.Client.OdataClient.YogaManagement.Contracts.TeacherProfile
{
    /// <summary>
    /// There are no comments for TeacherProfileDTOSingle in the schema.
    /// </summary>
    [global::Microsoft.OData.Client.OriginalNameAttribute("TeacherProfileDTOSingle")]
    public partial class TeacherProfileDTOSingle : global::Microsoft.OData.Client.DataServiceQuerySingle<TeacherProfileDTO>
    {
        /// <summary>
        /// Initialize a new TeacherProfileDTOSingle object.
        /// </summary>
        public TeacherProfileDTOSingle(global::Microsoft.OData.Client.DataServiceContext context, string path)
            : base(context, path) {}

        /// <summary>
        /// Initialize a new TeacherProfileDTOSingle object.
        /// </summary>
        public TeacherProfileDTOSingle(global::Microsoft.OData.Client.DataServiceContext context, string path, bool isComposable)
            : base(context, path, isComposable) {}

        /// <summary>
        /// Initialize a new TeacherProfileDTOSingle object.
        /// </summary>
        public TeacherProfileDTOSingle(global::Microsoft.OData.Client.DataServiceQuerySingle<TeacherProfileDTO> query)
            : base(query) {}

    }
    /// <summary>
    /// There are no comments for TeacherProfileDTO in the schema.
    /// </summary>
    /// <KeyProperties>
    /// Id
    /// </KeyProperties>
    [global::Microsoft.OData.Client.Key("Id")]
    [global::Microsoft.OData.Client.OriginalNameAttribute("TeacherProfileDTO")]
    public partial class TeacherProfileDTO : global::Microsoft.OData.Client.BaseEntityType, global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new TeacherProfileDTO object.
        /// </summary>
        /// <param name="ID">Initial value of Id.</param>
        /// <param name="appUserId">Initial value of AppUserId.</param>
        /// <param name="name">Initial value of Name.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        public static TeacherProfileDTO CreateTeacherProfileDTO(int ID, int appUserId, string name)
        {
            TeacherProfileDTO teacherProfileDTO = new TeacherProfileDTO();
            teacherProfileDTO.Id = ID;
            teacherProfileDTO.AppUserId = appUserId;
            teacherProfileDTO.Name = name;
            return teacherProfileDTO;
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
        /// There are no comments for Property AppUserId in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("AppUserId")]
        [global::System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessage = "AppUserId is required.")]
        public virtual int AppUserId
        {
            get
            {
                return this._AppUserId;
            }
            set
            {
                this.OnAppUserIdChanging(value);
                this._AppUserId = value;
                this.OnAppUserIdChanged();
                this.OnPropertyChanged("AppUserId");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private int _AppUserId;
        partial void OnAppUserIdChanging(int value);
        partial void OnAppUserIdChanged();
        /// <summary>
        /// There are no comments for Property Name in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("Name")]
        [global::System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessage = "Name is required.")]
        public virtual string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this.OnNameChanging(value);
                this._Name = value;
                this.OnNameChanged();
                this.OnPropertyChanged("Name");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private string _Name;
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
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
