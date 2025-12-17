using AutoSpot.ValueObjects.Base;
using AutoSpot.ValueObjects.Validators;

namespace AutoSpot.ValueObjects;

public class Torque(int value) : ValueObject<int>(new TorqueValidator(), value);