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
namespace YogaManagement.Client.OdataClient.YogaManagement.Contracts.Course
{
    /// <summary>
    /// Class containing all extension methods
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Get an entity of type global::YogaManagement.Client.OdataClient.YogaManagement.Contracts.Course.CourseDTO as global::YogaManagement.Client.OdataClient.YogaManagement.Contracts.Course.CourseDTOSingle specified by key from an entity set
        /// </summary>
        /// <param name="_source">source entity set</param>
        /// <param name="_keys">dictionary with the names and values of keys</param>
        public static global::YogaManagement.Client.OdataClient.YogaManagement.Contracts.Course.CourseDTOSingle ByKey(this global::Microsoft.OData.Client.DataServiceQuery<global::YogaManagement.Client.OdataClient.YogaManagement.Contracts.Course.CourseDTO> _source, global::System.Collections.Generic.IDictionary<string, object> _keys)
        {
            return new global::YogaManagement.Client.OdataClient.YogaManagement.Contracts.Course.CourseDTOSingle(_source.Context, _source.GetKeyPath(global::Microsoft.OData.Client.Serializer.GetKeyString(_source.Context, _keys)));
        }
        /// <summary>
        /// Get an entity of type global::YogaManagement.Client.OdataClient.YogaManagement.Contracts.Course.CourseDTO as global::YogaManagement.Client.OdataClient.YogaManagement.Contracts.Course.CourseDTOSingle specified by key from an entity set
        /// </summary>
        /// <param name="_source">source entity set</param>
        /// <param name="id">The value of id</param>
        public static global::YogaManagement.Client.OdataClient.YogaManagement.Contracts.Course.CourseDTOSingle ByKey(this global::Microsoft.OData.Client.DataServiceQuery<global::YogaManagement.Client.OdataClient.YogaManagement.Contracts.Course.CourseDTO> _source,
            int id)
        {
            global::System.Collections.Generic.IDictionary<string, object> _keys = new global::System.Collections.Generic.Dictionary<string, object>
            {
                { "Id", id }
            };
            return new global::YogaManagement.Client.OdataClient.YogaManagement.Contracts.Course.CourseDTOSingle(_source.Context, _source.GetKeyPath(global::Microsoft.OData.Client.Serializer.GetKeyString(_source.Context, _keys)));
        }
    }
}
