﻿using System.IO;
using System.Reflection;

namespace SEOChecker.Services.Tests
{
	public class TestHelper
	{
		public static string GetTextFromFile(string sampleFile)
		{
			var asm = Assembly.GetExecutingAssembly();
            var resource = string.Format("SEOChecker.Services.Tests.GoogleSearch.{0}", sampleFile);
            using (var stream = asm.GetManifestResourceStream(resource))
            {
                if (stream != null)
                {
                    var reader = new StreamReader(stream);
                    return reader.ReadToEnd();
                }
            }
            return string.Empty;
        }
	}
}