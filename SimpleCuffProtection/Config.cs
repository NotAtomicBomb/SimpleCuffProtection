using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Interfaces;

namespace SimpleCuffProtection
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        [Description("The message to display when someone shoots a cuffed player!")]
        public string WarningMessage { get; set; } = "<color=red>You are shooting a handcuffed player!</color>";
        [Description("The amount of seconds the message will be shown.")]
        public float WarningMessageDuration { get; set; } = 3f;
        [Description("Allow the cuffer to deal damage to the cuffed player ? (to ensure compliance)")]
        public bool AllowCufferDamage { get; set; } = false;
        [Description("Disallow uncuffing a player except by the person who originally cuffed them ?")]
        public bool DisallowUncuffing { get; set; } = false;
        [Description("Teams Blacklisted from immunity (Default: MTF,CHAOS)")]
        public List<int> BlacklistedTeams { get; private set; } = new List<int>() { 1, 2 };
    }
 }
