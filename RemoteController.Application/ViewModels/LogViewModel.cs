﻿using System;

namespace RemoteController.Application.ViewModels
{
    public class LogViewModel
    { 
        public DateTime Data { get; set; }

        public string CommandExeccuted { get; set; }

        public string Result { get; set; }

        public MachineViewModel Machine { get; set; }
    }
}
