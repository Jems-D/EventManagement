import type { EventDetails } from "./EventDetails";

export interface EventBooking {
  eventName: string;
  eventDetails: EventDetails[];
}
