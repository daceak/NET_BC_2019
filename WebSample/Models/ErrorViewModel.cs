using System;

namespace WebSample.Models
{
    public class ErrorViewModel //modeli tikai apraksta strukturu
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}