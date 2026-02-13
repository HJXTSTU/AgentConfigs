namespace VTCodeTemplateDemo
{
	public static class ExecutorFactory
	{
		public static BaseExecutor Create(string name)
		{
			switch (name)
			{
				case "MoveForwardExecutor":
					return new MoveForwardExecutor();
				case "RotateTwardExecutor":
					return new RotateTwardExecutor();
				case "SpawnEnemyExecutor":
					return new SpawnEnemyExecutor();
			}
			return null;
		}
	}
}
