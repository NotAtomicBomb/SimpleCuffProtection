using System.Collections.Generic;


using Exiled.API.Interfaces;

using UnityEngine;

namespace SimpleCuffProtection
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;


    }
 }
