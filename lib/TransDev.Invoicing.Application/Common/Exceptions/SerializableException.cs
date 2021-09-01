using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransDev.Invoicing.Application.Common.Exceptions
{
    public class SerializableException
    {
        [JsonRequired()]
        public string Message { get; set; }

        public string StackTrace { get; set; }

        public SerializableException[] Inner { get; set; }

        public SerializableException(string message)
        {
            Message = message;
            StackTrace = null;
            Inner = null;
        }

        public SerializableException(Exception ex)
        {
            var message = ex.Message;
            var stackTrace = ex.StackTrace;

            SerializableException[] inner = null;
            switch (ex)
            {
                case AggregateException aggregateEx:
                    if (aggregateEx.InnerExceptions != null && aggregateEx.InnerExceptions.Count > 0)
                        Inner = aggregateEx.InnerExceptions.Select(e => new SerializableException(e)).ToArray();
                    break;

                case ValidationException validationEx:
                    if (validationEx.Errors != null && validationEx.Errors.Count > 0)
                    {
                        inner = validationEx.Errors
                            .Select(pair =>
                            {
                                var description = pair.Key switch
                                {
                                    "" => "Error(s) with request",
                                    _ => $"Error(s) validating {pair.Key}",
                                };
                                var details = string.Join("\n", pair.Value.Select(s => $"- {s}"));

                                return new SerializableException($"{description}:\n{details}");
                            })
                            .ToArray();

                        if (inner.Length == 1)
                        {
                            message = inner[0].Message;
                            inner = null;
                        }
                    }
                    break;
            }
            if (inner == null && ex.InnerException != null)
                inner = new SerializableException[] { new SerializableException(ex.InnerException) };

            Message = message;
            StackTrace = stackTrace;
            Inner = inner;
        }
    }
}
