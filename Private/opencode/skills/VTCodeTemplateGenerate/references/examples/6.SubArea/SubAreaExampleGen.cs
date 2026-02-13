using UnityEditor;
using VTCodeTemplate.Core;

namespace VTCodeTemplateDemo
{
	public class SubAreaGen
	{
		[MenuItem("Tools/VTCodeTemplate/Demo/Gen SubArea Example", priority = 5)]
		public static void GenSubAreaExample()
		{
			TemplateHandler tempalteHandler = new TemplateHandler("Assets/VTCodeTemplatePro/Demo/6.SubArea/SubArea.vtemplate");

			IDataContext globalDataContext = tempalteHandler.GlobalDataContext;
			globalDataContext.AddReplaceValue("GlobalContent", "This is global content.");

			IDataContext subAreaDataContext = tempalteHandler.GetSubAreaDataContext("LogContentArea");
			subAreaDataContext.AddReplaceValue("Content", "This is sub area content.");

			tempalteHandler.Compile("Assets/VTCodeTemplatePro/Demo/6.SubArea/Generate/SubAreaExample.cs");
		}
	}
}
