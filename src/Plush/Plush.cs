using System.Reflection;
using TLDLoader;
using UnityEngine;

namespace Plush
{
	public class Plush : Mod
	{
		public override string ID => "M_Plush";
		public override string Name => "Plush";
		public override string Author => "M-";
		public override string Version => "1.0.0";
		public override bool LoadInDB => true;

		public override void DbLoad()
		{
			AssetBundle bundle = AssetBundle.LoadFromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream($"{nameof(Plush)}.plush"));
			var husky = bundle.LoadAsset<GameObject>("Husky");
			bundle.Unload(false);

			RegisterItem(husky, 0)
				.WithRigidbody(1f)
				.AsPickupable(new PickupableOptions() {
					Attachable = true,
				})
				.AsExplodable()
				.SpawnAt(5, itemdatabase.d.gelephant, itemdatabase.d.gjimmy)
				.SpawnInBox()
				.Register();
		}
	}
}
