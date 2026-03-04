import axios from "axios";
import type { EventBooking } from "../Models/EventBooking";
const getEventDetailsUrl = import.meta.env.VITE_EVENT_DETAILS_API_URL;

export const getAllEventDetailsAsync = async () => {
  try {
    const result = await axios.get<EventBooking[]>(`${getEventDetailsUrl}`);
    return result;
  } catch (err: any) {
    console.log(err);
  }
};
