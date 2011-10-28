using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace sixpetals.TextileToHtml {

    [TestFixture]
    public class TextileToHtmlTest {
        
        [Test]
        public void コンバートできる() {
            var test = @"* a simple
  * bulleted
  * list!";
            var gen = new TextileToHtmlGenerator();

        }
    }
}
