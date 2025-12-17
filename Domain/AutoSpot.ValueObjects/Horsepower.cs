using AutoSpot.ValueObjects.Base;
using AutoSpot.ValueObjects.Validators;

namespace AutoSpot.ValueObjects;

public class Horsepower(int value) : ValueObject<int>(new HorsepowerValidator(), value);
