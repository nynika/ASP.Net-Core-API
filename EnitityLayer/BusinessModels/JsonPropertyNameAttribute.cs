using System;

namespace EnitityLayer.BusinessModels
{
    internal class JsonPropertyNameAttribute : Attribute
    {
        private string v;

        public JsonPropertyNameAttribute(string v)
        {
            this.v = v;
        }
    }
}