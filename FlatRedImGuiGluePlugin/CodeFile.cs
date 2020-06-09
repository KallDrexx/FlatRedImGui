using System.IO;
using System.Reflection;
using Microsoft.Extensions.FileProviders;

namespace FlatRedImGuiGluePlugin
{
    public class CodeFile
    {
        public static readonly CodeFile ImGuiRenderer = new CodeFile(@"EmbeddedCodeFiles\ImGuiRenderer.cs");
        public static readonly CodeFile ImGuiManager = new CodeFile(@"EmbeddedCodeFiles\ImGuiManager.cs");
        public static readonly CodeFile ImGuiElement = new CodeFile(@"EmbeddedCodeFiles\ImGuiElement.cs");
        public static readonly CodeFile HasTextBufferAttribute = new CodeFile(@"EmbeddedCodeFiles\HasTextBufferAttribute.cs");
        
        private readonly string _embeddedResourceName;

        private CodeFile(string embeddedResourceName)
        {
            _embeddedResourceName = embeddedResourceName;
        }

        public string GetContents()
        {
            var provider = new EmbeddedFileProvider(Assembly.GetExecutingAssembly());
            using (var stream = provider.GetFileInfo(_embeddedResourceName).CreateReadStream())
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}