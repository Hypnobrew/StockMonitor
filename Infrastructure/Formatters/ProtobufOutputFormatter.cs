using System;
using Microsoft.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using ProtoBuf.Meta;

namespace Infrastructure
{
    public class ProtobufOutputFormatter :  OutputFormatter
    {
        private static Lazy<RuntimeTypeModel> model = new Lazy<RuntimeTypeModel>(CreateTypeModel);
 
        public string ContentType { get; private set; }
 
        public static RuntimeTypeModel Model
        {
            get { return model.Value; }
        }
 
        public ProtobufOutputFormatter()
        {
            ContentType = "application/x-protobuf";
            var mediaTypeHeader = MediaTypeHeaderValue.Parse(ContentType);
            mediaTypeHeader.Encoding = System.Text.Encoding.UTF8;
            SupportedMediaTypes.Add(mediaTypeHeader);
        }
 
        private static RuntimeTypeModel CreateTypeModel()
        {
            var typeModel = TypeModel.Create();
            typeModel.UseImplicitZeroDefaults = false;
            return typeModel;
        }
 
        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
        {
            var response = context.HttpContext.Response;
     
            Model.Serialize(response.Body, context.Object);
            return Task.FromResult(response);
        }
    }
}