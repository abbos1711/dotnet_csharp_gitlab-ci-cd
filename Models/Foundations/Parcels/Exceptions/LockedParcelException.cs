//=================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//=================================

using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Receivers.Exceptions
{
    public class LockedParcelException : Xeption
    {
        public LockedParcelException(Exception innerException)
            : base(message: "Receiver is locked, please try again.", innerException)
        { }
    }
}
