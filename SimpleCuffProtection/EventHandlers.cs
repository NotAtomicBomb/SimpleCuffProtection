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
		private bool sndMessage = false;
		// Token: 0x06000006 RID: 6 RVA: 0x00002A1C File Offset: 0x00000C1C
		public void OnPlayerHurt(HurtingEventArgs ev)
		{



			bool flag = ev.Target.IsCuffed;
			Team attacteam = ev.Attacker.Team;
			Team targteam = ev.Target.Team;

			if (flag)
			{
				if (attacteam == Team.MTF || attacteam == Team.CHI || attacteam == Team.RSC || attacteam == Team.CDP)
				{
					//if (ev.DamageType == DamageTypes.Com15 || ev.DamageType == DamageTypes.E11StandardRifle || ev.DamageType == DamageTypes.Grenade || ev.DamageType == DamageTypes.Logicer || ev.DamageType == DamageTypes.MicroHid || ev.DamageType == DamageTypes.Mp7 || ev.DamageType == DamageTypes.P90 || ev.DamageType == DamageTypes.Usp) {
					
					if (ev.DamageType.isWeapon && !ev.DamageType.isScp)
					{
						if (!sndMessage)
						{


							ev.Attacker.ShowHint(SimpleCuffProtection.WarnMsg,SimpleCuffProtection.WarnDur);
							sndMessage = true;

						}
						Timing.CallDelayed(3f, () =>
						{
							sndMessage = false;
						});

						ev.Amount = 0;
					}
				}
			
			}
				
			
		}
	
	}
	
}
