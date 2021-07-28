﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CGServices.CGGeneralServicesDB {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/CGServices")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CGGeneralServicesDB.ICGGeneralService")]
    public interface ICGGeneralService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICGGeneralService/IsLoginAuthorize", ReplyAction="http://tempuri.org/ICGGeneralService/IsLoginAuthorizeResponse")]
        string IsLoginAuthorize(string UserName, string UserPassword, string macAddress, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICGGeneralService/IsLoginAuthorize", ReplyAction="http://tempuri.org/ICGGeneralService/IsLoginAuthorizeResponse")]
        System.Threading.Tasks.Task<string> IsLoginAuthorizeAsync(string UserName, string UserPassword, string macAddress, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICGGeneralService/GetSocialUser", ReplyAction="http://tempuri.org/ICGGeneralService/GetSocialUserResponse")]
        CyberGlobesDM.GeneralsDMs.SocialUser GetSocialUser(string socialType, string company, string token, int avatarId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICGGeneralService/GetSocialUser", ReplyAction="http://tempuri.org/ICGGeneralService/GetSocialUserResponse")]
        System.Threading.Tasks.Task<CyberGlobesDM.GeneralsDMs.SocialUser> GetSocialUserAsync(string socialType, string company, string token, int avatarId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICGGeneralService/WriteToLog", ReplyAction="http://tempuri.org/ICGGeneralService/WriteToLogResponse")]
        void WriteToLog(string action, string search, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICGGeneralService/WriteToLog", ReplyAction="http://tempuri.org/ICGGeneralService/WriteToLogResponse")]
        System.Threading.Tasks.Task WriteToLogAsync(string action, string search, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICGGeneralService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/ICGGeneralService/GetDataUsingDataContractResponse")]
        CGServices.CGGeneralServicesDB.CompositeType GetDataUsingDataContract(CGServices.CGGeneralServicesDB.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICGGeneralService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/ICGGeneralService/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<CGServices.CGGeneralServicesDB.CompositeType> GetDataUsingDataContractAsync(CGServices.CGGeneralServicesDB.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICGGeneralService/UpdateCookie", ReplyAction="http://tempuri.org/ICGGeneralService/UpdateCookieResponse")]
        void UpdateCookie(string cookie, int id, string token, string AccesstokenSecret);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICGGeneralService/UpdateCookie", ReplyAction="http://tempuri.org/ICGGeneralService/UpdateCookieResponse")]
        System.Threading.Tasks.Task UpdateCookieAsync(string cookie, int id, string token, string AccesstokenSecret);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICGGeneralServiceChannel : CGServices.CGGeneralServicesDB.ICGGeneralService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CGGeneralServiceClient : System.ServiceModel.ClientBase<CGServices.CGGeneralServicesDB.ICGGeneralService>, CGServices.CGGeneralServicesDB.ICGGeneralService {
        
        public CGGeneralServiceClient() {
        }
        
        public CGGeneralServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CGGeneralServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CGGeneralServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CGGeneralServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string IsLoginAuthorize(string UserName, string UserPassword, string macAddress, string token) {
            return base.Channel.IsLoginAuthorize(UserName, UserPassword, macAddress, token);
        }
        
        public System.Threading.Tasks.Task<string> IsLoginAuthorizeAsync(string UserName, string UserPassword, string macAddress, string token) {
            return base.Channel.IsLoginAuthorizeAsync(UserName, UserPassword, macAddress, token);
        }
        
        public CyberGlobesDM.GeneralsDMs.SocialUser GetSocialUser(string socialType, string company, string token, int avatarId) {
            return base.Channel.GetSocialUser(socialType, company, token, avatarId);
        }
        
        public System.Threading.Tasks.Task<CyberGlobesDM.GeneralsDMs.SocialUser> GetSocialUserAsync(string socialType, string company, string token, int avatarId) {
            return base.Channel.GetSocialUserAsync(socialType, company, token, avatarId);
        }
        
        public void WriteToLog(string action, string search, string token) {
            base.Channel.WriteToLog(action, search, token);
        }
        
        public System.Threading.Tasks.Task WriteToLogAsync(string action, string search, string token) {
            return base.Channel.WriteToLogAsync(action, search, token);
        }
        
        public CGServices.CGGeneralServicesDB.CompositeType GetDataUsingDataContract(CGServices.CGGeneralServicesDB.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<CGServices.CGGeneralServicesDB.CompositeType> GetDataUsingDataContractAsync(CGServices.CGGeneralServicesDB.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public void UpdateCookie(string cookie, int id, string token, string AccesstokenSecret) {
            base.Channel.UpdateCookie(cookie, id, token, AccesstokenSecret);
        }
        
        public System.Threading.Tasks.Task UpdateCookieAsync(string cookie, int id, string token, string AccesstokenSecret) {
            return base.Channel.UpdateCookieAsync(cookie, id, token, AccesstokenSecret);
        }
    }
}
