using UnityEditor;
using VTCodeTemplate.Core;

namespace VTCodeTemplateDemo
{
	public class IncludeExampleGen
	{
		[MenuItem("Tools/VTCodeTemplate/Demo/Gen IncludeExample", priority = 4)]
		public static void GenIncludeExample()
		{
			TemplateHandler tempalteHandler = new TemplateHandler("Assets/VTCodeTemplatePro/Demo/5.Include/IncludeExample.vtemplate");

			//	Global Content
			IDataContext globalDataContext = tempalteHandler.GlobalDataContext;
			globalDataContext.AddReplaceValue("Content", "Include Example Content");

			tempalteHandler.Compile("Assets/VTCodeTemplatePro/Demo/5.Include/Generate/IncludeExample.cs");
		}
	}
}
