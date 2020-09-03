using System;
using System.Diagnostics.Tracing;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Features;
using UnityEngine;
using MEC;
using UnityEngine.Assertions.Must;
using Exiled.Events.EventArgs;

namespace SimpleCuffProtection
{
	// Token: 0x02000003 RID: 3
	internal class EventHandlers
	{
		private Dictionary<Player, Player> Handcuffs = new Dictionary<Player, Player>();

		public void OnPlayerHurt(HurtingEventArgs ev)
		{
			if (ev.Target.IsCuffed && ev.DamageType.isWeapon)
			{
				ev.Amount = 0;
				ev.Attacker.ShowHint(SimpleCuffProtection.WarnMsg, SimpleCuffProtection.WarnDur);
			}
		}
		
		public void OnHandcuffing(HandcuffingEventArgs ev)
		{
			if (SimpleCuffProtection.DisableUncuffing && Handcuffs.ContainsKey(ev.Cuffer)) Handcuffs[ev.Cuffer] = ev.Target;
			else if (SimpleCuffProtection.DisableUncuffing) Handcuffs.Add(ev.Cuffer, ev.Target);
		}

		public void OnRemovingHandcuffs(RemovingHandcuffsEventArgs ev)
		{
			if (SimpleCuffProtection.DisableUncuffing) ev.IsAllowed = false;
		}

		public void OnChangingItem(ChangingItemEventArgs ev)
		{
			if (SimpleCuffProtection.DisableUncuffing && ev.NewItem.id == ItemType.Disarmer && Handcuffs.ContainsKey(ev.Player))
				ev.Player.Broadcast(5, "<b>If you'd like to uncuff the player you have cuffed earlier, drop the <color=#8A2BE2>Disarmer</color> by right-clicking on it in the inventory wheel.</b>");
		}

		public void OnDroppingItem(DroppingItemEventArgs ev)
		{
			if (SimpleCuffProtection.DisableUncuffing && ev.Item.id == ItemType.Disarmer && Handcuffs.ContainsKey(ev.Player))
				ev.Player.ClearBroadcasts();
			ev.Player.Broadcast(5, "<b>The player you have cuffed earlier has been uncuffed, feel free to pick up the <color=#8A2BE2>Disarmer</color> again.</b>");
			Handcuffs.Remove(ev.Player);
		}
	}
}
