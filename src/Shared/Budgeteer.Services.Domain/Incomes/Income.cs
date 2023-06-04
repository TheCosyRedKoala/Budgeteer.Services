﻿using Budgeteer.Services.Domain.Common;
using TCRK.DomainHelpers.Classes;

namespace Budgeteer.Services.Domain.Incomes;

public class Income : Entity
{
    public string Name { get; private set; }
    public decimal Amount { get; private set; }
    public RecurrenceType Recurrence { get; private set; }

    public Income(string name, decimal amount, RecurrenceType recurrence)
    {
        Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
        Amount = Guard.Against.Negative(amount, nameof(amount));
        Recurrence = Guard.Against.EnumOutOfRange(recurrence, nameof(recurrence));
    }
}
