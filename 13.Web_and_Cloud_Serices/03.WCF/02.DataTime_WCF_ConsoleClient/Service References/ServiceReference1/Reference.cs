﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _02.DataTime_WCF_ConsoleClient.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IDateTimeService")]
    public interface IDateTimeService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDateTimeService/GetDayOfWeek", ReplyAction="http://tempuri.org/IDateTimeService/GetDayOfWeekResponse")]
        string GetDayOfWeek(System.DateTime dateTime);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDateTimeService/GetDayOfWeek", ReplyAction="http://tempuri.org/IDateTimeService/GetDayOfWeekResponse")]
        System.Threading.Tasks.Task<string> GetDayOfWeekAsync(System.DateTime dateTime);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDateTimeServiceChannel : _02.DataTime_WCF_ConsoleClient.ServiceReference1.IDateTimeService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DateTimeServiceClient : System.ServiceModel.ClientBase<_02.DataTime_WCF_ConsoleClient.ServiceReference1.IDateTimeService>, _02.DataTime_WCF_ConsoleClient.ServiceReference1.IDateTimeService {
        
        public DateTimeServiceClient() {
        }
        
        public DateTimeServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DateTimeServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DateTimeServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DateTimeServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetDayOfWeek(System.DateTime dateTime) {
            return base.Channel.GetDayOfWeek(dateTime);
        }
        
        public System.Threading.Tasks.Task<string> GetDayOfWeekAsync(System.DateTime dateTime) {
            return base.Channel.GetDayOfWeekAsync(dateTime);
        }
    }
}