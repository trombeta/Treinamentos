using System;

namespace MyStore.Helper
{
    public class EnumHelper
    {
        public T EnumAleatorio<T>()
        {
            var v = Enum.GetValues(typeof(T));

            return (T)v.GetValue(new Random().Next(v.Length));
        }
    }
}