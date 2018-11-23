using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOM {
	private static Dictionary<int, int> gameobj_to_asset = new Dictionary<int,int>();
	public static void start() {

	}
	public static T instantiate<T>(T origin, Transform parent) where T : Object {
		int res_id = 0;
		int origin_id = origin.GetInstanceID();
		T o = Object.Instantiate<T>(origin);
		int new_id = o.GetInstanceID();
		if (gameobj_to_asset.TryGetValue(origin_id, out res_id)) {
			gameobj_to_asset[new_id] = res_id;
			ABM.ref_asset(res_id);
		}
		return o;
	}
	public static T instantiate<T>(T origin) where T : Object {
		return instantiate<T>(origin, null);
	}
	public static Object instantiate(Object origin, Transform parent) {
		return instantiate<Object>(origin, parent);
	}

	public static Object instantiate(GameObject origin) {
		return instantiate(origin, null);
	}
	public static Object instantiate(string name, Transform parent) {
		var ao = ABM.load_asset(name);
		var o = Object.Instantiate(ao, parent);
		gameobj_to_asset[o.GetInstanceID()] = ao.GetInstanceID();
		return o;
	}

	public static Object instantiate(string name) {
		return instantiate(name, null);
	}
	public static void destroy(Object obj, float delay = 0.0f) {
		int res_id;
		if(gameobj_to_asset.TryGetValue(obj.GetInstanceID(), out res_id))
			ABM.unref_asset(res_id);
		Object.Destroy(obj, delay);
	}
}
