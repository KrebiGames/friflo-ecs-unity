using Friflo.Engine.ECS;

namespace Friflo.Engine.Unity {
	public static class EntityExtensions {
		public static void AddComponent(this Entity entity, IComponent component) =>
			Add(entity, nameof(Entity.AddComponent), component);

		public static void AddTag(this Entity entity, ITag tag) =>
			Add(entity, nameof(Entity.AddTag), tag);

		private static void Add(Entity entity, string methodName, object value) =>
			typeof(Entity)
				.GetMethod(methodName, System.Type.EmptyTypes)
				.MakeGenericMethod(value.GetType())
				.Invoke(entity, null);
	}
}