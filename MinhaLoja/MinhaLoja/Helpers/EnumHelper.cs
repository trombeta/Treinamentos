using System;

namespace MyStore.Helper
{
    public class EnumHelper
    {
        public T EnumAleatorio<T>()
        {
            var e = Enum.GetValues(typeof(T));

            return (T)e.GetValue(new Random().Next(e.Length));
        }
    }
}