using AutoSpot.ValueObjects.Base;
using AutoSpot.ValueObjects.Validators;

namespace AutoSpot.ValueObjects;

public class EngineVolume(decimal liters) : ValueObject<decimal>(new EngineVolumeValidator(), liters);