using System.IO;
using System.Reflection;

namespace MinhaLoja.Helpers
{
    public static class TestHelper
    {
        public static string PastaDoExecutaval => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }
}
