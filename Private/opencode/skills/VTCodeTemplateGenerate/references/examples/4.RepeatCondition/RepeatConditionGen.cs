using UnityEditor;
using VTCodeTemplate.Core;

namespace VTCodeTemplateDemo
{
	public class RepeatConditionGen
	{
		[MenuItem("Tools/VTCodeTemplate/Demo/Gen RepeatCondition Example", priority = 3)]
		public static void GenRepeatCondition()
		{
			TemplateHandler tempalteHandler = new TemplateHandler("Assets/VTCodeTemplatePro/Demo/4.RepeatCondition/RepeatCondition.vtemplate");

			//	Global Content
			IDataContext globalDataContext = tempalteHandler.GlobalDataContext;
			globalDataContext.AddReplaceValue("Content", "Hello World");

			tempalteHandler.SetConditionActive("LogCondition", true);

			//	Set LogArea Internal Content
			IDataContext internalContext = tempalteHandler.GetLogicAreaDataContext("RepeatLog");
			internalContext.AddReplaceValue("InternalContent", "Internal Content Replaced");
			IRepeatDataContext repeatDataContext = tempalteHandler.GetRepeatDataContext("RepeatLog");
			for (int i = 0; i < 10; i++)
			{
				IDataContext currentDataContext = repeatDataContext.CreateNextIteratorDataContext();
				currentDataContext.AddReplaceValue("Count", (i + 1).ToString());
			}

			tempalteHandler.Compile("Assets/VTCodeTemplatePro/Demo/4.RepeatCondition/Generate/RepeatConditionalExample.cs");
		}
	}
}
