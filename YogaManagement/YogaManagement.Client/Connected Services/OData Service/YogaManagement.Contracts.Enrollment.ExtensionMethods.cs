﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generation date: 6/26/2023 4:10:29 PM
namespace YogaManagement.Client.OdataClient.YogaManagement.Contracts.Enrollment
{
    /// <summary>
    /// Class containing all extension methods
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Get an entity of type global::YogaManagement.Client.OdataClient.YogaManagement.Contracts.Enrollment.EnrollmentDTO as global::YogaManagement.Client.OdataClient.YogaManagement.Contracts.Enrollment.EnrollmentDTOSingle specified by key from an entity set
        /// </summary>
        /// <param name="_source">source entity set</param>
        /// <param name="_keys">dictionary with the names and values of keys</param>
        public static global::YogaManagement.Client.OdataClient.YogaManagement.Contracts.Enrollment.EnrollmentDTOSingle ByKey(this global::Microsoft.OData.Client.DataServiceQuery<global::YogaManagement.Client.OdataClient.YogaManagement.Contracts.Enrollment.EnrollmentDTO> _source, global::System.Collections.Generic.IDictionary<string, object> _keys)
        {
            return new global::YogaManagement.Client.OdataClient.YogaManagement.Contracts.Enrollment.EnrollmentDTOSingle(_source.Context, _source.GetKeyPath(global::Microsoft.OData.Client.Serializer.GetKeyString(_source.Context, _keys)));
        }
        /// <summary>
        /// Get an entity of type global::YogaManagement.Client.OdataClient.YogaManagement.Contracts.Enrollment.EnrollmentDTO as global::YogaManagement.Client.OdataClient.YogaManagement.Contracts.Enrollment.EnrollmentDTOSingle specified by key from an entity set
        /// </summary>
        /// <param name="_source">source entity set</param>
        /// <param name="memberId">The value of memberId</param>
        /// <param name="yogaClassId">The value of yogaClassId</param>
        public static global::YogaManagement.Client.OdataClient.YogaManagement.Contracts.Enrollment.EnrollmentDTOSingle ByKey(this global::Microsoft.OData.Client.DataServiceQuery<global::YogaManagement.Client.OdataClient.YogaManagement.Contracts.Enrollment.EnrollmentDTO> _source,
            int memberId, 
            int yogaClassId)
        {
            global::System.Collections.Generic.IDictionary<string, object> _keys = new global::System.Collections.Generic.Dictionary<string, object>
            {
                { "MemberId", memberId }, 
                { "YogaClassId", yogaClassId }
            };
            return new global::YogaManagement.Client.OdataClient.YogaManagement.Contracts.Enrollment.EnrollmentDTOSingle(_source.Context, _source.GetKeyPath(global::Microsoft.OData.Client.Serializer.GetKeyString(_source.Context, _keys)));
        }
    }
}
