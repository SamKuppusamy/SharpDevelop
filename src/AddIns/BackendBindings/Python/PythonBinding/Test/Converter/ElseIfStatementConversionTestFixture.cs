﻿// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using ICSharpCode.NRefactory;
using ICSharpCode.PythonBinding;
using NUnit.Framework;

namespace PythonBinding.Tests.Converter
{
	/// <summary>
	/// Converts a C# else if statement to Python's elif.
	/// </summary>
	[TestFixture]
	public class ElseIfStatementConversionTestFixture
	{
		string csharp = "class Foo\r\n" +
						"{\r\n" +
						"\tpublic int GetCount(i)\r\n" +
						"\t{" +
						"\t\tif (i == 0) {\r\n" +
						"\t\t\treturn 10;\r\n" +
						"\t\t} else if (i < 1){\r\n" +
						"\t\t\treturn 4;\r\n" +
						"\t\t}\r\n" +
						"\t\treturn 2;\r\n" +
						"\t}\r\n" +
						"}";
						
		[Test]
		public void ConvertedPythonCode()
		{
			NRefactoryToPythonConverter converter = new NRefactoryToPythonConverter(SupportedLanguage.CSharp);
			string python = converter.Convert(csharp);
			string expectedPython = "class Foo(object):\r\n" +
									"\tdef GetCount(self, i):\r\n" +
									"\t\tif i == 0:\r\n" +
									"\t\t\treturn 10\r\n" +
									"\t\telif i < 1:\r\n" +
									"\t\t\treturn 4\r\n" +
									"\t\treturn 2";
			
			Assert.AreEqual(expectedPython, python);
		}
	}
}
