﻿using System;
using Xeptions;

namespace dosLogistic.API.Models.Foundations.Users.Exceptions
{
    public class FailedUserStorageException : Xeption
    {
        public FailedUserStorageException(Exception innerException)
            : base(message: "Failed user storage error occurred, contact support.", innerException)
        { }
    }
}
