﻿using System;
using System.Data;

namespace DeusVultClicker.Client.Shared.Store
{
    public record AppState(double Faith, int Followers, double Money, DateTime Timestamp, int IntervalInMs);
}
