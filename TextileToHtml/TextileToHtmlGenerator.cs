using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using VSLangProj80;
using Textile;
using System.IO;

namespace sixpetals.TextileToHtml {
    [ComVisible(true)]
    [Guid("0E28FE58-1755-465E-A2D9-8B4AFD875742")]
    [CodeGeneratorRegistration(typeof(TextileToHtmlGenerator),
        "Textile format file can convert to html.",
        vsContextGuids.vsContextGuidVCSProject,
        GeneratesDesignTimeSource = true)]
    [ProvideObject(typeof(TextileToHtmlGenerator))]
    public class TextileToHtmlGenerator : BaseCodeGeneratorWithSite {


        protected override string GetDefaultExtension() { return ".html"; }

        protected override byte[] GenerateCode(string inputFileContent) {
            using (var output = new Outputer()) {
                var target = new TextileFormatter(output);
                target.Format(inputFileContent);
                return output.GetOutput();
            }
        }
    }

    public class Outputer : IOutputter,IDisposable {
        public StreamWriter _writer;
        public MemoryStream _stream;
        public void Begin() {
          _stream =  new MemoryStream();
          _writer = new StreamWriter(_stream);
        }

        public void Write(string text) {
            _writer.Write(text);

        }

        public void WriteLine(string line) {
            _writer.WriteLine(line);
        }

        public void End() {
            _writer.Flush();
        }

        public void Dispose() {
            _writer.Dispose();
        }

        public byte[] GetOutput() {
            return _stream.ToArray();
        }
    }

}

