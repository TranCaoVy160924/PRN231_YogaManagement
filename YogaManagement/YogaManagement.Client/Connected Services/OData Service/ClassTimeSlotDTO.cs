﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generation date: 6/27/2023 4:42:56 PM
namespace YogaManagement.Client.OdataClient.YogaManagement.Contracts.TimeSlot
{
    /// <summary>
    /// There are no comments for ClassTimeSlotDTOSingle in the schema.
    /// </summary>
    [global::Microsoft.OData.Client.OriginalNameAttribute("ClassTimeSlotDTOSingle")]
    public partial class ClassTimeSlotDTOSingle : global::Microsoft.OData.Client.DataServiceQuerySingle<ClassTimeSlotDTO>
    {
        /// <summary>
        /// Initialize a new ClassTimeSlotDTOSingle object.
        /// </summary>
        public ClassTimeSlotDTOSingle(global::Microsoft.OData.Client.DataServiceContext context, string path)
            : base(context, path) {}

        /// <summary>
        /// Initialize a new ClassTimeSlotDTOSingle object.
        /// </summary>
        public ClassTimeSlotDTOSingle(global::Microsoft.OData.Client.DataServiceContext context, string path, bool isComposable)
            : base(context, path, isComposable) {}

        /// <summary>
        /// Initialize a new ClassTimeSlotDTOSingle object.
        /// </summary>
        public ClassTimeSlotDTOSingle(global::Microsoft.OData.Client.DataServiceQuerySingle<ClassTimeSlotDTO> query)
            : base(query) {}

    }
    /// <summary>
    /// There are no comments for ClassTimeSlotDTO in the schema.
    /// </summary>
    /// <KeyProperties>
    /// Id
    /// </KeyProperties>
    [global::Microsoft.OData.Client.Key("Id")]
    [global::Microsoft.OData.Client.OriginalNameAttribute("ClassTimeSlotDTO")]
    public partial class ClassTimeSlotDTO : global::Microsoft.OData.Client.BaseEntityType, global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new ClassTimeSlotDTO object.
        /// </summary>
        /// <param name="ID">Initial value of Id.</param>
        /// <param name="dayOfWeek">Initial value of DayOfWeek.</param>
        /// <param name="startTime">Initial value of StartTime.</param>
        /// <param name="endTime">Initial value of EndTime.</param>
        /// <param name="className">Initial value of ClassName.</param>
        /// <param name="courseName">Initial value of CourseName.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        public static ClassTimeSlotDTO CreateClassTimeSlotDTO(int ID, 
                    string dayOfWeek, 
                    string startTime, 
                    string endTime, 
                    string className, 
                    string courseName)
        {
            ClassTimeSlotDTO classTimeSlotDTO = new ClassTimeSlotDTO();
            classTimeSlotDTO.Id = ID;
            classTimeSlotDTO.DayOfWeek = dayOfWeek;
            classTimeSlotDTO.StartTime = startTime;
            classTimeSlotDTO.EndTime = endTime;
            classTimeSlotDTO.ClassName = className;
            classTimeSlotDTO.CourseName = courseName;
            return classTimeSlotDTO;
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
        /// There are no comments for Property DayOfWeek in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("DayOfWeek")]
        [global::System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessage = "DayOfWeek is required.")]
        public virtual string DayOfWeek
        {
            get
            {
                return this._DayOfWeek;
            }
            set
            {
                this.OnDayOfWeekChanging(value);
                this._DayOfWeek = value;
                this.OnDayOfWeekChanged();
                this.OnPropertyChanged("DayOfWeek");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private string _DayOfWeek;
        partial void OnDayOfWeekChanging(string value);
        partial void OnDayOfWeekChanged();
        /// <summary>
        /// There are no comments for Property StartTime in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("StartTime")]
        [global::System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessage = "StartTime is required.")]
        public virtual string StartTime
        {
            get
            {
                return this._StartTime;
            }
            set
            {
                this.OnStartTimeChanging(value);
                this._StartTime = value;
                this.OnStartTimeChanged();
                this.OnPropertyChanged("StartTime");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private string _StartTime;
        partial void OnStartTimeChanging(string value);
        partial void OnStartTimeChanged();
        /// <summary>
        /// There are no comments for Property EndTime in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("EndTime")]
        [global::System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessage = "EndTime is required.")]
        public virtual string EndTime
        {
            get
            {
                return this._EndTime;
            }
            set
            {
                this.OnEndTimeChanging(value);
                this._EndTime = value;
                this.OnEndTimeChanged();
                this.OnPropertyChanged("EndTime");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private string _EndTime;
        partial void OnEndTimeChanging(string value);
        partial void OnEndTimeChanged();
        /// <summary>
        /// There are no comments for Property ClassName in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("ClassName")]
        [global::System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessage = "ClassName is required.")]
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
        /// There are no comments for Property CourseName in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("CourseName")]
        [global::System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessage = "CourseName is required.")]
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
