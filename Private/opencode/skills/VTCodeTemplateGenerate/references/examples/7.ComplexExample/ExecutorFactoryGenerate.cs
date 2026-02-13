
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using VTCodeTemplate.Core;

namespace VTCodeTemplateDemo {
	public class ExecutorFactoryGenerator
	{
		[MenuItem("Tools/VTCodeTemplate/Demo/Gen Executor Factory", priority = 7)]
		public static void GenerateExecutorFactory()
		{
			TemplateHandler templateHandler = new TemplateHandler("Assets/VTCodeTemplatePro/Demo/7.ComplexExample/Templates/Factory.vtemplate");

			IDataContext globalDataContext = templateHandler.GlobalDataContext;
			globalDataContext.AddReplaceValue("FactoryType", "Executor");
			globalDataContext.AddReplaceValue("BaseType", typeof(BaseExecutor).Name);

			Assembly executorAssembly = typeof(BaseExecutor).Assembly;
			Type[] types = executorAssembly.GetTypes();
			List<Type> executorTypes = new List<Type>();
			foreach (Type type in types) 
			{
				if(type == typeof(BaseExecutor))
				{
					continue;
				}
				if (type.IsSubclassOf(typeof(BaseExecutor)))
				{
					executorTypes.Add(type);
				}
			}

			IRepeatDataContext repeatDataContext = templateHandler.GetRepeatDataContext("SwitchCaseArea");
			for (int i = 0; i < executorTypes.Count; i++) 
			{
				IDataContext currentDataContext = repeatDataContext.CreateNextIteratorDataContext();
				currentDataContext.AddReplaceValue("TypeName", executorTypes[i].Name);
			}

			

			templateHandler.Compile("Assets/VTCodeTemplatePro/Demo/7.ComplexExample/Generate/ExecutorFactory.cs");
		}
	}
}
