﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generation date: 6/13/2023 10:37:08 PM
using System.ComponentModel.DataAnnotations;

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
            : base(context, path) { }

        /// <summary>
        /// Initialize a new YogaClassDTOSingle object.
        /// </summary>
        public YogaClassDTOSingle(global::Microsoft.OData.Client.DataServiceContext context, string path, bool isComposable)
            : base(context, path, isComposable) { }

        /// <summary>
        /// Initialize a new YogaClassDTOSingle object.
        /// </summary>
        public YogaClassDTOSingle(global::Microsoft.OData.Client.DataServiceQuerySingle<YogaClassDTO> query)
            : base(query) { }

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
        /// <param name="status">Initial value of Status.</param>
        /// <param name="courseId">Initial value of CourseId.</param>
        /// <param name="courseName">Initial value of CourseName.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        public static YogaClassDTO CreateYogaClassDTO(int ID,
                    string name,
                    int size,
                    string yogaClassStatus,
                    int courseId,
                    string courseName)
        {
            YogaClassDTO yogaClassDTO = new YogaClassDTO();
            yogaClassDTO.Id = ID;
            yogaClassDTO.Name = name;
            yogaClassDTO.Size = size;
            yogaClassDTO.YogaClassStatus = yogaClassStatus;
            yogaClassDTO.CourseId = courseId;
            yogaClassDTO.CourseName = courseName;
            return yogaClassDTO;
        }

        #region Id
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
        #endregion

        #region Name
        /// <summary>
        /// There are no comments for Property Name in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("Name")]
        [global::System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessage = "Name is required.")]
        [MaxLength(50, ErrorMessage = "Course name must be between 1-50 character")]
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
        #endregion

        #region Size
        /// <summary>
        /// There are no comments for Property Size in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("Size")]
        [global::System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessage = "Size is required.")]
        [Range(10, 20, ErrorMessage = "Class must be between 10 to 20 people")]
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
        #endregion

        #region YogaClassStatus
        /// <summary>
        /// There are no comments for Property Name in the schema.
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
        #endregion

        #region CourseId
        /// <summary>
        /// There are no comments for Property CourseId in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("CourseId")]
        [global::System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessage = "CourseId is required.")]
        [Range(minimum: 1, maximum: int.MaxValue)]
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
        #endregion

        #region CourseName
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
        #endregion

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
