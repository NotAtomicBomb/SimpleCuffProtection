using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Interfaces;

using UnityEngine;

namespace SimpleCuffProtection
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        [Description("The message to display when someone shoots a cuffed player!")]
        public string WarningMessage { get; set; } = "<color=red>You are shooting a handcuffed player!</color>";
        [Description("The amount of seconds the message will be shown.")]
        public float WarningMessageDuration { get; set; } = 3f;
        [Description("Disallow uncuffing a player except by the person who originally cuffed them ?")]
        public bool DisableUncuffing { get; set; } = false;
    }
 }
