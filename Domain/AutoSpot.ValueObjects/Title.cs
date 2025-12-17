using AutoSpot.ValueObjects.Base;
using AutoSpot.ValueObjects.Validators;

namespace AutoSpot.ValueObjects;

public class Title(string title) : ValueObject<string>(new TitleValidator(), title);