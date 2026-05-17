using Friflo.Engine.ECS;
using System;

namespace Friflo.Engine.Unity {
	public static class EntityExtensions {
		public static void AddComponentReflection(this Entity entity, IComponent component) {
			if (component == null)
				return;

			var type = component.GetType();

			var method = typeof(Entity)
				.GetMethod(nameof(Entity.AddComponent), Type.EmptyTypes)
				.MakeGenericMethod(type);

			method.Invoke(entity, null);
		}

		public static void AddTagReflection(this Entity entity, ITag tag) {
			var type = tag.GetType();

			var method = typeof(Entity)
				.GetMethod(nameof(Entity.AddTag), Type.EmptyTypes)
				.MakeGenericMethod(type);

			method.Invoke(entity, null);
		}
	}
}