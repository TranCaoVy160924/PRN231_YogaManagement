﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generation date: 6/25/2023 3:40:15 PM
namespace YogaManagement.Client.OdataClient.YogaManagement.Contracts.YogaClass
{
    /// <summary>
    /// There are no comments for YogaClassDTOSingle in the schema.
    /// </summary>
    [global::Microsoft.OData.Client.OriginalNameAttribute("YogaClassDTOSingle")]
    public partial class YogaClassDTOSingle : global::Microsoft.OData.Client.DataServiceQuerySingle<YogaClassDTO>
    {
        /// <summary>
        /// Initialize a new YogaClassDTOSingle object.
        /// </summary>
        public YogaClassDTOSingle(global::Microsoft.OData.Client.DataServiceContext context, string path)
            : base(context, path) {}

        /// <summary>
        /// Initialize a new YogaClassDTOSingle object.
        /// </summary>
        public YogaClassDTOSingle(global::Microsoft.OData.Client.DataServiceContext context, string path, bool isComposable)
            : base(context, path, isComposable) {}

        /// <summary>
        /// Initialize a new YogaClassDTOSingle object.
        /// </summary>
        public YogaClassDTOSingle(global::Microsoft.OData.Client.DataServiceQuerySingle<YogaClassDTO> query)
            : base(query) {}

    }
    /// <summary>
    /// There are no comments for YogaClassDTO in the schema.
    /// </summary>
    /// <KeyProperties>
    /// Id
    /// </KeyProperties>
    [global::Microsoft.OData.Client.Key("Id")]
    [global::Microsoft.OData.Client.OriginalNameAttribute("YogaClassDTO")]
    public partial class YogaClassDTO : global::Microsoft.OData.Client.BaseEntityType, global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new YogaClassDTO object.
        /// </summary>
        /// <param name="ID">Initial value of Id.</param>
        /// <param name="name">Initial value of Name.</param>
        /// <param name="size">Initial value of Size.</param>
        /// <param name="yogaClassStatus">Initial value of YogaClassStatus.</param>
        /// <param name="courseId">Initial value of CourseId.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        public static YogaClassDTO CreateYogaClassDTO(int ID, string name, int size, string yogaClassStatus, int courseId)
        {
            YogaClassDTO yogaClassDTO = new YogaClassDTO();
            yogaClassDTO.Id = ID;
            yogaClassDTO.Name = name;
            yogaClassDTO.Size = size;
            yogaClassDTO.YogaClassStatus = yogaClassStatus;
            yogaClassDTO.CourseId = courseId;
            return yogaClassDTO;
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
        /// There are no comments for Property Size in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("Size")]
        [global::System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessage = "Size is required.")]
        public virtual int Size
        {
            get
            {
                return this._Size;
            }
            set
            {
                this.OnSizeChanging(value);
                this._Size = value;
                this.OnSizeChanged();
                this.OnPropertyChanged("Size");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private int _Size;
        partial void OnSizeChanging(int value);
        partial void OnSizeChanged();
        /// <summary>
        /// There are no comments for Property YogaClassStatus in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("YogaClassStatus")]
        [global::System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessage = "YogaClassStatus is required.")]
        public virtual string YogaClassStatus
        {
            get
            {
                return this._YogaClassStatus;
            }
            set
            {
                this.OnYogaClassStatusChanging(value);
                this._YogaClassStatus = value;
                this.OnYogaClassStatusChanged();
                this.OnPropertyChanged("YogaClassStatus");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private string _YogaClassStatus;
        partial void OnYogaClassStatusChanging(string value);
        partial void OnYogaClassStatusChanged();
        /// <summary>
        /// There are no comments for Property CourseId in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("CourseId")]
        [global::System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessage = "CourseId is required.")]
        public virtual int CourseId
        {
            get
            {
                return this._CourseId;
            }
            set
            {
                this.OnCourseIdChanging(value);
                this._CourseId = value;
                this.OnCourseIdChanged();
                this.OnPropertyChanged("CourseId");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private int _CourseId;
        partial void OnCourseIdChanging(int value);
        partial void OnCourseIdChanged();
        /// <summary>
        /// There are no comments for Property CourseName in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("CourseName")]
        public virtual string CourseName
        {
            get
            {
                return this._CourseName;
            }
            set
            {
                this.OnCourseNameChanging(value);
                this._CourseName = value;
                this.OnCourseNameChanged();
                this.OnPropertyChanged("CourseName");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private string _CourseName;
        partial void OnCourseNameChanging(string value);
        partial void OnCourseNameChanged();
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
