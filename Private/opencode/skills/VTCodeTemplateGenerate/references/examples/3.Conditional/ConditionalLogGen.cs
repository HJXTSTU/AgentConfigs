using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using VTCodeTemplate.Core;

namespace VTCodeTemplateDemo
{
	public class ConditionalLogGen
	{
		[MenuItem("Tools/VTCodeTemplate/Demo/Gen Condition Log", priority = 2)]
		public static void GenConditionExample()
		{
			TemplateHandler tempalteHandler = new TemplateHandler("Assets/VTCodeTemplatePro/Demo/3.Conditional/ConditionalExample.vtemplate");

			tempalteHandler.SetConditionActive("LogCondition", true);

			tempalteHandler.Compile("Assets/VTCodeTemplatePro/Demo/3.Conditional/Generate/ConditionalExample.cs");
		}
	}
}
