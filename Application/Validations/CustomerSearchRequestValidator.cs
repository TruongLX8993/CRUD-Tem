﻿using Application.Queries;
using FluentValidation;

namespace Application.Validations
{
    public class CustomerSearchRequestValidator : AbstractValidator<CustomerSearchRequest>
    {
        public CustomerSearchRequestValidator()
        {
        }
    }
}