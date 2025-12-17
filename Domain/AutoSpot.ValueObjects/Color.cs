using AutoSpot.ValueObjects.Base;
using AutoSpot.ValueObjects.Validators;

namespace AutoSpot.ValueObjects;

public class Color(string color) : ValueObject<string>(new ColorValidator(), color);