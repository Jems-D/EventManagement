using System;
using backend.Class;
using MediatR;

namespace backend.Features.Events.GetEvent;

public record GetEventByIdQuery(int id) : IRequest<EventBooking?>;
