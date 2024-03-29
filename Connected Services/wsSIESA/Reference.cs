﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wsSIESA
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30422-0661")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="wsSIESA.WSUNOEESoap")]
    public interface WSUNOEESoap
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CrearConexionXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<bool> CrearConexionXMLAsync(string pvstrxmlConexion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/EjecutarConsultaXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<wsSIESA.ArrayOfXElement> EjecutarConsultaXMLAsync(string pvstrxmlParametros);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/LeerEsquemaParametros", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<string> LeerEsquemaParametrosAsync(string pvstrxmlParametros);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ImportarXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<wsSIESA.ImportarXMLResponse> ImportarXMLAsync(wsSIESA.ImportarXMLRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InicializarVariablesImportacion", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task InicializarVariablesImportacionAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SiesaWEBContabilizar", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<short> SiesaWEBContabilizarAsync(string pvstrParametros);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30422-0661")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ImportarXML", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ImportarXMLRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string pvstrDatos;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public short printTipoError;
        
        public ImportarXMLRequest()
        {
        }
        
        public ImportarXMLRequest(string pvstrDatos, short printTipoError)
        {
            this.pvstrDatos = pvstrDatos;
            this.printTipoError = printTipoError;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30422-0661")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ImportarXMLResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ImportarXMLResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public wsSIESA.ArrayOfXElement ImportarXMLResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public short printTipoError;
        
        public ImportarXMLResponse()
        {
        }
        
        public ImportarXMLResponse(wsSIESA.ArrayOfXElement ImportarXMLResult, short printTipoError)
        {
            this.ImportarXMLResult = ImportarXMLResult;
            this.printTipoError = printTipoError;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30422-0661")]
    public interface WSUNOEESoapChannel : wsSIESA.WSUNOEESoap, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30422-0661")]
    public partial class WSUNOEESoapClient : System.ServiceModel.ClientBase<wsSIESA.WSUNOEESoap>, wsSIESA.WSUNOEESoap
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public WSUNOEESoapClient(EndpointConfiguration endpointConfiguration) : 
                base(WSUNOEESoapClient.GetBindingForEndpoint(endpointConfiguration), WSUNOEESoapClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WSUNOEESoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(WSUNOEESoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WSUNOEESoapClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(WSUNOEESoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WSUNOEESoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<bool> CrearConexionXMLAsync(string pvstrxmlConexion)
        {
            return base.Channel.CrearConexionXMLAsync(pvstrxmlConexion);
        }
        
        public System.Threading.Tasks.Task<wsSIESA.ArrayOfXElement> EjecutarConsultaXMLAsync(string pvstrxmlParametros)
        {
            return base.Channel.EjecutarConsultaXMLAsync(pvstrxmlParametros);
        }
        
        public System.Threading.Tasks.Task<string> LeerEsquemaParametrosAsync(string pvstrxmlParametros)
        {
            return base.Channel.LeerEsquemaParametrosAsync(pvstrxmlParametros);
        }
        
        public System.Threading.Tasks.Task<wsSIESA.ImportarXMLResponse> ImportarXMLAsync(wsSIESA.ImportarXMLRequest request)
        {
            return base.Channel.ImportarXMLAsync(request);
        }
        
        public System.Threading.Tasks.Task InicializarVariablesImportacionAsync()
        {
            return base.Channel.InicializarVariablesImportacionAsync();
        }
        
        public System.Threading.Tasks.Task<short> SiesaWEBContabilizarAsync(string pvstrParametros)
        {
            return base.Channel.SiesaWEBContabilizarAsync(pvstrParametros);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.WSUNOEESoap))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                result.SendTimeout = System.TimeSpan.FromHours(10);
                return result;
            }
            if ((endpointConfiguration == EndpointConfiguration.WSUNOEESoap12))
            {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                System.ServiceModel.Channels.TextMessageEncodingBindingElement textBindingElement = new System.ServiceModel.Channels.TextMessageEncodingBindingElement();
                textBindingElement.MessageVersion = System.ServiceModel.Channels.MessageVersion.CreateVersion(System.ServiceModel.EnvelopeVersion.Soap12, System.ServiceModel.Channels.AddressingVersion.None);
                result.Elements.Add(textBindingElement);
                System.ServiceModel.Channels.HttpTransportBindingElement httpBindingElement = new System.ServiceModel.Channels.HttpTransportBindingElement();
                httpBindingElement.AllowCookies = true;
                httpBindingElement.MaxBufferSize = int.MaxValue;
                httpBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.SendTimeout = System.TimeSpan.FromHours(10);
                result.Elements.Add(httpBindingElement);
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.WSUNOEESoap))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost/wsunoee/WSUNOEE.asmx");
            }
            if ((endpointConfiguration == EndpointConfiguration.WSUNOEESoap12))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost/wsunoee/WSUNOEE.asmx");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        public enum EndpointConfiguration
        {
            
            WSUNOEESoap,
            
            WSUNOEESoap12,
        }
    }
    
    [System.Xml.Serialization.XmlSchemaProviderAttribute(null, IsAny=true)]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil-lib", "2.0.0.1")]
    public partial class ArrayOfXElement : object, System.Xml.Serialization.IXmlSerializable
    {
        
        private System.Collections.Generic.List<System.Xml.Linq.XElement> nodesList = new System.Collections.Generic.List<System.Xml.Linq.XElement>();
        
        public ArrayOfXElement()
        {
        }
        
        public virtual System.Collections.Generic.List<System.Xml.Linq.XElement> Nodes
        {
            get
            {
                return this.nodesList;
            }
        }
        
        public virtual System.Xml.Schema.XmlSchema GetSchema()
        {
            throw new System.NotImplementedException();
        }
        
        public virtual void WriteXml(System.Xml.XmlWriter writer)
        {
            System.Collections.Generic.IEnumerator<System.Xml.Linq.XElement> e = nodesList.GetEnumerator();
            for (
            ; e.MoveNext(); 
            )
            {
                ((System.Xml.Serialization.IXmlSerializable)(e.Current)).WriteXml(writer);
            }
        }
        
        public virtual void ReadXml(System.Xml.XmlReader reader)
        {
            for (
            ; (reader.NodeType != System.Xml.XmlNodeType.EndElement); 
            )
            {
                if ((reader.NodeType == System.Xml.XmlNodeType.Element))
                {
                    System.Xml.Linq.XElement elem = new System.Xml.Linq.XElement("default");
                    ((System.Xml.Serialization.IXmlSerializable)(elem)).ReadXml(reader);
                    Nodes.Add(elem);
                }
                else
                {
                    reader.Skip();
                }
            }
        }
    }
}
