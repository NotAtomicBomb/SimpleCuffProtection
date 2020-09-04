using System;
using Exiled;
using Exiled.API;
using Exiled.API.Features;
using Exiled.Events;
using Exiled.API.Enums;

namespace SimpleCuffProtection
{
	public class SimpleCuffProtection : Plugin<Config>
	{
		internal static SimpleCuffProtection plugin { get; private set; }
        public override Version Version => Version.Parse("1.0.7");
		internal static string WarnMsg;
		internal static float WarnDur;
		internal static bool AllowCufferDamage;
		internal static bool DisallowUncuffing;

		public override string Name
		{
			get
			{
				return "SimpleCuffProtection";
			} 
		}
        public override string Author => "Atomic";
        public override void OnDisabled()
		{
			bool flag = !this.enabled;
			if (!flag)
			{
                Exiled.Events.Handlers.Player.Hurting -= LocalEvents.OnPlayerHurt;
				Exiled.Events.Handlers.Player.Handcuffing -= LocalEvents.OnHandcuffing;
				Exiled.Events.Handlers.Player.RemovingHandcuffs -= LocalEvents.OnRemovingHandcuffs;
				Exiled.Events.Handlers.Player.ChangingItem -= LocalEvents.OnChangingItem;
				Exiled.Events.Handlers.Player.DroppingItem -= LocalEvents.OnDroppingItem;
			}
		}
		public override void OnEnabled()
		{
			OnReloaded();
			this.enabled = Config.IsEnabled;
			bool flag = !this.enabled;
			if (!flag)
			{
				SimpleCuffProtection.plugin = this;
				Log.Warn("Registering events for SimpleCuffProtection...");
				LocalEvents = new EventHandlers();
				Exiled.Events.Handlers.Player.Hurting += LocalEvents.OnPlayerHurt;
				Exiled.Events.Handlers.Player.Handcuffing += LocalEvents.OnHandcuffing;
				Exiled.Events.Handlers.Player.RemovingHandcuffs += LocalEvents.OnRemovingHandcuffs;
				Exiled.Events.Handlers.Player.ChangingItem += LocalEvents.OnChangingItem;
				Exiled.Events.Handlers.Player.DroppingItem += LocalEvents.OnDroppingItem;
			}
		}
		public override void OnReloaded()
		{
			WarnMsg = Config.WarningMessage;
			WarnDur = Config.WarningMessageDuration;
			AllowCufferDamage = Config.AllowCufferDamage;
			DisallowUncuffing = Config.DisallowUncuffing;
		}

		private EventHandlers LocalEvents;

		private bool enabled = false;
	}
}
