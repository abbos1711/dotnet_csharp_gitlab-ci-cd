﻿using Xeptions;

namespace dosLogistic.API.Models.Processings.Users
{
    public class UserProcessingValidationException : Xeption
    {
        public UserProcessingValidationException(Xeption innerException)
            : base(message: "PostImpression validation error occurred, please try again.", innerException)
        { }
    }
}
