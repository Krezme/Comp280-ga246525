using BeardedManStudios.Forge.Networking.Frame;
using System;
using MainThreadManager = BeardedManStudios.Forge.Networking.Unity.MainThreadManager;

namespace BeardedManStudios.Forge.Networking.Generated
{
	public partial class NetworkObjectFactory : NetworkObjectFactoryBase
	{
		public override void NetworkCreateObject(NetWorker networker, int identity, uint id, FrameStream frame, Action<NetworkObject> callback)
		{
			if (networker.IsServer)
			{
				if (frame.Sender != null && frame.Sender != networker.Me)
				{
					if (!ValidateCreateRequest(networker, identity, id, frame))
						return;
				}
			}
			
			bool availableCallback = false;
			NetworkObject obj = null;
			MainThreadManager.Run(() =>
			{
				switch (identity)
				{
					case ChatManagerNetworkObject.IDENTITY:
						availableCallback = true;
						obj = new ChatManagerNetworkObject(networker, id, frame);
						break;
					case CopyableObjectsFollowingPlayerNetworkObject.IDENTITY:
						availableCallback = true;
						obj = new CopyableObjectsFollowingPlayerNetworkObject(networker, id, frame);
						break;
					case CubeForgeGameNetworkObject.IDENTITY:
						availableCallback = true;
						obj = new CubeForgeGameNetworkObject(networker, id, frame);
						break;
					case ExampleProximityPlayerNetworkObject.IDENTITY:
						availableCallback = true;
						obj = new ExampleProximityPlayerNetworkObject(networker, id, frame);
						break;
					case LocationOfCopyNetworkObject.IDENTITY:
						availableCallback = true;
						obj = new LocationOfCopyNetworkObject(networker, id, frame);
						break;
					case NetworkCameraNetworkObject.IDENTITY:
						availableCallback = true;
						obj = new NetworkCameraNetworkObject(networker, id, frame);
						break;
					case PlayerLookNetworkObject.IDENTITY:
						availableCallback = true;
						obj = new PlayerLookNetworkObject(networker, id, frame);
						break;
					case PlayerMovementNetworkObject.IDENTITY:
						availableCallback = true;
						obj = new PlayerMovementNetworkObject(networker, id, frame);
						break;
					case RandomPanelSpawnSyncNetworkObject.IDENTITY:
						availableCallback = true;
						obj = new RandomPanelSpawnSyncNetworkObject(networker, id, frame);
						break;
					case RaybitchSynkNetworkObject.IDENTITY:
						availableCallback = true;
						obj = new RaybitchSynkNetworkObject(networker, id, frame);
						break;
					case SyncPastedGameObjectNetworkObject.IDENTITY:
						availableCallback = true;
						obj = new SyncPastedGameObjectNetworkObject(networker, id, frame);
						break;
					case TestNetworkObject.IDENTITY:
						availableCallback = true;
						obj = new TestNetworkObject(networker, id, frame);
						break;
					case WandFollowCameraNetworkObject.IDENTITY:
						availableCallback = true;
						obj = new WandFollowCameraNetworkObject(networker, id, frame);
						break;
				}

				if (!availableCallback)
					base.NetworkCreateObject(networker, identity, id, frame, callback);
				else if (callback != null)
					callback(obj);
			});
		}

		// DO NOT TOUCH, THIS GETS GENERATED PLEASE EXTEND THIS CLASS IF YOU WISH TO HAVE CUSTOM CODE ADDITIONS
	}
}