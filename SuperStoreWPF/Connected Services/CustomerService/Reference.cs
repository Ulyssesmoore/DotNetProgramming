﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SuperStoreWPF.CustomerService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CustomerService.ICustomerService")]
    public interface ICustomerService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/GetOwnedProducts", ReplyAction="http://tempuri.org/ICustomerService/GetOwnedProductsResponse")]
        SuperStoreWebService2.Product[] GetOwnedProducts(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/GetOwnedProducts", ReplyAction="http://tempuri.org/ICustomerService/GetOwnedProductsResponse")]
        System.Threading.Tasks.Task<SuperStoreWebService2.Product[]> GetOwnedProductsAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/GetAllCustomers", ReplyAction="http://tempuri.org/ICustomerService/GetAllCustomersResponse")]
        SuperStoreWebService2.Customer[] GetAllCustomers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/GetAllCustomers", ReplyAction="http://tempuri.org/ICustomerService/GetAllCustomersResponse")]
        System.Threading.Tasks.Task<SuperStoreWebService2.Customer[]> GetAllCustomersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/CreateCustomer", ReplyAction="http://tempuri.org/ICustomerService/CreateCustomerResponse")]
        void CreateCustomer(SuperStoreWebService2.Customer newCustomer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/CreateCustomer", ReplyAction="http://tempuri.org/ICustomerService/CreateCustomerResponse")]
        System.Threading.Tasks.Task CreateCustomerAsync(SuperStoreWebService2.Customer newCustomer);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICustomerServiceChannel : SuperStoreWPF.CustomerService.ICustomerService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CustomerServiceClient : System.ServiceModel.ClientBase<SuperStoreWPF.CustomerService.ICustomerService>, SuperStoreWPF.CustomerService.ICustomerService {
        
        public CustomerServiceClient() {
        }
        
        public CustomerServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CustomerServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CustomerServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CustomerServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public SuperStoreWebService2.Product[] GetOwnedProducts(string name) {
            return base.Channel.GetOwnedProducts(name);
        }
        
        public System.Threading.Tasks.Task<SuperStoreWebService2.Product[]> GetOwnedProductsAsync(string name) {
            return base.Channel.GetOwnedProductsAsync(name);
        }
        
        public SuperStoreWebService2.Customer[] GetAllCustomers() {
            return base.Channel.GetAllCustomers();
        }
        
        public System.Threading.Tasks.Task<SuperStoreWebService2.Customer[]> GetAllCustomersAsync() {
            return base.Channel.GetAllCustomersAsync();
        }
        
        public void CreateCustomer(SuperStoreWebService2.Customer newCustomer) {
            base.Channel.CreateCustomer(newCustomer);
        }
        
        public System.Threading.Tasks.Task CreateCustomerAsync(SuperStoreWebService2.Customer newCustomer) {
            return base.Channel.CreateCustomerAsync(newCustomer);
        }
    }
}
