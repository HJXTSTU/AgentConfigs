using UnityEditor;
using VTCodeTemplate.Core;

namespace VTCodeTemplateDemo
{
	public class HelloWorldGen
	{
		[MenuItem("Tools/VTCodeTemplate/Demo/Gen HelloWorld", priority = 0)]
		public static void GenHelloWorld()
		{
			TemplateHandler tempalteHandler = new TemplateHandler("Assets/VTCodeTemplatePro/Demo/1.HelloWorld/HelloWorld.vtemplate");

			IDataContext globalDataContext = tempalteHandler.GlobalDataContext;
			globalDataContext.AddReplaceValue("Content", "Hello World");

			tempalteHandler.Compile("Assets/VTCodeTemplatePro/Demo/1.HelloWorld/Generate/HelloWorld.cs");
		}
	}
}
