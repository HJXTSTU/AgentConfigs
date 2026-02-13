using UnityEditor;
using VTCodeTemplate.Core;
namespace VTCodeTemplateDemo
{
	public class RepeatExampleGen
	{
		[MenuItem("Tools/VTCodeTemplate/Demo/Gen RepeatExample", priority = 1)]
		public static void GenRepeatExample()
		{
			TemplateHandler tempalteHandler = new TemplateHandler("Assets/VTCodeTemplatePro/Demo/2.Repeat/Repeat.vtemplate");

			//	Global Content
			IDataContext globalDataContext = tempalteHandler.GlobalDataContext;
			globalDataContext.AddReplaceValue("Content", "Hello World");

			//	Set LogArea Internal Content
			IRepeatDataContext repeatDataContext = tempalteHandler.GetRepeatDataContext("LogArea");
			for(int i = 0; i < 10; i++)
			{
				IDataContext currentDataContext = repeatDataContext.CreateNextIteratorDataContext();
				currentDataContext.AddReplaceValue("Count", (i + 1).ToString());
			}

			tempalteHandler.Compile("Assets/VTCodeTemplatePro/Demo/2.Repeat/Generate/RepeatExample.cs");
		}
	}
}
