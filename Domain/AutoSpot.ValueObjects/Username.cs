using AutoSpot.ValueObjects.Base;
using AutoSpot.ValueObjects.Validators;

namespace AutoSpot.ValueObjects;

public class Username(string name) : ValueObject<string>(new UsernameValidator(), name);